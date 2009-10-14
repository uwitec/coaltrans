using System;
using System.IO;
using System.Text;
using System.IO.Compression;

namespace CoalTrans.Util
{
    public static class ZipHelper
    {
        public static string Zip(string tozipstr)
        {
            MemoryStream mStream = new MemoryStream();
            GZipStream gStream = new GZipStream(mStream, CompressionMode.Compress);

            BinaryWriter bw = new BinaryWriter(gStream);
            bw.Write(Encoding.UTF8.GetBytes(tozipstr));
            bw.Close();

            gStream.Close();
            string outs = Convert.ToBase64String(mStream.ToArray());
            mStream.Close();
            return outs;
        }


        public static string UnZip(string zipedstr)
        {
            byte[] data = Convert.FromBase64String(zipedstr);
            MemoryStream mStream = new MemoryStream(data);
            GZipStream gStream = new GZipStream(mStream, CompressionMode.Decompress);
            StreamReader streamR = new StreamReader(gStream);
            string outs = streamR.ReadToEnd();
            mStream.Close();
            gStream.Close();
            streamR.Close();
            return outs;
        }
    }
}