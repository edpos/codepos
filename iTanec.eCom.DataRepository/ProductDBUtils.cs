using iTanec.eCom.BusinessObjects;
using iTanec.eCom.Common.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iTanec.eCom.DataRepository
{
    public class ProductDBUtils
    {
        public static List<SqlParameter> CreateParameter<T>(object item, bool IgnoreEmpty)
        {
            if (item != null)
            {
                Type entityType = typeof(T);
                List<SqlParameter> param = new List<SqlParameter>();
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
                SqlParameter parameter = null;
                foreach (PropertyDescriptor prop in properties)
                {
                    if (!IgnoreEmpty)
                    {
                        if (prop.GetValue(item) != null && (prop.GetValue(item).ToString() == "1/1/0001 12:00:00 AM" || prop.GetValue(item).ToString() == "01-01-0001 12:00:00"))
                        {
                            parameter = new SqlParameter("@" + prop.Name, DBNull.Value);
                            parameter.SourceVersion = System.Data.DataRowVersion.Original;
                            param.Add(parameter);

                        }
                        else if (prop.GetValue(item) == null)
                            param.Add(new SqlParameter("@" + prop.Name, DBNull.Value));
                        else
                        {
                            parameter = new SqlParameter("@" + prop.Name, prop.GetValue(item));
                            parameter.SourceVersion = System.Data.DataRowVersion.Original;
                            param.Add(parameter);
                        }
                    }
                    else if (prop.GetValue(item) != null)
                    {
                        if (prop.GetValue(item).ToString() != "1/1/0001 12:00:00 AM")
                            param.Add(new SqlParameter("@" + prop.Name, prop.GetValue(item)));
                    }
                }
                return param;
            }
            else
            {
                return null;
            }
        }

        public static List<T> CreateList<T>(DataTable table)
        {
            List<T> list = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(CreateItem<T>(row));
            }
            return list;
        }
        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            Type entityType = typeof(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
                DateTime dt = new DateTime();
                foreach (PropertyDescriptor prop in properties)
                {
                    PropertyInfo propInfo = obj.GetType().GetProperty(prop.Name);
                    try
                    {
                        object value = DBNull.Value;
                        foreach (DataColumn column in row.Table.Columns)
                        {
                            if (ConvertToTitleCase(column.ColumnName).ToLower().Equals(prop.Name.ToLower()))
                            {
                                value = row[column.ColumnName];
                                break;
                            }
                            //DEPRECATED
                            //else if (column.ColumnName.ToLower().Equals(prop.Name.ToLower()))
                            //{
                            //    value = row[column.ColumnName];
                            //    break;
                            //}
                        }
                        if (value != DBNull.Value)
                        {
                            if (prop.PropertyType.FullName.Equals("System.String"))
                            {
                                propInfo.SetValue(obj, value.ToString().Trim(), null);
                            }
                            else if (prop.PropertyType.FullName.Equals("System.Boolean"))
                            {
                                if (Utilities.GetBoolean(value))
                                    propInfo.SetValue(obj, true, null);
                                else
                                    propInfo.SetValue(obj, false, null);
                            }
                            else if (prop.PropertyType.FullName.Equals("System.Single"))//Float
                            {
                                value = Utilities.GetSingle(value);
                                propInfo.SetValue(obj, value, null);
                            }
                            else if (prop.PropertyType.FullName.Equals("System.Decimal"))
                            {
                                value = Utilities.GetDecimal(value);
                                propInfo.SetValue(obj, value, null);
                            }
                            else if (prop.PropertyType.FullName.Equals("System.DateTime"))
                            {
                                if (value.Equals("1/1/0001 12:00:00 AM"))
                                    propInfo.SetValue(obj, null, null);
                                else
                                {
                                    dt = DateTime.Parse(value.ToString());
                                    propInfo.SetValue(obj, dt, null);
                                }
                            }
                            else if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
                            {
                                value = Convert.ChangeType(value, Nullable.GetUnderlyingType(prop.PropertyType));
                                propInfo.SetValue(obj, value, null);
                            }
                            else if (prop.PropertyType.FullName.Equals("System.Char"))
                            {
                                propInfo.SetValue(obj, Convert.ChangeType(value, Type.GetType("System.Char")));
                            }
                            else
                                propInfo.SetValue(obj, value, null);
                        }
                        else
                        {
                            if (prop.PropertyType.FullName.Equals("System.DateTime"))
                            {
                                propInfo.SetValue(obj, DateTime.MinValue, null);
                            }
                        }
                    }
                    catch (IndexOutOfRangeException outof)
                    {
                        // You can log something here
                    }
                    catch (Exception ex)
                    {
                        // You can log something here
                    }
                }
            }
            return obj;
        }

        public static T CreateItem<T>(IDataReader row)
        {
            T obj = default(T);
            Type entityType = typeof(T);

            if (row != null)
            {
                obj = Activator.CreateInstance<T>();
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
                DateTime dt = new DateTime();
                foreach (PropertyDescriptor prop in properties)
                {
                    PropertyInfo propInfo = obj.GetType().GetProperty(prop.Name);
                    try
                    {
                        if (row[prop.Name] != System.DBNull.Value)
                        {
                            object value = row[prop.Name];
                            if (prop.PropertyType.FullName.Equals("System.Boolean"))
                            {
                                if (Convert.ToBoolean(value))
                                    propInfo.SetValue(obj, true, null);
                                else
                                    propInfo.SetValue(obj, false, null);
                            }
                            else if (prop.PropertyType.FullName.Equals("System.Single"))
                            {
                                value = Utilities.GetSingle(value);
                                propInfo.SetValue(obj, value, null);
                            }
                            else if (prop.PropertyType.FullName.Equals("System.Decimal"))
                            {
                                value = Utilities.GetDecimal(value);
                                propInfo.SetValue(obj, value, null);
                            }
                            else if (prop.PropertyType.FullName.Equals("System.DateTime"))
                            {
                                if (value.Equals("1/1/0001 12:00:00 AM"))
                                    propInfo.SetValue(obj, null, null);
                                else
                                {
                                    dt = DateTime.Parse(value.ToString());
                                    propInfo.SetValue(obj, dt, null);
                                }
                            }
                            else if (prop.PropertyType.FullName.Equals("System.String"))
                            {
                                propInfo.SetValue(obj, value.ToString().Trim(), null);
                            }
                            else
                                propInfo.SetValue(obj, value, null);
                        }
                        else
                        {
                            if (prop.PropertyType.FullName.Equals("System.DateTime"))
                            {
                                propInfo.SetValue(obj, DateTime.MinValue, null);
                            }
                        }
                    }
                    catch (IndexOutOfRangeException outof)
                    {

                    }
                    catch (Exception ex)
                    {
                        // You can log something here
                    }
                }
            }
            return obj;
        }

        public static SqlParameter CreateParameter(string paramName, object paramValue)
        {
            SqlParameter para = new SqlParameter("@" + paramName, paramValue);
            if (paramValue != null)
            {
                if (string.IsNullOrEmpty(Convert.ToString(para.Value)) || paramValue.Equals(-1))
                {
                    para.Value = DBNull.Value;
                    para.Size = 80;
                }
            }
            string result = Convert.ToString(paramValue);
            if (string.IsNullOrEmpty(result))
            {
                para.Value = DBNull.Value;
            }
            return para;
        }

        public static SqlParameter CreateParameter(string paramName, object paramValue, ParameterDirection paramDirection = ParameterDirection.Input)
        {
            SqlParameter para = new SqlParameter("@" + paramName, paramValue);
            para.Direction = paramDirection;
            return para;
        }

        public static SqlParameter CreateParameter(string paramName, object paramValue, int paramSize, ParameterDirection paramDirection = ParameterDirection.Input)
        {
            SqlParameter para = new SqlParameter("@" + paramName, paramValue);
            para.Direction = paramDirection;
            para.Size = paramSize;
            return para;
        }

        public static SqlParameter CreateParameter(string paramName, object paramValue, DbType dbType, ParameterDirection paramDirection = ParameterDirection.Input)
        {
            SqlParameter para = new SqlParameter("@" + paramName, paramValue);
            para.Direction = paramDirection;
            para.DbType = dbType;
            return para;
        }
        public static SqlParameter CreateParameter(string paramName, object paramValue, SqlDbType dbType, ParameterDirection paramDirection = ParameterDirection.Input)
        {
            SqlParameter para = new SqlParameter("@" + paramName, paramValue);
            para.Direction = paramDirection;
            para.SqlDbType = dbType;
            return para;
        }

        public static DataTable ConvertTo<T>(T[] list)
        {
            DataTable table = CreateTable<T>();

            Type entityType = typeof(T);

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);

            DataTable table = new DataTable(entityType.Name);

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            return table;
        }

        public static object ConvertInvalidSeqIDsToDBNull(int seqID)
        {
            object returnValue = DBNull.Value;

            if (IsValidSeqID(seqID))
            {
                returnValue = seqID;
            }
            return returnValue;
        }
        public static object ConvertInvalidSeqIDsToDBNull(int? seqID)
        {
            object returnValue = DBNull.Value;

            if (IsValidSeqID(seqID))
            {
                returnValue = seqID;
            }
            return returnValue;
        }

        public static object ConvertInvalidSeqIDsToDBNull(Int64 seqID)
        {
            object returnValue = DBNull.Value;

            if (IsValidSeqID(seqID))
            {
                returnValue = seqID;
            }
            return returnValue;
        }

        public static object ConvertInvalidSeqIDsToDBNull(Int64? seqID)
        {
            object returnValue = DBNull.Value;
            if (IsValidSeqID(seqID))
            {
                returnValue = seqID;
            }
            return returnValue;
        }

        /// <summary>
        /// Valid if the parameter is not null or non negative
        /// </summary>
        /// <param name="seqID"></param>
        /// <returns>True, if it is valid else, false.</returns>
        public static bool IsValidSeqID(int seqID)
        {
            return (seqID != UtilConstants.InvalidSeqId);
        }

        /// <summary>
        /// Valid if the parameter is not null or non negative
        /// </summary>
        /// <param name="seqID"></param>
        /// <returns>True, if it is valid else, false.</returns>
        public static bool IsValidSeqID(int? seqID)
        {
            return (seqID != UtilConstants.InvalidSeqId && seqID != null);
        }

        public static bool IsValidSeqID(Int64? seqID)
        {
            return (seqID != UtilConstants.InvalidSeqIdInt64 && seqID != null);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteValue"></param>
        /// <returns></returns>
        public static object ConvertInvalidByteToDBNull(byte[] byteValue)
        {
            object returnValue = DBNull.Value;

            if (byteValue != null && byteValue.Count() > 1)
            {
                returnValue = byteValue;
            }

            return returnValue;
        }

        public static object ConvertInvalidStringsToDBNull(string stringValue)
        {
            object returnValue = DBNull.Value;

            if (!string.IsNullOrEmpty(stringValue) && stringValue.Trim() != string.Empty)
            {
                returnValue = stringValue.Trim();
            }

            return returnValue;
        }

        public static object ConvertInvalidDatesToDBNull(DateTime Date)
        {
            object returnValue = DBNull.Value;

            DateTime[] dt = new DateTime[] { new DateTime(1900, 1, 1), new DateTime(0001, 1, 1) };

            if (!dt.Contains(Date))
            {
                returnValue = Date;
            }
            return returnValue;
        }

        public static object ConvertInvalidDecimalToDBNull(decimal? value)
        {
            object returnValue = DBNull.Value;

            if (value != null && value != UtilConstants.InvalidDecimal)
            {
                returnValue = value;
            }
            return returnValue;
        }

        public static object ConvertInvalidDecimalToDBNull(decimal value)
        {
            object returnValue = DBNull.Value;

            if (value != UtilConstants.InvalidDecimal)
            {
                returnValue = value;
            }

            return returnValue;

        }

        public static object ConvertInvalidDoubleToDBNull(double? value)
        {
            object returnValue = DBNull.Value;
            if (value != null && value.Value != null)
            {
                returnValue = value;
            }

            return returnValue;
        }

        public static object ConvertInvalidDoubleToDBNull(double value)
        {
            object returnValue = DBNull.Value;

            if (value != UtilConstants.InvalidDouble)
            {
                returnValue = value;
            }

            return returnValue;
        }

        /// <summary>
        /// Converts the invalidSeqIDs to NULL for database query strings.
        /// </summary>
        /// <param name="seqID">Represents the seqId to convert </param>
        /// <returns>Converted invalidSeqIDs to NULL.</returns>
        public static object ConvertInvalidIntegerToDBNull(int? value)
        {
            object returnValue = DBNull.Value;

            if (value != null && value != UtilConstants.InvalidInt)
            {
                returnValue = value;
            }

            return returnValue;
        }

        /// <summary>
        /// Converts the invalidSeqIDs to NULL for database query strings.
        /// </summary>
        /// <param name="seqID">Represents the seqId to convert </param>
        /// <returns>Converted invalidSeqIDs to NULL.</returns>
        public static object ConvertInvalidStringIntegerToDBNull(string value)
        {
            object returnValue = DBNull.Value;
            int numValue;
            bool parsed = Int32.TryParse(value, out numValue);
            if (parsed && numValue != UtilConstants.InvalidInt)
            {
                returnValue = value;
            }

            return returnValue;
        }

        /// <summary>
        /// Converts the invalidSeqIDs to NULL for database query strings.
        /// </summary>
        /// <param name="seqID">Represents the seqId to convert </param>
        /// <returns>Converted invalidSeqIDs to NULL.</returns>
        public static object ConvertInvalidIntegerToDBNull(int value)
        {
            object returnValue = DBNull.Value;

            if (value != UtilConstants.InvalidInt)
            {
                returnValue = value;
            }

            return returnValue;
        }

        public static object ConvertInvalidIntegerToDBNull(ulong? value)
        {
            object returnValue = DBNull.Value;

            if (value != null && value.Value != ulong.MaxValue)
            {
                returnValue = value;
            }

            return returnValue;
        }

        public static object ConvertInvalidIntegerToDBNull(ulong value)
        {
            object returnValue = DBNull.Value;

            if (value != ulong.MaxValue)
            {
                returnValue = value;
            }

            return returnValue;
        }

        public static int ConvertBoolToDBBit(bool value)
        {
            return (value ? 1 : 0);
        }

        public static int ConvertBoolToDBBit(bool? value)
        {
            if (value == null)
                return 0;
            else
                return ((bool)value ? 1 : 0);
        }

        public static object ConvertInvalidTimeSpanToDBNull(TimeSpan timeSpan)
        {
            object returnValue = DBNull.Value;

            if (timeSpan != TimeSpan.MinValue)
            {
                returnValue = timeSpan;
            }

            return returnValue;
        }

        public static string ConvertToTitleCase(string inputValue)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            //Create TextInfo object.
            TextInfo textInfo = cultureInfo.TextInfo;
            string propertyName = string.Empty;
            propertyName = inputValue;
            propertyName = propertyName.Replace("_", " ");
            propertyName = textInfo.ToTitleCase(propertyName);
            propertyName = propertyName.Replace(" ", "");
            return propertyName;
        }

        public static SqlParameter CreateDataTableParameter(string paramName, DataTable paramDt)
        {
            SqlParameter para = new SqlParameter("@" + paramName, paramDt);
            if (paramDt == null)
            {
                para.Value = DBNull.Value;
            }

            return para;
        }

    }
}
