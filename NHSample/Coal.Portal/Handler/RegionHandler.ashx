<%@ WebHandler Language="C#" Class="RegionHandler" %>

using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using Coal.Util;
using Coal.BLL;

public class RegionHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    { 
        BindRegions(context);
    }

    private static void BindRegions(HttpContext context)
    {
        int parentId = EConvert.ToInt(context.Request["parent_id"]);

        List<RegionManager.Region> regions = RegionManager.RegionMap.GetRegions(parentId);

        ResultObject ro = new ResultObject();
        ArrayList list = new ArrayList();

        if (regions != null)
        {
            ro.StatusCode = 1;
            ro.ErrorCode = -1;

            foreach (RegionManager.Region region in regions)
            {
                SortedList dict = new SortedList();
                dict["id"] = region.ID;
                dict["name"] = region.Name;
                list.Add(dict);
            }
        }

        ro["regions"] = list;
        context.Response.Write(ro.ToJSONString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}