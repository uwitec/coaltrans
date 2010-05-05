using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Web;

namespace IdxSource
{
    public partial class Form1 : Form
    {
        private XMLNodeMode _emNodeMode;
        private int _maxPageCount;
        private int _pageSize;
        private Encoding _encoding ;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //
            SetBaiduNewParam();
        }

        private void SetBaiduNewParam()
        {

            string URLSeed = @"http://news.baidu.com/ns?bt=0&et=0&si=&rn=100&tn=newsA&ie=gb2312&ct=1&word={0}&pn={1}&cl=2";            
            int pageCount = 3;
            int pageSize = 100;
            //string regtex = "<td class=\"text\"><a href=\"([\\s\\S]+?) \"  mon=\"a=5[\\s\\S]+?<span><b>([\\s\\S]+?)</b></span></a> <font color=#6f6f6f> <nobr>([\\s\\S]+?) ([\\s\\S]+?)</nobr></font><br><font size=-1>([\\s\\S]+?)\\.\\.\\.</font>";
            string regtex = "<table cellspacing=0 cellpadding=2>\n<tr>([\\s\\S]+?)<td class=\"text\"><a href=\"([\\s\\S]+?) \"  mon=\"a=5[\\s\\S]+?<span><b>([\\s\\S]+?)</b></span></a> <font color=#6f6f6f> <nobr>([\\s\\S]+?) ([\\s\\S]+?)</nobr></font><br><font size=-1>([\\s\\S]+?)</font>    \n(<a href=\"/ns\\?([\\s\\S]+?) \"><font color=#008000>(\\d+)条相同新闻&gt;&gt;</a></font>)?\n</td></tr></table><br>";
            string fileSeed = @"C:\Autonomy\outPut_{0}_{1}.xml";
            XMLNodeMode nodeMode = XMLNodeMode.BaiduNews;

            tb_path1.Text = @"C:\Autonomy\baiduhot\hot_{0}.xml";
            richTextBox_hot.Text = "</span><a target=\"_blank\" href=\"([\\s\\S]+?)\" mon=\"r=1\">([\\s\\S]+?)</a></li>";
            tb_pageCount.Text = pageCount.ToString();
            tb_URLSeed.Text = URLSeed;
            tb_fileSeed.Text = fileSeed;
            richTextBox_RegExpress.Text = regtex;
            _emNodeMode = nodeMode;
            _maxPageCount = pageCount;

            _pageSize = pageSize;
            _encoding = Encoding.GetEncoding("gb2312");
        }

        private void SetBaiduParam()
        {

            string URLSeed = @"http://www.baidu.com/s?wd={0}&pn={1}&rn=100";
            int pageCount = 3;
            int pageSize = 100;
            //<table border="0" cellpadding="0" cellspacing="0" [\s\S]+? href="([\s\S]+?)"  target="_blank" ><font size="3">([\s\S]+?)</font></a><br><font size=-1>([\s\S]+?)<br><font color="#008000">([\s\S]+?( \.\.\. )?[\S]+?( \.\.\. )?) ([\S]+?) ( |繁体)</font>([\s\S]+?) <br></font></td></tr></table><br>
            string regtex = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" [\\s\\S]+? href=\"([\\S]+?)\"  target=\"_blank\" ><font size=\"3\">([\\s\\S]+?)</font></a><br><font size=-1>([\\s\\S]+?)<br><font color=\"#008000\">([\\s\\S]+?( \\.\\.\\. )?[\\S]+?( \\.\\.\\. )?) ([\\S]+?) ( |繁体)</font>([\\s\\S]+?) <br></font></td></tr></table><br>";
            string fileSeed = @"C:\Autonomy\outPut_{0}_{1}.xml";
            XMLNodeMode nodeMode = XMLNodeMode.Baidu;

            tb_path1.Text = @"C:\Autonomy\baiduhot\hot_{0}.xml";
            //richTextBox_hot.Text = "</span><a target=\"_blank\" href=\"([\\s\\S]+?)\" mon=\"r=1\">([\\s\\S]+?)</a></li>";
            tb_pageCount.Text = pageCount.ToString();
            tb_URLSeed.Text = URLSeed;
            tb_fileSeed.Text = fileSeed;
            richTextBox_RegExpress.Text = regtex;
            _emNodeMode = nodeMode;
            _maxPageCount = pageCount;

            _pageSize = pageSize;
            _encoding = Encoding.GetEncoding("gb2312");
        }

        private void ShowBaiduNews()
        {
            

            //textBox_URLInput.Text = "http://news.baidu.com/ns?word={0}&bt={1}&et={2}&si=&rn=100&tn=newsdy&ie=gb2312&ct=1&cl=3&pn={3}";
            tb_URLSeed.Text = "http://news.baidu.com/ns?word={0}&si=&rn=100&tn=newsdy&ie=gb2312&ct=1&cl=3&pn={1}";

            richTextBox_RegExpress.Text = "<td class=\"text\"><a href=\"([\\s\\S]+?) \"  mon=\"a=5[\\s\\S]+?<span><b>([\\s\\S]+?)</b></span></a> <font color=#6f6f6f> <nobr>([\\s\\S]+?) ([\\s\\S]+?)</nobr></font><br><font size=-1>([\\s\\S]+?)\\.\\.\\.</font>";

            tb_fileSeed.Text = @"C:\Autonomy\xml\100224\bnew_{0}_{1}.xml";
        }

