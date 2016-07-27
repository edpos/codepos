using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace iTanec.eCom.Common.General
{
    public static class Utilities
    {

        public static string RemoveIllegalCharacterAndWhiteSpace(string val)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex regx = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            val = regx.Replace(val, "");
            val = Regex.Replace(val, @"[^0-9a-zA-Z]+", "");
            var newstr = val.Replace(" ", ""); //String.Join("", FileName.Where(c => !char.IsWhiteSpace(c)));
            return newstr.ToString();
        }

        public static string RemoveillegalCharacterFromFile(string FileName)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex regx = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            FileName = regx.Replace(FileName, "");
            FileName = Regex.Replace(FileName, @"[^0-9a-zA-Z]+", "");
            var newstr = FileName.Replace(' ', '_'); //String.Join("", FileName.Where(c => !char.IsWhiteSpace(c)));
            return newstr.ToString();
        }


        public static string GetValidFileName(string filePath)
        {
            char[] invalids = Path.GetInvalidFileNameChars();
            return string.Join("_", filePath.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
        }
        public static int GetAppSettingInt(string key)
        {
            AppSettingsReader reader = new AppSettingsReader();
            string AppID = reader.GetValue(key, typeof(string)).ToString();
            int applicationID = Convert.ToInt32(AppID);
            return applicationID;
        }
        /// <summary>
        /// Calculate Total Pages
        /// </summary>
        /// <param name="numberOfRecords"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static int CalculateTotalPages(long numberOfRecords, Int32 pageSize)
        {
            long result;
            int totalPages;

            Math.DivRem(numberOfRecords, pageSize, out result);

            if (result > 0)
                totalPages = (int)((numberOfRecords / pageSize)) + 1;
            else
                totalPages = (int)(numberOfRecords / pageSize);

            return totalPages;

        }

        /// <summary>
        /// Check if date is a valid format
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static Boolean IsDate(string date)
        {
            DateTime dateTime;
            return DateTime.TryParse(date, out dateTime);
        }

        /// <summary>
        /// IsNumeric
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Boolean IsNumeric(object entity)
        {
            if (entity == null) return false;

            int result;
            return int.TryParse(entity.ToString(), out result);
        }

        /// <summary>
        /// IsDouble
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Boolean IsDouble(object entity)
        {
            if (entity == null) return false;

            string e = entity.ToString();

            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = e.IndexOf(".", i)) != -1)
            {
                i += ".".Length;
                count++;
            }
            if (count > 1) return false;

            e = e.Replace(".", "");

            int result;
            return int.TryParse(e, out result);
        }

        public static List<string> Message(string message)
        {
            List<string> returnMessage = new List<string>();
            returnMessage.Add(message);
            return returnMessage;
        }

        public static string RemoveSpecialCharacters(string str)
        {
            if (str == null) return string.Empty;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9') || (str[i] >= 'A' && str[i] <= 'z' || (str[i] == '.' || str[i] == '_')))
                    sb.Append(str[i]);
            }

            return sb.ToString();
        }

         #region "Private constructor"
        
        #endregion

        #region "Data validation"
        public static bool isValidTime(string time)
        {
            TimeSpan ts = TimeSpan.FromTicks(0);
            string s = time;
            bool result = false;
            DateTime t = DateTime.Now;
            result = DateTime.TryParseExact(s, "hh:mm tt", null, System.Globalization.DateTimeStyles.None, out t);
            return result;
        }
        /// <summary>
        /// Checks if the object passed is null or empty.
        /// </summary>
        /// <returns>True if has value, otherwise false.</returns>
        public static bool HasValue(object value)
        {
            if ((value != null) && value != DBNull.Value && !string.IsNullOrWhiteSpace(value.ToString()))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Checks if the DataTable passed is null or empty.
        /// </summary>
        /// <returns>True if has value, otherwise false.</returns>
        public static bool HasValue(DataTable table)
        {
            if ((table != null) && table.Rows.Count > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Checks if the Dataset passed is null or empty.
        /// </summary>
        /// <returns>True if has value, otherwise false.</returns>
        public static bool HasValue(DataSet dataSet)
        {
            if ((dataSet != null) && dataSet.Tables.Count > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Checks if the passed value is a valid integer.
        /// </summary>
        /// <returns>True if a valid Int32, otherwise false.</returns>


        /// <summary>
        /// Checks if the passed value is a valid integer, with a variable to bind (ByRef).
        /// </summary>
        /// <returns>True if a valid Int32, otherwise false.</returns>
        public static bool IsNumeric(string value, ref int intReturn)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            else
            {
                try
                {
                    intReturn = Convert.ToInt32(value);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Checks if the value passed is True or False.
        /// </summary>
        /// <returns>True if the value is 1, TRUE, YES, ON. False for 0, FALSE, NO, OFF. Otherwise throws an InvalidOperationException.</returns>
        public static bool TrueOrFalse(object value)
        {
            if (!HasValue(value))
                return false;
            switch (value.ToString().Trim().ToUpper())
            {
                case "1":
                case "TRUE":
                case "YES":
                case "ON":
                case "ENABLE":
                    return true;
                case "0":
                case "FALSE":
                case "NO":
                case "OFF":
                case "DISABLE":
                    return false;
                default:
                    throw new InvalidOperationException(value.ToString());
            }
        }
        #endregion

        #region "Data parsing and conversion"
        public static DataView GetView(DataSet DS)
        {
            DataView dv = null;
            if (HasValue(DS))
            {
                if (DS.Tables.Count > 0)
                {
                    if (DS.Tables[0].Rows.Count > 0)
                        dv = DS.Tables[0].DefaultView;
                }
            }
            return dv;
        }

       

        public static void CopyPropertyValues(object source, object destination)
        {
            var destProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in source.GetType().GetProperties())
            {
                foreach (var destProperty in destProperties)
                {
                    if (destProperty.Name == sourceProperty.Name &&
                destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        destProperty.SetValue(destination, sourceProperty.GetValue(
                            source, new object[] { }), new object[] { });

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the passed value as seconds (for example 1m 10s should be 70).
        /// </summary>
        /// <returns>The value in seconds, as Int32.</returns>
       

        /// <summary>
        /// Returns time in the format 00:00, where : is replaced by the specified separator.
        /// </summary>
        /// <returns>The time value, as String.</returns>
        public static string TimespanToTime(TimeSpan value, string separator)
        {
            return value.Hours.ToString("00") + separator + value.Minutes.ToString("00");
        }

        /// <summary>
        /// Returns a string using the RFC822 format, representing the passed DateTime.
        /// </summary>
        /// <returns>Date in RFC-822 format.</returns>
        public static string GetDateRfc822(DateTime value)
        {
            int offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;
            string zone = "+" + offset.ToString().PadLeft(2, '0');

            if (offset < 0)
            {
                int i = offset * -1;
                zone = "-" + i.ToString().PadLeft(2, '0');
            }
            return value.ToString("ddd, dd MMM yyyy HH:mm:ss " + zone.PadRight(5, '0'));
        }


        /// <summary>
        /// Parses the value using the RFC822 format and returns as DateTime.
        /// </summary>
        /// <returns>Parsed value as DateTime.</returns>
        public static DateTime ParseDateRfc822(string value)
        {
            if (string.IsNullOrEmpty(value))
                return DateTime.MinValue;
            DateTime dt = default(DateTime);
            int pos = value.LastIndexOf(" ");
            try
            {
                dt = Convert.ToDateTime(value);

                if (value.Substring(pos + 1) == "Z")
                    dt = dt.ToUniversalTime();
                else if (value.Substring(pos + 1) == "GMT")
                    dt = dt.ToUniversalTime();
                return dt;
            }
            catch
            {
            }

            dt = Convert.ToDateTime(value.Substring(0, pos));

            if (value[pos + 1] == '+')
            {
                int h = Convert.ToInt32(value.Substring(pos + 2, 2));
                dt = dt.AddHours(-h);
                int m = Convert.ToInt32(value.Substring(pos + 4, 2));
                dt = dt.AddMinutes(-m);
            }
            else if (value[pos + 1] == '-')
            {
                int h = Convert.ToInt32(value.Substring(pos + 2, 2));
                dt = dt.AddHours(h);
                int m = Convert.ToInt32(value.Substring(pos + 4, 2));
                dt = dt.AddMinutes(m);
            }
            else if (value.Substring(pos + 1) == "A")
                dt = dt.AddHours(1);
            else if (value.Substring(pos + 1) == "B")
                dt = dt.AddHours(2);
            else if (value.Substring(pos + 1) == "C")
                dt = dt.AddHours(3);
            else if (value.Substring(pos + 1) == "D")
                dt = dt.AddHours(4);
            else if (value.Substring(pos + 1) == "E")
                dt = dt.AddHours(5);
            else if (value.Substring(pos + 1) == "F")
                dt = dt.AddHours(6);
            else if (value.Substring(pos + 1) == "G")
                dt = dt.AddHours(7);
            else if (value.Substring(pos + 1) == "H")
                dt = dt.AddHours(8);
            else if (value.Substring(pos + 1) == "I")
                dt = dt.AddHours(9);
            else if (value.Substring(pos + 1) == "K")
                dt = dt.AddHours(10);
            else if (value.Substring(pos + 1) == "L")
                dt = dt.AddHours(11);
            else if (value.Substring(pos + 1) == "M")
                dt = dt.AddHours(12);
            else if (value.Substring(pos + 1) == "N")
                dt = dt.AddHours(-1);
            else if (value.Substring(pos + 1) == "O")
                dt = dt.AddHours(-2);
            else if (value.Substring(pos + 1) == "P")
                dt = dt.AddHours(-3);
            else if (value.Substring(pos + 1) == "Q")
            {
                dt = dt.AddHours(-4);
            }
            else if (value.Substring(pos + 1) == "R")
            {
                dt = dt.AddHours(-5);
            }
            else if (value.Substring(pos + 1) == "S")
            {
                dt = dt.AddHours(-6);
            }
            else if (value.Substring(pos + 1) == "T")
            {
                dt = dt.AddHours(-7);
            }
            else if (value.Substring(pos + 1) == "U")
            {
                dt = dt.AddHours(-8);
            }
            else if (value.Substring(pos + 1) == "V")
            {
                dt = dt.AddHours(-9);
            }
            else if (value.Substring(pos + 1) == "W")
            {
                dt = dt.AddHours(-10);
            }
            else if (value.Substring(pos + 1) == "X")
            {
                dt = dt.AddHours(-11);
            }
            else if (value.Substring(pos + 1) == "Y")
            {
                dt = dt.AddHours(-12);
            }
            else if (value.Substring(pos + 1) == "EST")
            {
                dt = dt.AddHours(5);
            }
            else if (value.Substring(pos + 1) == "EDT")
            {
                dt = dt.AddHours(4);
            }
            else if (value.Substring(pos + 1) == "CST")
            {
                dt = dt.AddHours(6);
            }
            else if (value.Substring(pos + 1) == "CDT")
            {
                dt = dt.AddHours(5);
            }
            else if (value.Substring(pos + 1) == "MST")
            {
                dt = dt.AddHours(7);
            }
            else if (value.Substring(pos + 1) == "MDT")
            {
                dt = dt.AddHours(6);
            }
            else if (value.Substring(pos + 1) == "PST")
            {
                dt = dt.AddHours(8);
            }
            else if (value.Substring(pos + 1) == "PDT")
            {
                dt = dt.AddHours(7);
            }

            return dt;

        }

        /// <summary>
        /// Returns the days difference between two dates.
        /// </summary>
        /// <returns>Integer (days).</returns>
        public static int DateDiff(DateTime date1, DateTime date2)
        {
            return DateDiff(date1, date2, "days");
        }

        /// <summary>
        /// Returns the specific datepart difference between two dates (default datepart is days)
        /// </summary>
        /// <returns>Integer (years, months, days, minutes or seconds).</returns>
        public static int DateDiff(DateTime date1, DateTime date2, string datePart)
        {
            TimeSpan ts = date1 - date2;
            switch (datePart)
            {
                case "year":
                case "yyyy":
                case "yy":
                case "y":
                    return ts.Days / 365;
                case "month":
                case "mon":
                case "mo":
                    return ts.Days / 30;
                case "day":
                case "dd":
                case "d":
                    return ts.Days;
                case "hour":
                case "hh":
                case "h":
                    return ts.Hours;
                case "minute":
                case "min":
                case "m":
                    return ts.Minutes;
                case "second":
                case "sec":
                case "s":
                    return ts.Seconds;
            }
            return ts.Days;
        }

        /// <summary>
        /// Compare 2 strings and return the similarity from 0 to 100%, using the Levenshtein algorithm
        /// </summary>
        /// <returns>Integer (similarity from 0 to 100).</returns>
        public static int StringSimilarity(string a, string b)
        {
            if (string.IsNullOrEmpty(b) | string.IsNullOrEmpty(b))
                return 0;
            if (a == b)
                return 100;

            Int32 cost = default(Int32);
            Int32[,] d = new int[a.Length + 1, b.Length + 1];
            Int32 min1 = default(Int32);
            Int32 min2 = default(Int32);
            Int32 min3 = default(Int32);

            for (int i = 0; i <= d.GetUpperBound(0); i++)
            {
                d[i, 0] = i;
            }

            for (Int32 i = 0; i <= d.GetUpperBound(1); i++)
            {
                d[0, i] = i;
            }
            for (Int32 i = 1; i <= d.GetUpperBound(0); i++)
            {

                for (Int32 j = 1; j <= d.GetUpperBound(1); j++)
                {
                    cost = Convert.ToInt32(!(a[i - 1] == b[j - 1]));

                    min1 = d[i - 1, j] + 1;
                    min2 = d[i, j - 1] + 1;
                    min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }

            int result = d[d.GetUpperBound(0), d.GetUpperBound(1)];
            int length = a.Length;

            if (b.Length > length)
                length = b.Length;

            result = Convert.ToInt32(Math.Abs((1 - result / length) * 100));
            return result;
        }

        /// <summary>
        /// Returns the capitalized string (first letter uppercased).
        /// </summary>
        /// <returns>Capitalized string.</returns>
        public static string Capitalize(string value)
        {
            if (!string.IsNullOrEmpty(value))
                return value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
            return string.Empty;
        }
        #endregion

        #region "Data conversion"
        /// <summary>
        /// Converts the passed String to UT8ByteArray.
        /// </summary>
        /// <returns>Converted String as UT8ByteArray.</returns>
        public static byte[] StringToUTF8ByteArray(string value)
        {
            return new UTF8Encoding().GetBytes(value);
        }

        /// <summary>
        /// Convert the passed UT8ByteArray to String.
        /// </summary>
        /// <returns>Converted UT8ByteArray as String.</returns>
        public static string UTF8ByteArrayToString(byte[] value)
        {
            return new UTF8Encoding().GetString(value);
        }

        public static TimeSpan GetTimeFromString(string time)
        {
            TimeSpan ts = TimeSpan.FromTicks(0);
            try
            {
                string s = time;
                DateTime t = DateTime.ParseExact(s, "hh:mm tt", null);
                ts = t.TimeOfDay;
            }
            catch (Exception ex)
            {
            }
            return ts;
        }

        public static string GetFormattedTimeString(string timeString)
        {
            DateTime t = DateTime.ParseExact(timeString, "HH:mm:ss", null);
            return t.ToString("hh:mm tt");
        }
        #endregion

        #region "Get data as types"

        /// <summary>
        /// Return the passed object as String.
        /// </summary>
        /// <returns>Object converted to String.</returns>
        public static string GetStringTrim(object value)
        {
            if (value == null)
                return string.Empty;
            else
                return value.ToString().Trim();
        }

        public static string GetString(object value)
        {
            if (value == null)
                return string.Empty;
            else
                return value.ToString();
        }

        /// <summary>
        /// Return the passed object as Int32.
        /// </summary>
        /// <returns>Object converted to Int32.</returns>
        public static int GetInt32(object value)
        {
            if (!HasValue(value))
                return 0;
            else
                return Convert.ToInt32(value);
        }

        /// <summary>
        /// Return the passed object as Int32.
        /// </summary>
        /// <returns>Object converted to Int32.</returns>
        public static decimal GetDecimal(object value)
        {
            if (!HasValue(value))
                return 0;
            else
                return Convert.ToDecimal(value);
        }

        /// <summary>
        /// Return the passed object as Int32.
        /// </summary>
        /// <returns>Object converted to Int32.</returns>
        public static int GetInt32Negative(object value)
        {
            if (!HasValue(value))
                return -1;
            else
                return Convert.ToInt32(value);
        }

        /// <summary>
        /// Return the passed object as Double.
        /// </summary>
        /// <returns>Object converted to Double.</returns>
        public static double GetDouble(object value)
        {
            if (value == null)
                return double.MinValue;
            else
                return Convert.ToDouble(value);
        }

        /// <summary>
        /// Return the passed object as Single.
        /// </summary>
        /// <returns>Object converted to Single.</returns>
        public static float GetSingle(object value)
        {
            if (value == null)
                return float.MinValue;
            else
                return Convert.ToSingle(value);
        }

        /// <summary>
        /// Return the passed object as Boolean.
        /// </summary>
        /// <returns>Object converted to Boolean.</returns>
        public static bool GetBoolean(object value)
        {
            if (value == null)
                return false;
            else
            {
                string r = value.ToString();
                if (string.IsNullOrEmpty(r))
                    return false;
                else
                {
                    r = r.ToLower();
                    return (r == "1" || r == "true" || r == "yes");
                }
            }
        }
        /// <summary>
        /// To get custom date format and return only the format
        /// </summary>
        /// <param name="shortDate">True/False</param>
        /// <returns></returns>
        public static string GetCustomDateFormat(bool shortDate)
        {
            if (shortDate)
                return DateTimeFormatInfo.GetInstance((new CultureInfo("en-US")).DateTimeFormat).ShortDatePattern = "MM/dd/yyyy";
            else
                return DateTimeFormatInfo.GetInstance((new CultureInfo("en-US")).DateTimeFormat).LongDatePattern = "dddd, MMMM d, yyyy";
        }
        /// <summary>
        /// To get custom time format and return only the format
        /// </summary>
        /// <param name="shortTime">True/False</param>
        /// <returns></returns>
        public static string GetCustomTimeFormat(bool shortTime)
        {
            if (shortTime)
                return DateTimeFormatInfo.GetInstance((new CultureInfo("en-US")).DateTimeFormat).ShortTimePattern = "hh:mm tt";
            else
                return DateTimeFormatInfo.GetInstance((new CultureInfo("en-US")).DateTimeFormat).LongTimePattern = "hh:mm:ss tt";
        }
        
        /// <summary>
        /// Return the passed object as DateTime.
        /// </summary>
        /// <returns>Object converted to DateTime.</returns>
        public static DateTime GetDateTime(object value)
        {
            if (!HasValue(value))
                return DateTime.MinValue;
            else
                return Convert.ToDateTime(value);
        }

        public static DateTime GetDateTimeParse(object value)
        {
            if (!HasValue(value))
                return DateTime.MinValue;
            else
            {
                string str = Utilities.GetString(value);
                string[] format = { "yyyyMMdd" };
                DateTime date;

                DateTime.TryParseExact(str,
                                          format,
                                          System.Globalization.CultureInfo.InvariantCulture,
                                          System.Globalization.DateTimeStyles.None,
                                          out date);
                return date;
            }
                
        }


        public static TimeSpan Convert12HourTOTimeSpan(string value)
        {
            var retTime = new TimeSpan();
            // formatting String 
            string timePart = "12:00", amPmPart = " AM";
            try
            {
                if (value.Length > 5)
                    timePart = value.Substring(0, 5);
            }
            catch
            {
                timePart = "12:00";
            }

            try
            {
                string sAmPm = value.Substring(5, (value.Length - 5));

                if (new[] { "A", "AM", "a", "am" }.Contains(sAmPm.Trim()))
                    amPmPart = " AM";
                else
                    amPmPart = " PM";
            }
            catch
            {
                amPmPart = "AM";
            }
            // Parsing to Time Span
            try
            {
                retTime = TimeSpan.Parse(timePart);
                var currHours = retTime.Hours;
                if (amPmPart.Trim() == "PM")
                {

                    int IncrementHours = 0;
                    if (currHours <= 11)
                        IncrementHours = 12;
                    else
                        IncrementHours = 0;
                    retTime = retTime.Add(new TimeSpan(IncrementHours, 0, 0));
                }
                else if (amPmPart.Trim() == "AM")
                {
                    if (currHours == 12)
                        retTime = retTime.Add(new TimeSpan(-12, 0, 0));
                }
            }
            catch { }
            // return Time Span
            return retTime;
        }

        public static string Convert24HourTimespanToString(TimeSpan ts)
        {
            var dateTime = new DateTime(ts.Ticks);
            var formattedTime = dateTime.ToString("h:mm tt", System.Globalization.CultureInfo.InvariantCulture);

            return formattedTime;
        }
        #endregion

        /// <summary>
        /// Gets a DateTime representing the first day in the current month
        /// </summary>
        /// <param name="current">The current date</param>
        /// <returns></returns>
        public static DateTime MonthFirstDay(DateTime current)
        {
            DateTime first = current.AddDays(1 - current.Day);
            return first;
        }

        /// <summary>
        /// Gets a DateTime representing the last day in the current month
        /// </summary>
        /// <param name="current">The current date</param>
        /// <returns></returns>
        public static DateTime MonthLastDay(DateTime current)
        {
            int daysInMonth = DateTime.DaysInMonth(current.Year, current.Month);

            DateTime last = MonthFirstDay(DateTime.Now).AddDays(daysInMonth - 1);
            return last;
        }
        /// <summary>
        /// To get the word the last character
        /// </summary>
        /// <param name="source"></param>
        /// <param name="tail_length"></param>
        /// <returns></returns>
        public static string GetLast(string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
    }

}
