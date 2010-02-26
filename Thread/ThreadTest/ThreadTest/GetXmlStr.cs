using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using System.IO;

namespace ThreadTest
{
    public class GetXmlStr
    {
        private static XmlDocument XmlDoc1;        
        private static IList<XmlNode> StringList;
        private static string XmlStr;
        public GetXmlStr()
        {
            //定义XmlDoc1
            XmlDoc1 = CreateXmlDoc("ListUrl0226043253.xml");
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
            GetXmlStr Pro = new GetXmlStr();
            XmlStr += "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            XmlStr += "<docs>";
            int MaxWorkerThreads = 25;
            int MaxIOCompletionThreads = 2000;
            int MinWorkerThreads = 1;
            ThreadPool.GetMaxThreads(out MaxWorkerThreads, out MaxIOCompletionThreads);
            ThreadPool.GetMinThreads(out MinWorkerThreads, out MaxIOCompletionThreads);
            Console.WriteLine("开始" + DateTime.Now.ToString());
            if (StringList.Count > 0)
            {                
                ThreadPool.QueueUserWorkItem(waitCallback, StringList[0]);                
            }                
        }
        private static XmlDocument CreateXmlDoc(string fileName)
        {
            XmlDocument XmlDoc = new XmlDocument();
            string path = System.Environment.CurrentDirectory.ToString();
            path = path.Replace("bin\\Debug", "contet\\") + fileName;
            XmlDoc.Load(path);
            return XmlDoc;
        }
        private static IList<XmlNode> CreateStringList(XmlDocument XmlDoc)
        {
            IList<XmlNode> List = new List<XmlNode>();
            XmlNodeList hits = XmlDoc.SelectNodes("docs")[0].ChildNodes;
            foreach (XmlNode hit in hits)
            {
                List.Add(hit);
            }
            return List;
        }
        public static void MyThreadWork(object state)
        {
            XmlStr += "<doc>";
            XmlNode Node = (XmlNode)state;
            string url = Node.SelectSingleNode("doc_url").InnerText;
            Console.WriteLine("初始content" + DateTime.Now.ToString());
            GetContent content = new GetContent(url);
            Console.WriteLine("获得content" + DateTime.Now.ToString());
            XmlStr += "<doc_url><![CDATA[" + Node.ChildNodes[0].InnerText + "]]></doc_url>";
            XmlStr += "<doc_mySrcType><![CDATA[" + Node.ChildNodes[1].InnerText + "]]></doc_mySrcType>";
            XmlStr += "<doc_MyDate><![CDATA[" + Node.ChildNodes[2].InnerText + "]]></doc_MyDate>";
            XmlStr += "<doc_title><![CDATA[" + content.ArticleTitle + "]]></doc_title>";
            XmlStr += "<doc_MySiteName><![CDATA[" + content.SiteName + "]]></doc_MySiteName>";
            XmlStr += "<doc_content><![CDATA[" + content.ArticleContent + "]]></doc_content>";
            XmlStr += "</doc>";
            //WriteXml(_UrlList);
            StringList.RemoveAt(0);
            Console.WriteLine("赋值XmlStr" + DateTime.Now.ToString());
            if (StringList.Count > 0)
            {
                ThreadPool.QueueUserWorkItem(waitCallback, StringList[0]);
            }
            else
            {
                XmlStr += "</docs>";
                XmlDoc1.LoadXml(XmlStr);
                string path = System.Environment.CurrentDirectory.ToString();
                path = path.Replace("bin\\Debug", "contet\\") + "ListUrl0226043253.xml";
                XmlDoc1.Save(path);
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine("三级页面链接抓取完毕！");
            }            
            
        }
    }
}