        private void  GetBaiduNewsURl()
        {

        }

        private void textBox_URLInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_codein_TextChanged(object sender, EventArgs e)
        {
            string incode = tb_codein.Text;

            string outString = UrlEnCode(incode);// +" # " + UniCodetoAsciiCode(incode);
            //HttpContext.Current.Server.UrlEncode s;
            //string outString = HttpServerUtility.UrlEncode(incode);
            //System.Web.
            tb_codeout.Text = outString;
        }

        private string UrlEnCode(string str)
        {
            //HttpContext s = new HttpContext();
            //HttpUtility server = new HttpUtility();
            //HttpUtility.UrlEncode
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            Encoding unicode = Encoding.Unicode;
            Encoding utf8code = Encoding.UTF8;
            return HttpUtility.UrlEncode(str) + " #GB " + HttpUtility.UrlEncode(str, gb2312) + " #u8 " + HttpUtility.UrlEncode(str, utf8code) + " #un " + HttpUtility.UrlEncode(str, unicode);
            //return s.UrlEncode(str);
        }
        private string UniCodetoAsciiCode(string incode)
        {
            // Create two different encodings.
            Encoding ascii = Encoding.ASCII;
            Encoding utf8code = Encoding.UTF8;
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            // Convert the string into a byte[].
            byte[] unicodeBytes = utf8code.GetBytes(incode);
            byte[] gbcodeBytes = gb2312.GetBytes(incode);

            //// Perform the conversion from one encoding to the other.
            //byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            //char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            //ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            //string asciiString = new string(asciiChars);

            StringBuilder sb = new StringBuilder();
            sb.Append("UTF8Code:");
            for (int i = 0; i < unicodeBytes.Length; i++)
            {
                sb.Append("%" + Convert.ToString(unicodeBytes[i], 16));
            }
            sb.Append(" GB2312:");
            for (int i = 0; i < gbcodeBytes.Length; i++)
            {
                sb.Append("%" + Convert.ToString(gbcodeBytes[i], 16));
            }
            return sb.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            char[] charSeparators = new char[] { ';' };
            tb_Link.Text = string.Format(tb_URLSeed.Text, HttpUtility.UrlEncode(tb_KeyWords.Text,_encoding),0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] charSeparators = new char[] { ';' };
            tb_path.Text = string.Format(tb_fileSeed.Text, tb_path1.Text.Split(charSeparators));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(tb_Link.Text);
            myRequest.Method = "GET";
            myRequest.ContentType = "application/x-www-form-urlencoded";

            // Get response
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
            string content = reader.ReadToEnd();

            richTextBox_Content.Text = content;
        }

        private void btn_match_Click(object sender, EventArgs e)
        {
            Regex r;
            Match m;


            r = new Regex(richTextBox_RegExpress.Text, RegexOptions.IgnoreCase | RegexOptions.Compiled);


            m = r.Match(richTextBox_Content.Text);
            if(m.Success)
            {
                StringBuilder sb_match = new StringBuilder();
                for (int i = 1; i < m.Groups.Count; i++)
                {
                    sb_match.Append("$").Append(i.ToString()).Append(": ").Append(m.Groups[i].Value).Append(System.Environment.NewLine);
                }

                sb_match.Append(Pagetoxml.GetNodeValue(m,_emNodeMode,""));

                richTextBox_hot.Text = sb_match.ToString();
                
            }            
        }

        private void bn_OUTXML_Click(object sender, EventArgs e)
        {
            string content = richTextBox_Content.Text;

            Regex r;
            Match m;


            r = new Regex(richTextBox_RegExpress.Text, RegexOptions.IgnoreCase | RegexOptions.Compiled);

            StringBuilder xml = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xml.Append("<docs>");

            for (m = r.Match(content); m.Success; m = m.NextMatch())
            {
                xml.Append(Pagetoxml.GetBaiduNewsNode(m,""));
            }

            xml.Append("</docs>");

            FileStream nFile = new FileStream(tb_path.Text, FileMode.CreateNew);
            using (StreamWriter writer = new StreamWriter(nFile))
            {
                writer.Write(xml.ToString());
            }
            MessageBox.Show("OK");
        }

        private void bn_do_Click(object sender, EventArgs e)
        {
            string urlSeed = tb_URLSeed.Text ;
            string fileSeed = tb_fileSeed.Text;
            string regtex = richTextBox_RegExpress.Text;
            XMLNodeMode nodeMode = _emNodeMode;
            int userpageCount;
            int pageCount = _maxPageCount;
            if (int.TryParse(tb_pageCount.Text,out userpageCount))
            {
                pageCount = userpageCount;
            }
            
            int pageSize = _pageSize;
            char[] charSeparators = new char[] { ';' };
            string[] words = tb_KeyWords.Text.Split(charSeparators);

            Pagetoxml.Do(urlSeed, words, pageSize, pageCount, fileSeed, regtex, nodeMode, _encoding,false);
        }

