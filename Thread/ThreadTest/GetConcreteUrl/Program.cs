using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;

namespace GetConcreteUrl
{
    public class Program
    {
        private static XmlDocument XmlDoc1;
        private static XmlDocument XmlDoc2;
        private static IList<string> StringList;
        
        public Program()
        {
            //定义XmlDoc1
            XmlDoc1 = CreateXmlDoc("weblist.xml");
            //定义XmlDoc2
            XmlDoc2 = CreateXmlDoc("ListUrl.xml");
            XmlNode root = XmlDoc2.SelectSingleNode("List_Url");
            root.RemoveAll();
            //定义StringList
            StringList = CreateStringList(XmlDoc1);
        }
        public static WaitCallback waitCallback = new WaitCallback(MyThreadWork);

        public static void Main()
        {
            Program Pro = new Program();
            if (StringList.Count > 0)
            {                
                ThreadPool.QueueUserWorkItem(waitCallback, StringList[0]);                
            }                
        }
        private static XmlDocument CreateXmlDoc(string fileName)
        {
            XmlDocument XmlDoc = new XmlDocument();
            string path = System.Environment.CurrentDirectory.ToString();
            path = path.Replace("bin\\Debug", "") + fileName;
            XmlDoc.Load(path);
            return XmlDoc;
        }
        private static IList<string> CreateStringList(XmlDocument XmlDoc)
        {
            IList<string> List = new List<String>();
            XmlNodeList hits = XmlDoc.SelectNodes("Web_Url_List")[0].ChildNodes;
            foreach (XmlNode hit in hits)
            {
                List.Add(hit.InnerText.Replace("amp;", ""));
            }
            return List;
        }
        public static void MyThreadWork(object state)
        {           
            ListUrl List = new ListUrl(state.ToString());
            IList<string> _UrlList = List.Start();
            WriteXml(_UrlList);
            StringList.RemoveAt(0);
            if (StringList.Count > 0)
            {
                ThreadPool.QueueUserWorkItem(waitCallback, StringList[0]);
            }            
        }
        public static void WriteXml(IList<string> List)
        {
            XmlNode root = XmlDoc2.SelectSingleNode("List_Url");
            if (List != null)
            {
                foreach(string obj in List)
                {
                    XmlElement xe1 = XmlDoc2.CreateElement("Url");
                    xe1.InnerText = obj;
                    root.AppendChild(xe1);
                }
            }           
            string path = System.Environment.CurrentDirectory.ToString();
            path = path.Replace("bin\\Debug", "") + "ListUrl.xml";
            XmlDoc2.Save(path);
        }       
    }
}
