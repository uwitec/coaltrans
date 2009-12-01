<%@ WebHandler Language="C#" Class="ValidCodeGenerator" %>

using System;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

public class ValidCodeGenerator : IHttpHandler 
{

    public void ProcessRequest(HttpContext context)
    {
        GenerateVerifyImage(context);
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
    }

    /// <summary>
    /// 生成图片验证码
    /// </summary>
    /// <param name="nLen">验证码的长度</param>
    /// <param name="strKey">输出参数，验证码的内容</param>
    /// <returns>图片字节流</returns>
    public void GenerateVerifyImage(HttpContext context)
    {
        int nLen = 5;
        int nBmpWidth = 13 * nLen + 5;
        int nBmpHeight = 25;
        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(nBmpWidth, nBmpHeight);

        // 1. 生成随机背景颜色
        int nRed, nGreen, nBlue;  // 背景的三元色
        System.Random rd = new Random((int)System.DateTime.Now.Ticks);
        nRed = rd.Next(255) % 128 + 128;
        nGreen = rd.Next(255) % 128 + 128;
        nBlue = rd.Next(255) % 128 + 128;

        // 2. 填充位图背景
        System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(bmp);
        graph.FillRectangle(new SolidBrush(System.Drawing.Color.FromArgb(nRed, nGreen, nBlue))
         , 0
         , 0
         , nBmpWidth
         , nBmpHeight);


        // 3. 绘制干扰线条，采用比背景略深一些的颜色
        int nLines = 3;
        System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(nRed - 17, nGreen - 17, nBlue - 17), 2);
        for (int a = 0; a < nLines; a++)
        {
            int x1 = rd.Next() % nBmpWidth;
            int y1 = rd.Next() % nBmpHeight;
            int x2 = rd.Next() % nBmpWidth;
            int y2 = rd.Next() % nBmpHeight;
            graph.DrawLine(pen, x1, y1, x2, y2);
        }

        // 采用的字符集，可以随即拓展，并可以控制字符出现的几率
        string strCode = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // 4. 循环取得字符，并绘制
        string strResult = "";
        for (int i = 0; i < nLen; i++)
        {
            int x = (i * 13 + rd.Next(3));
            int y = rd.Next(4) + 1;

            // 确定字体
            System.Drawing.Font font = new System.Drawing.Font("Courier New",
             12 + rd.Next() % 4,
             System.Drawing.FontStyle.Bold);
            char c = strCode[rd.Next(strCode.Length)];  // 随机获取字符
            strResult += c.ToString();

            // 绘制字符
            graph.DrawString(c.ToString(),
             font,
             new SolidBrush(System.Drawing.Color.FromArgb(nRed - 60 + y * 3, nGreen - 60 + y * 3, nBlue - 40 + y * 3)),
             x,
             y);
        }

        if (context.Request.Cookies["valid_code"] != null)
        {
            context.Request.Cookies["valid_code"].Expires = DateTime.Now.AddDays(-1);
        }
        context.Response.Cookies.Add(new HttpCookie("valid_code", strResult));

        using (MemoryStream ms = new MemoryStream())
        {
            bmp.Save(ms, ImageFormat.Gif);//将图片保存到指定流
            context.Response.ClearContent();//清楚缓冲区的流
            context.Response.ContentType = "imge.Gif";//配置输出类型
            context.Response.BinaryWrite(ms.ToArray());//输出内容 
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}