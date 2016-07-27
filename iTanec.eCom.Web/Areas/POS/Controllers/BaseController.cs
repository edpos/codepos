using iTanec.eCom.Common.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace iTanec.eCom.Web.Areas.POS.Controllers
{
    public class BaseController : Controller
    {
        // GET: CDS/Base
        protected override void OnException(ExceptionContext filterContext)
        {
            //write your custom code here
        }
        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
            //if (SessionManager.Session.sysUserID <= 0 )
                //filterContext.Result = new RedirectResult("~/POS/Login");
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            //if (SessionManager.Session.sysUserID <= 0)
               // filterContext.Result = new RedirectResult("~/POS/Login");
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                base.Dispose(disposing);
            }
            finally
            {
                // Your database code here
            }
        }
    }
}