using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace iTanec.eCom.Common.General
{
    public class SessionManager
    {
        public const string SESSION_OBJECT = "SESSION_OBJECT";

        /// <summary>
        /// Creates a new session object if a object doesn't exists
        /// </summary>
        public static void CreateSessionObject()
        {
            if (HttpContext.Current.Session != null)
            {
                if (HttpContext.Current.Session[SESSION_OBJECT] == null)
                {
                    HttpContext.Current.Session[SESSION_OBJECT] = new SessionObject();
                }
            }
        }
        /// <summary>
        /// Gets the current session object from the active session
        /// </summary>
        public static SessionObject Session
        {
            get
            {
                CreateSessionObject();
                if (Utilities.HasValue(HttpContext.Current.Session))
                    return (SessionObject)HttpContext.Current.Session[SESSION_OBJECT];
                else
                    return null;
            }
        }
        /// <summary>
        /// Closes the active session
        /// </summary>
        public static void Close()
        {
            if (HttpContext.Current.Session != null)
            {
                HttpContext.Current.Session.Abandon();
            }
        }
    }

}