        private void tb_urlparam_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox_RegExpress_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            string URLSeed = @"http://www.google.cn/custom?hl=zh-CN&newwindow=1&client=pub-9567569708077095&cof=FORID:13%3BAH:left%3BCX:%25E5%25A4%25A9%25E6%25B6%25AF%25E7%25A4%25BE%25E5%258C%25BA%25E6%2590%259C%25E7%25B4%25A2%25E5%25BC%2595%25E6%2593%258E%3BL:http://www.google.com/intl/zh-CN/images/logos/custom_search_logo_sm.gif%3BLH:30%3BLP:1%3BVLC:%23551a8b%3BDIV:%23cccccc%3B&cx=001806228871176379899:cmxrka8rlbc&adkw=AELymgXDpDl41zXJlXLe-eKZF1xHly4ACu7FwGqFcB46-ipGZ3WzWWF2f_xSNbAS30ws9W2L8PSr7XgMYNh2N_uDMxjY_XTfPRvxhpKST4lCP0Sx_0HzfKA&boostcse=0&q={0}&start={1}&sa=N";
            int pageCount = 10;
            int pageSize = 10;
            string regtex = "<li><div class=g>           <h2 class=r><a href=\"([\\s\\S]+?)\" target=_blank class=l>([\\s\\S]+?)</a></h2><table border=0 cellpadding=0 cellspacing=0><tr><td class=\"j\"><div class=std>([\\s\\S]+?)<br><span class=a>([\\s\\S]+?)</span><nobr></nobr></div>           </td></tr></table></div>";
            string fileSeed = @"C:\xml\天涯\outPut_{0}_{1}.xml";
            XMLNodeMode nodeMode = XMLNodeMode.TianyaGoogle;

            tb_URLSeed.Text = URLSeed;
            tb_fileSeed.Text = fileSeed;
            richTextBox_RegExpress.Text = regtex;
            _emNodeMode = nodeMode;
            _maxPageCount = pageCount;
            _pageSize = pageSize;
            _encoding = Encoding.UTF8;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            string URLSeed = @"http://news.sogou.com/news?query={0}&page={1}&time=0&sort=1&mode=1";
            int pageCount = 10;
            int pageSize = 10;
            string regtex = "<a class=\"pp\" href=\"([\\s\\S]+?)\"[\\s\\S]+?<b>([\\s\\S]+?)</b>[\\s\\S]+?<p class=\"newstime\">([\\s\\S]+?) &nbsp;([\\s\\S]+?)</p>[\\s\\S]+?<p>([\\s\\S]+?)</p></td>";
            string fileSeed = @"C:\xml\sogou\outPut_{0}_{1}.xml";
            XMLNodeMode nodeMode = XMLNodeMode.SogouNews;

            tb_URLSeed.Text = URLSeed;
            tb_fileSeed.Text = fileSeed;
            richTextBox_RegExpress.Text = regtex;
            _emNodeMode = nodeMode;
            _maxPageCount = pageCount;
            _pageSize = pageSize;
            _encoding = Encoding.GetEncoding("gb2312");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            _encoding = Encoding.UTF8;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string content = richTextBox_Content.Text;
            
            Regex r;
            Match m;

            r = new Regex(richTextBox_hot.Text, RegexOptions.IgnoreCase | RegexOptions.Compiled);


            for (m = r.Match(content); m.Success; m = m.NextMatch())
            {
                string old20url = m.Groups[1].Value;
                string keyword = m.Groups[2].Value;
                string new100url = old20url.Replace(@"&rn=20", @"&rn=100");
                
                Pagetoxml.GenerateXml(new100url, richTextBox_RegExpress.Text, string.Format(tb_path1.Text, keyword), XMLNodeMode.BaiduNews, keyword,true);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime oldDate = new DateTime(1970, 1, 1);
            DateTime newDate = dateTimePicker1.Value;//DateTime.Now;

            // Difference in days, hours, and minutes.
            TimeSpan ts = newDate - oldDate;

            double differenceInSeconds = ts.TotalSeconds;
            //MessageBox.Show(differenceInSeconds.ToString());
            tb_seconds.Text = differenceInSeconds.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            double totalSecond;
            double.TryParse(tb_seconds.Text, out totalSecond);
            TimeSpan ts = new TimeSpan((long)totalSecond * TimeSpan.TicksPerSecond);
            textBox_ts.Text = ts.ToString();
            DateTime oldDate = new DateTime(1970, 1, 1);
            DateTime newDate = oldDate.Add(ts);
            dateTimePicker1.Value = newDate;
        }

        private void radioBaidu_CheckedChanged(object sender, EventArgs e)
        {
            SetBaiduParam();
        }


    }
}