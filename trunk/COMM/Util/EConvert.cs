using System;
using System.Text;
using System.Text.RegularExpressions;



namespace CoalTrans.Util
{
    public static class EConvert
    {
        public static string ToString(object data)
        {
            if (null == data || data == DBNull.Value) return string.Empty;
            return data.ToString().Trim();
        }

        public static int ToInt(object data)
        {
            return ToInt(data, 0);
        }

        public static int ToInt(object data, int defaultValue)
        {
            if (data == null || data == DBNull.Value)
            {
                return defaultValue;
            }

            switch (data.GetType().Name)
            {
                case "Int16":
                case "Int32":
                    return Convert.ToInt32(data);
                case "Int64":
                    long long_data = (long)data;
                    if (long_data >= int.MinValue && long_data <= int.MaxValue)
                    {
                        return Convert.ToInt32(data);
                    }
                    else
                    {
                        return defaultValue;
                    }
                case "Single":
                    float float_data = (float)data;
                    if (float_data >= int.MinValue && float_data <= int.MaxValue)
                    {
                        return Convert.ToInt32(float_data);
                    }
                    else
                    {
                        return defaultValue;
                    }
                case "Double":
                    double double_data = (double)data;
                    if (double_data >= int.MinValue && double_data <= int.MaxValue)
                    {
                        return Convert.ToInt32(double_data);
                    }
                    else
                    {
                        return defaultValue;
                    }
                case "Decimal":
                    decimal decimal_data = (decimal)data;
                    if (decimal_data >= int.MinValue && decimal_data <= int.MaxValue)
                    {
                        return Convert.ToInt32(decimal_data);
                    }
                    else
                    {
                        return defaultValue;
                    }
            }

            if (Regex.IsMatch(data.ToString(), @"^\-?[12]?\d{1,9}$"))
            {
                return Convert.ToInt32(data);
            }
            else
            {
                return defaultValue;
            }
        }

        public static long ToLong(object data)
        {
            return ToInt64(data);
        }

        public static long ToInt64(object data)
        {
            if (data == null || data == DBNull.Value)
            {
                return 0;
            }

            switch (data.GetType().Name)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                    return Convert.ToInt64(data);
                case "Single":
                    float float_data = (float)data;
                    if (float_data >= long.MinValue && float_data <= long.MaxValue)
                    {
                        return Convert.ToInt64(float_data);
                    }
                    else
                    {
                        return 0;
                    }
                case "Double":
                    double double_data = (double)data;
                    if (double_data >= long.MinValue && double_data <= long.MaxValue)
                    {
                        return Convert.ToInt64(double_data);
                    }
                    else
                    {
                        return 0;
                    }
                case "Decimal":
                    decimal decimal_data = (decimal)data;
                    if (decimal_data >= long.MinValue && decimal_data <= long.MaxValue)
                    {
                        return Convert.ToInt64(decimal_data);
                    }
                    else
                    {
                        return 0;
                    }
            }

            if (Regex.IsMatch(data.ToString(), @"^\-?\d{1,20}$"))
            {
                return Convert.ToInt64(data);
            }
            else
            {
                return 0;
            }
        }

        public static byte ToByte(object data)
        {
            if (data == null || data == DBNull.Value)
            {
                return 0;
            }

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
            {
                return 0;
            }

            switch (data.GetType().Name)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Single":
                case "Decimal":
                    return Convert.ToSingle(data);
                case "Double":
                    double double_data = (double)data;
                    if (double_data >= float.MinValue && double_data <= float.MaxValue)
                    {
                        return Convert.ToSingle(double_data);
                    }
                    else
                    {
                        return 0;
                    }
            }

            if (Regex.IsMatch(data.ToString(), @"^\-?\d+(\.\d+)?$"))
            {
                return Convert.ToSingle(data);
            }
            else
            {
                return 0;
            }
        }

        public static double ToDouble(object data)
        {
            if (data == null || data == DBNull.Value)
            {
                return 0;
            }

            switch (data.GetType().Name)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Single":
                case "Double":
                case "Decimal":
                    return Convert.ToDouble(data);
            }

            if (Regex.IsMatch(data.ToString(), @"^\-?\d+(\.\d+)?$"))
            {
                return Convert.ToDouble(data);
            }
            else
            {
                return 0;
            }
        }

        public static DateTime ToDateTime(object data)
        {
            return ToDateTime(data, DateTime.MinValue);
        }

        public static DateTime ToDateTime(object data, DateTime defaultValue)
        {
            if (data == null || data == DBNull.Value)
                return defaultValue;

            if (data is DateTime)
            {
                return (DateTime)data;
            }

            try
            {
                return Convert.ToDateTime(data);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool ToBoolean(object data)
        {
            if (data == null || data == DBNull.Value)
            {
                return false;
            }

            switch (data.GetType().Name)
            {
                case "Boolean":
                case "Int16":
                case "Int32":
                case "Int64":
                case "Single":
                case "Double":
                case "Decimal":
                    return Convert.ToBoolean(data);
            }

            if (Regex.IsMatch(data.ToString(), @"^true$", RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 将对象转化为十进制数
        /// </summary>
        /// <param name="data">数据对象</param>
        /// <returns>成功：返回相应的十进制数；不能转化：返回0</returns>
        public static Decimal ToDecimal(object data)
        {
            return ToDecimal(data, 0);
        }


        /// <summary>
        /// 将对象转化为十进制数（带默认值）
        /// </summary>
        /// <param name="data">数据对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>成功：返回相应的十进制数；不能转化：返回默认值</returns>
        public static Decimal ToDecimal(object data, decimal defaultValue)
        {
            if (data == null || data == DBNull.Value)
            {
                return defaultValue;
            }

            switch (data.GetType().Name)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Decimal":
                    return Convert.ToDecimal(data);
                case "Single":
                    float float_data = (float)data;
                    if (float_data >= (float)Decimal.MinValue && float_data <= (float)Decimal.MaxValue)
                    {
                        return Convert.ToDecimal(float_data);
                    }
                    else
                    {
                        return defaultValue;
                    }
                case "Double":
                    double double_data = (double)data;
                    if (double_data >= (double)Decimal.MinValue && double_data <= (double)Decimal.MaxValue)
                    {
                        return Convert.ToDecimal(double_data);
                    }
                    else
                    {
                        return defaultValue;
                    }
            }

            if (Regex.IsMatch(data.ToString(), @"^\-?\d+(\.\d+)?$"))
            {
                return Convert.ToDecimal(data);
            }
            else
            {
                return defaultValue;
            }
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
