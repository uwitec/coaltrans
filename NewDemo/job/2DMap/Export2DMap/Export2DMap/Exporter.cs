using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using System.Xml;
using Autonomy.Demo.Dal;

namespace Export2DMap
{
    public class Exporter
    {
        public void Save()
        {
            long latestTimeStamp = 0;
            long preTimeStamp = 0;

            //备份底图文件
            BackUpFile(ref latestTimeStamp, ref preTimeStamp);

            //备份数据
            Cluster2DMapEntity map = new Cluster2DMapEntity();
            map.ClusterTimeId = latestTimeStamp;
            map.PreClusterTimeId = preTimeStamp;
            Cluster2DMapEntity.Cluster2DMapDAO mapDao = new Cluster2DMapEntity.Cluster2DMapDAO();
            mapDao.Add(map);

            XmlDocument contentDoc = Query();
            //Create an XmlNamespaceManager for resolving namespaces.
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(contentDoc.NameTable);
            nsmgr.AddNamespace("autn", "http://schemas.autonomy.com/aci/");
            //Select the book node with the matching attribute value.
            XmlNodeList clusters = contentDoc.SelectNodes("autnresponse/responsedata/autn:clusters/autn:cluster", nsmgr);
            //string nodeId;
            int nodeTop;
            int nodeLeft;
            //string nodeTitleId;
            string nodeTitle;
            //int clusterNum = 0;

            foreach (XmlNode cluster in clusters)
            {
                nodeTitle = cluster.SelectSingleNode("autn:title", nsmgr).InnerText;
                nodeLeft = int.Parse(cluster.SelectSingleNode("autn:x_coord", nsmgr).InnerText);
                nodeTop =  int.Parse(cluster.SelectSingleNode("autn:y_coord", nsmgr).InnerText);
               
                Cluster2DPointEntity point = new Cluster2DPointEntity();
                point.MapTimeId = latestTimeStamp;
                point.ClusterX = nodeLeft;
                point.ClusterY = nodeTop;
                point.ClusterTitle = nodeTitle;
                Cluster2DPointEntity.Cluster2DPointDAO pointDao = new Cluster2DPointEntity.Cluster2DPointDAO();
                long pointId = pointDao.Add(point);

                foreach (XmlNode docNode in cluster.SelectNodes("autn:docs/autn:doc", nsmgr))
                {
                    string title = docNode.SelectSingleNode("autn:title", nsmgr).InnerText;
                    string reference = docNode.SelectSingleNode("autn:ref", nsmgr).InnerText;

                    Cluster2DDocEntity doc = new Cluster2DDocEntity();
                    doc.DocRef = reference;
                    doc.DocTitle = title;
                    doc.PointId = pointId;
                    Cluster2DDocEntity.Cluster2DDocDAO docDao = new Cluster2DDocEntity.Cluster2DDocDAO();
                    docDao.Add(doc);
                }
            }
        }

        private XmlDocument Query()
        {
            string actUrl = ConfigurationManager.AppSettings["IdolACIPort"] + "/action=ClusterResults&SourceJobname=myjob_clusters&MaxTerms=0&NumResults=200";
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(actUrl);
            myRequest.Method = "GET";
            myRequest.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            XmlDocument contentDoc = new XmlDocument();
            contentDoc.LoadXml(content);
            return contentDoc;
        }

        public bool BackUpFile(ref long latestTimeStamp, ref long preTimeStamp)
        {
            string srcDirectory = ConfigurationManager.AppSettings["Src2DMapDirectory"].ToString();
            string desDirectory = ConfigurationManager.AppSettings["Des2DMapDirectory"].ToString();          
            
            string[] fileNames = Directory.GetFiles(srcDirectory);
            List<long> timeStamps = new List<long>();

            for (int i = 0;i <fileNames.Length ; i++)
            {
                long timeStamp;
                string[] timeStampFiles = fileNames[i].Split('-');
                if (timeStampFiles.Length >= 2 
                    && long.TryParse(timeStampFiles[1].Split('.')[0], out timeStamp))
                {
                    timeStamps.Add(timeStamp);
                }
            }

            if (timeStamps.Count > 0)
            {
                if (timeStamps.Count > 1)
                {
                    //对timeStamps排序
                    timeStamps.Sort(new TimeStampCompare<long>());
                    latestTimeStamp = timeStamps[0];
                    preTimeStamp = timeStamps[1];
                }
                else
                {
                    latestTimeStamp = timeStamps[0];
                    preTimeStamp = -1;
                }

                string srcFile = srcDirectory + "myjob_clusters-" + latestTimeStamp + ".jpeg";
                string desFile = desDirectory + latestTimeStamp + ".jpeg";
                File.Copy(srcFile, desFile, true);

                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class TimeStampCompare<T> : IComparer<long>
    {
        #region IComparer<long> Members

        public int Compare(long x, long y)
        {
            if (x > y)
            {
                return -1;
            }
            else if (x == y)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        #endregion
    }
}
