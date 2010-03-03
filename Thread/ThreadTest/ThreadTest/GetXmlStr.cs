using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace ThreadTest
{
    public class GetXmlStr
    {
        private ManualResetEvent _DoneEvent;
        private XmlDocument _XmlDoc1;        
        private IList<XmlNode> _StringList;        
        private int Num = 25;
        private int DieNum = 0;
        private StringBuilder XmlStr;
        private string _FileName;

        public GetXmlStr(string Url,ManualResetEvent DoneEvent)
        {
            _FileName = Url;
            _DoneEvent = DoneEvent;
            _XmlDoc1 = CreateXmlDoc(Url);
            _StringList = Create_StringList(_XmlDoc1);
        }
        public void Action(object Url)
        {
            string StrUrl = Url.ToString();            
            LStart();           
            
        }
        public void LStart()
        {       
            Thread[] ThreadList = new Thread[Num];
            for (int i = 0; i < Num; i++)
            {
                ThreadList[i] = new Thread(new ThreadStart(Run));
                ThreadList[i].Name = i.ToString();
            }            
            XmlStr = new StringBuilder();
            XmlStr.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            XmlStr.Append("<docs>"); 
            for (int i = 0; i < Num; i++)
            {
                ThreadList[i].Start();
            }
        }
        private static XmlDocument CreateXmlDoc(string _FileName)
        {
            XmlDocument XmlDoc = new XmlDocument();            
            XmlDoc.Load(_FileName);
            return XmlDoc;
        }
        private static IList<XmlNode> Create_StringList(XmlDocument XmlDoc)
        {
            IList<XmlNode> List = new List<XmlNode>();
            XmlNodeList hits = XmlDoc.SelectNodes("docs")[0].ChildNodes;
            foreach (XmlNode hit in hits)
            {
                List.Add(hit);
            }
            return List;
        }
        private void Run()
        {
            int Index = -1;
            while (true)
            {
                if (Index == -1)
                {
                    Index = Convert.ToInt32(Thread.CurrentThread.Name);
                }
                if (Index < _StringList.Count)
                {
                    try
                    {
                        XmlNode Node = (XmlNode)_StringList[Index];
                        string url = Node.SelectSingleNode("doc_url").InnerText;                        
                        GetContent content = new GetContent(url);
                        Console.WriteLine(_FileName);
                        Console.WriteLine(url);
                        XmlStr.Append("<doc>");
                        XmlStr.Append("<doc_url><![CDATA[" + Node.ChildNodes[0].InnerText + "]]></doc_url>");
                        XmlStr.Append("<doc_mySrcType><![CDATA[" + Node.ChildNodes[1].InnerText + "]]></doc_mySrcType>");
                        XmlStr.Append("<doc_MyDate><![CDATA[" + Node.ChildNodes[2].InnerText + "]]></doc_MyDate>");
                        XmlStr.Append("<doc_title><![CDATA[" + content.ArticleTitle + "]]></doc_title>");
                        XmlStr.Append("<doc_MySiteName><![CDATA[" + content.SiteName + "]]></doc_MySiteName>");
                        XmlStr.Append("<doc_content><![CDATA[" + RemoveHTML(content.ArticleContent) + "]]></doc_content>");
                        //XmlStr.Append("<doc_comment><![CDATA[" + RemoveHTML(content.ArticleComment) + "]]></doc_comment>");
                        XmlStr.Append("</doc>");
                        Index = Index + Num;
                    }
                    catch { }
                }
                else if (Index >= _StringList.Count)
                {
                    DieNum = DieNum + 1;
                    if (DieNum == Num)
                    {
                        XmlStr.Append("</docs>");
                        _XmlDoc1.LoadXml(XmlStr.ToString());  
                        _XmlDoc1.Save(_FileName);
                        Console.WriteLine(DateTime.Now.ToString());
                        Console.WriteLine("三级页面" + _FileName + "抓取完毕！");
                        _DoneEvent.Set();
                    }
                    Thread.CurrentThread.Abort();
                }               
            }
        }
        private string RemoveHTML(String text)
        {
            try
            {
                Regex regex = new Regex(@"<[^>]*>", RegexOptions.IgnoreCase);
                text = regex.Replace(text, "");
                text = Regex.Replace(text, "[\\s]{2,}", " ");//两个以上的空格
                return text;
            }
            catch
            {
                return "";
            }
        }
    }
}
