using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coal.Util;
using System.Data;
using Coal.Entity;
using System.Data.SqlClient;

namespace Coal.BLL
{
    public class RegionManager
    {
        public class RegionMap
        {
            private static LRUObjectCache<int, List<Region>> listData = new LRUObjectCache<int, List<Region>>();
            private static LRUObjectCache<int, Region> regionData = new LRUObjectCache<int, Region>();

            public static List<Region> GetRegions(int parentId)
            {
                List<Region> regions = listData[parentId];
                if (regions == null)
                {
                    listData[parentId] = FindRegionByParentId(parentId);
                }

                return listData[parentId];
            }

            public static Region GetRegion(int id)
            {
                if (regionData[id] != null)
                {
                    return regionData[id];
                }
                else
                {
                    Region category = FindRegion(id);
                    regionData[id] = category;
                    return category;
                }
            }

            static RegionMap()
            {
                Init(-1);
            }

            private static void Init(int root)
            {
                listData[root] = FindRegionByParentId(root);
            }

            private static List<Region> FindRegionByParentId(int parentId)
            {
                RegionEntity.RegionDAO regionDao = new RegionEntity.RegionDAO();
                List<RegionEntity> parentRegions = regionDao.Find(" parent = @parent",
                    new SqlParameter[] { new SqlParameter("parent", parentId)});

                List<Region> regions = new List<Region>();
                if (parentRegions != null && parentRegions.Count > 0)
                {
                    foreach (RegionEntity r in parentRegions)
                    {
                        Region region = new Region();
                        region.ID = r.Id.Value;
                        region.Name = r.Name;
                        regions.Add(region);
                    }
                }

                return regions;
            }

            private static Region FindRegion(int id)
            {
                RegionEntity.RegionDAO regionDao = new RegionEntity.RegionDAO();
                List<Region> categories = new List<Region>();
                RegionEntity rEntity = regionDao.FindById(id);

                if (rEntity != null)
                {
                    Region region = new Region();
                    region.ID = rEntity.Id.Value;
                    region.Name = rEntity.Name;
                    return region;
                }
                else
                {
                    return null;
                }
            }
        }

        public class Region
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
}
