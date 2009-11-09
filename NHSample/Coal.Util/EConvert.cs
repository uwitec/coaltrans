using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Coal.Util
{
    public static class EConvert
    {
        private static readonly Regex INTEGER_REGEX = new Regex(@"^\-?\d{1,9}$",RegexOptions.Compiled);
        private static readonly Regex LONG_REGEX = new Regex(@"^\-?\d{1,18}$", RegexOptions.Compiled);
        private static readonly Regex FLOAT_REGEX = new Regex(@"^\-?\d+(\.\d+)?$", RegexOptions.Compiled);

        public static string ToString(object data, string def_value)
        {
            if (null == data) 
                return def_value;

            return Convert.ToString(data).Trim();
        }
        public static string ToString(object data)
        {
            return ToString(data, string.Empty);
        }

        public static int ToInt(object data,int def_value)
        {
            if (data == null || data==DBNull.Value) 
                return def_value;

            if (data is int) 
                return (int)data;

            if (INTEGER_REGEX.IsMatch(data.ToString()))
            {
                return Convert.ToInt32(data);
            }
            else
            {
                try
                {
                    return Convert.ToInt32(data);
                }
                catch
                {
                    return def_value; 
                }
            }
        }
        public static int ToInt(object data)
        {
            return ToInt(data, 0);
        }

        public static long ToLong(object data)
        {
            if (data == null || data == DBNull.Value)
                return 0L;

            if (data is long)
                return (long)data;

            if (LONG_REGEX.IsMatch(data.ToString()))
            {
                return Convert.ToInt64(data);
            }
            else
            {
                try
                {
                    return Convert.ToInt32(data);
                }
                catch
                {
                    return 0L;
                }
            }
        }

        public static DateTime ToDateTime(object data)
        {
            return ToDateTime(data, DateTime.MinValue);
        }
        public static DateTime ToDateTime(object data, DateTime def_value)
        {
            if (data == null || data == DBNull.Value) 
                return def_value;

            if (data is DateTime) 
                return (DateTime)data;

            try
            {
                return Convert.ToDateTime(data);
            }
            catch
            {
                return def_value;
            }
        }

        public static bool ToBoolean(object d)
        {
            return ToBoolean(d, false);
        }
        public static bool ToBoolean(object d, bool def_value)
        {
            if (d == null || d == DBNull.Value) 
                return def_value;

            if (d is bool) 
                return (bool)d;

            try
            {
                return Convert.ToBoolean(d);
            }
            catch
            {
                return def_value;
            }
        }

        public static byte ToByte(object data)
        {
            if (data == null || data == DBNull.Value) 
                return 0;

            if (data is byte) 
                return (byte)data;

            try
            {
                return Convert.ToByte(data);
            }
            catch
            {
                return 0;
            }
        }

        public static byte[] ToBinary(object data)
        {
            try
            {
                return (byte[])data;
            }
            catch
            {
                return null;
            }
        }
        public static float ToFloat(object data)
        {
            if (data == null || data == DBNull.Value) 
                return 0f;

            if (data is float)
                return (float)data;

            if (FLOAT_REGEX.IsMatch(data.ToString()))
            {
                return Convert.ToSingle(data);
            }
            else
            {
                return 0f;
            }
        }

        public static float ToFloat(object data,int digit)
        {
            return Convert.ToSingle(Math.Round(ToFloat(data), digit));
        }

        public static decimal ToDecimal(object data)
        {
            if (data == null || data == DBNull.Value)
                return 0;

            if (data is decimal)
                return (decimal)data;

            if (FLOAT_REGEX.IsMatch(data.ToString()))
            {
                return Convert.ToDecimal(data);
            }
            else
            {
                return 0;
            }
        }

        public static decimal ToDecimal(object data, int digit)
        {
            return Convert.ToDecimal(Math.Round(ToDecimal(data),digit));
        }

        public static string ToBase64(string strnormal)
        {
            try
            {
                return Convert.ToBase64String(Encoding.Default.GetBytes(strnormal));
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string FromBase64(string strbase64)
        {
            try
            {
                return Encoding.Default.GetString(Convert.FromBase64String(strbase64));
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}