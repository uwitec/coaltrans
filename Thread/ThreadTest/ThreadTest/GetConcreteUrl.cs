using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;

namespace ThreadTest
{
    public class GetConcreteUrl
    {
        private static XmlDocument XmlDoc1;
        private static XmlDocument XmlDoc2;
        private static IList<string> StringList;
        
        public GetConcreteUrl()
        {
            //定义XmlDoc1
            XmlDoc1 = CreateXmlDoc("weblist.xml");
            //定义XmlDoc2
            //XmlDoc2 = CreateXmlDoc("ListUrl.xml");
            
            //XmlNode root = XmlDoc2.SelectSingleNode("List_Url");
            //root.RemoveAll();
            //定义StringList
            StringList = CreateStringList(XmlDoc1);
        }
        public static WaitCallback waitCallback = new WaitCallback(MyThreadWork);

        public void LStart()
        {
            GetConcreteUrl Pro = new GetConcreteUrl();
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
            else
            {
                Console.WriteLine("二级页面链接抓取完毕！");
            }
        }
        public static void WriteXml(IList<string> List)
        {
            //XmlNode root = XmlDoc2.SelectSingleNode("List_Url");
            string xmlstr = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            xmlstr += "<docs>";
            if (List != null)
            {
                foreach (string obj in List)
                {
                    xmlstr += "<doc>";
                    xmlstr += WriteContent(null, obj);
                    xmlstr += "</doc>";                    
                }
            }
            xmlstr += "</docs>";
            XmlDoc2 = new XmlDocument();
            XmlDoc2.LoadXml(xmlstr);
            string path = System.Environment.CurrentDirectory.ToString();
            path = path.Replace("bin\\Debug", "contet\\") + "ListUrl" + DateTime.Now.ToString("MMddhhmmss") + ".xml";
            XmlDoc2.Save(path);
        }
        public static string WriteContent(XmlElement xel,string obj)
        {            
            string Str = "";
            if (!string.IsNullOrEmpty(obj))
            {
                string[] List = obj.Split('※');
                //GetContent Content = new GetContent(List[0].ToString());
                Str += "<doc_url><![CDATA[" + List[0].ToString() + "]]></doc_url>";
                Str += "<doc_mySrcType><![CDATA[fosrum]]></doc_mySrcType>";
                //Str += "<doc_title><![CDATA[" + Content.ArticleTitle + "]]></doc_title>";
                //Str += "<doc_MySiteName><![CDATA[" + Content.SiteName + "]]></doc_MySiteName>";
                Str += "<doc_MyDate><![CDATA[" + List[1].ToString() + "]]></doc_MyDate>";
                //Str += "<doc_content><![CDATA[" + Content.ArticleContent + "]]></doc_content>";
            }
            return Str;
        }
    }
}
