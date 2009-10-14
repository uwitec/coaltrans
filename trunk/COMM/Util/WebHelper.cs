using System.IO;
using System.Net;
using System.Text;
namespace CoalTrans.Util
{
    public static class WebHelper
    {
        public static string GetPageHTML(string url)
        {
            return GetPageHTML(url, Encoding.Default);
        }

        public static string GetPageHTML(string url,Encoding encoding)
        {
            Stream stream = null;
            StreamReader sr = null;

            try
            {
                stream = WebRequest.Create(url).GetResponse().GetResponseStream();
                sr = new StreamReader(stream, encoding);
                return sr.ReadToEnd();
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }

                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
        }

        public static string GetPageHTML(string url, string send_data, Encoding encoding)
        {
            Stream stream = null;
            StreamReader sr = null;

            try
            {
                WebRequest req = WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                /*************************/
                //send_data = HttpUtility.UrlEncode( send_data, encoding );
                byte[] send_data_bytes = encoding.GetBytes(send_data);
                req.ContentLength = send_data_bytes.Length;
                Stream newStream = req.GetRequestStream();
                newStream.Write(send_data_bytes, 0, send_data_bytes.Length);
                newStream.Close();
                /*************************/
                stream = req.GetResponse().GetResponseStream();
                sr = new StreamReader(stream, encoding);
                return sr.ReadToEnd();
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }

                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }
        }
    }
}
