using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace iTanec.eCom.Common.General
{
    /// <summary>
    /// Static class containing utility helper class
    /// </summary>
    /// <history>
    ///  Author				:	Edwin J
    ///  Creation Date		:	17/1/2014
    ///  Last revised		:
    ///  Revision history	:
    /// </history>
    public static class Utility
    {
        /// <summary>
        /// Retrieve ENum value from XML attibute
        /// </summary>
        /// <param name="attribval"></param>
        /// <returns></returns>
        public static T GetEnumValueFromXmlAttrName<T>(string attribVal)
        {
            T val = default(T);

            if (typeof(T).BaseType.FullName.Equals("System.Enum"))
            {
                FieldInfo[] fields = typeof(T).GetFields();

                foreach (FieldInfo field in fields)
                {
                    object[] attribs = field.GetCustomAttributes(typeof(XmlEnumAttribute), false);

                    foreach (object attr in attribs)
                    {
                        if ((attr as XmlEnumAttribute).Name.Equals(attribVal))
                        {
                            val = (T)field.GetValue(null);
                            return val;
                        }
                    }
                }
            }

            return val;
        }

        /// <summary>
        /// serialize object to XML
        /// </summary>
        /// <param name="toserialize"></param>
        /// <returns></returns>
        public static string SerializeObjectToXML<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
            StringWriter textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }

        /// <summary>
        /// Deserialize XML object from input string
        /// </summary>
        /// <param name="toserialize"></param>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static T DeserializeXMLObject<T>(this T toSerialize, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(toSerialize.GetType());
            StringReader rdr = new StringReader(xmlString);
            return (T)serializer.Deserialize(rdr);
        }

        /// <summary>
        /// Remove HTML tags in input string
        /// </summary>
        /// <param name="inputstring"></param>
        /// <returns></returns>
        public static string RemoveHtmlTags(string inputString)
        {
            string[] exp = new string[] { "<br />", "<br/>" };
            const string HTML_TAG_PATTERN = "<.*?>";

            foreach (string str in exp)
            {
                inputString = Regex.Replace(inputString, str, "; ");
            }

            return Regex.Replace(inputString, HTML_TAG_PATTERN, string.Empty);
        }

        /// <summary>
        /// Create DB Insert values
        /// </summary>
        /// <param name="prop"></param>
        /// <returns>Prep string for DB insert</returns>
        //public static string PropertySetLooping(object prop)
        //{
        //    Type t = prop.GetType();
        //    StringBuilder sqlStringBuilder = new StringBuilder();
        //    sqlStringBuilder.Append("(");
        //    string sqlString = string.Empty;
        //    foreach (PropertyInfo info in t.GetProperties())
        //    {
        //        bool IsRequired = false;
        //        object[] attr = info.GetCustomAttributes(typeof(DBRestrict), false);
        //        if (attr != null && attr.Length > 0)
        //        {
        //            IsRequired = ((DBRestrict)attr[0]).Description;
        //        }

        //        if (!IsRequired)
        //        {
        //            if (info.CanRead && (info.PropertyType == typeof(System.Int16) || info.PropertyType == typeof(System.Int32) || info.PropertyType == typeof(System.Int64)
        //                || info.PropertyType == typeof(System.Decimal)))
        //            {
        //                sqlStringBuilder.Append(info.GetValue(prop, null));
        //                sqlStringBuilder.Append(",");

        //            }

        //            else if (info.CanRead && info.PropertyType == typeof(System.Boolean))
        //            {
        //                var x = (Boolean.Parse(info.GetValue(prop, null).ToString())) ? 1 : 0;
        //                sqlStringBuilder.Append(x);
        //                sqlStringBuilder.Append(",");
        //            }
        //            else
        //            {
        //                sqlStringBuilder.Append("'");
        //                sqlStringBuilder.Append(info.GetValue(prop, null));
        //                sqlStringBuilder.Append("'");
        //                sqlStringBuilder.Append(",");
        //            }
        //        }
        //    }
        //    sqlString = sqlStringBuilder.ToString();
        //    sqlString = sqlString.Remove(sqlString.Length - 1);
        //    return sqlString;

        //}
        /// <summary>
        /// Hash the input string along with Salt provided
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="salt"></param>
        /// <returns>Hashed byte array</returns>
        public static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        /// <summary>
        /// Remove specific char from input literal
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>cleared string</returns>
        public static string RemoveSpecificLiteral(string inputString, string[] paramExp)
        {
            // iterate through the array and clean them up
            foreach (string str in paramExp)
            {
                inputString = Regex.Replace(inputString, str, "");
            }
            return inputString;
        }

        /// <summary>
        ///Send SMS based on input
        /// </summary>
        /// <param name="DestinationNo"></param>
        /// <param name="ContentMsg"></param>
        /// <returns>bool value indicating success or faiiure</returns>
        public static bool SendSMS(string smsText, string sendTo)
        {
            #region Variables

            string userId = ConfigurationManager.AppSettings["SMSGatewayUserID"];
            string pwd = ConfigurationManager.AppSettings["SMSGatewayPassword"];
            string postURL = ConfigurationManager.AppSettings["SMSGatewayPostURL"];

            StringBuilder postData = new StringBuilder();
            string responseMessage = string.Empty;
            HttpWebRequest request = null;
            bool isSMSSent = false;

            #endregion Variables

            try
            {
                // Prepare POST data
                postData.Append("action=send");
                postData.Append("&username=" + userId);
                postData.Append("&passphrase=" + pwd);
                postData.Append("&phone=" + sendTo);
                postData.Append("&message=" + smsText);
                byte[] data = new ASCIIEncoding().GetBytes(postData.ToString());

                // Prepare web request
                request = (HttpWebRequest)WebRequest.Create(postURL);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                // Write data to stream
                using (Stream newStream = request.GetRequestStream())
                {
                    newStream.Write(data, 0, data.Length);
                }

                // Send the request and get a response
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Read the response
                    using (StreamReader srResponse = new StreamReader(response.GetResponseStream()))
                    {
                        responseMessage = srResponse.ReadToEnd();
                    }
                }
                isSMSSent = true;
            }
            catch (Exception objException)
            {
                isSMSSent = false;
                throw objException;
            }
            return isSMSSent;
        }
    }
}