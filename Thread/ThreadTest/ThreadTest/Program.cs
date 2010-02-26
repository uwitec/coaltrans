using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;

namespace ThreadTest
{
    class Program
    {
        private static XmlDocument XmlDoc;
        public Program()
        {
            XmlDoc = new XmlDocument();
            string path = System.Environment.CurrentDirectory.ToString();
            path = path.Replace("bin\\Debug", "") + "weblist.xml";
            XmlDoc.Load(path);
            XmlNode root = XmlDoc.SelectSingleNode("Web_Url_List");
            root.RemoveAll();
        }

        public static WaitCallback waitCallback = new WaitCallback(MyThreadWork);

        public static void Main()
        {
            Program Pro = new Program();
            //string rootUrl = "http://www.tianya.cn/publicforum/articleslist/0/free.shtml";
            //ThreadPool.QueueUserWorkItem(waitCallback, rootUrl);
            //Console.ReadLine();
            //GetConcreteUrl Pro1 = new GetConcreteUrl();
            //Pro1.LStart();
            //Console.ReadLine();
            GetXmlStr xmlstr = new GetXmlStr();
            xmlstr.LStart();
            Console.ReadLine();
        }

        public static void MyThreadWork(object state)
        {
            WriteXml(state.ToString());
            WebList list = new WebList(state.ToString());
            string rootUrl = list.ListStart();

            if (!string.IsNullOrEmpty(rootUrl))
            {
                ThreadPool.QueueUserWorkItem(waitCallback, rootUrl);
            }
            else
            {
                Console.WriteLine("执行完毕，按回车键抓取列表");
            }
        }
        public static void WriteXml(string Url)
        {
            XmlNode root = XmlDoc.SelectSingleNode("Web_Url_List");
            XmlElement xe1 = XmlDoc.CreateElement("Web_Url");
            xe1.InnerText = Url; 
            root.AppendChild(xe1);  
            string path = System.Environment.CurrentDirectory.ToString();
            path = path.Replace("bin\\Debug", "") + "weblist.xml";
            XmlDoc.Save(path);
        }        
    }
}
