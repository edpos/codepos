using iTanec.eCom.Common.General;
using System.Web;
using System.Web.Mvc;

namespace iTanec.eCom.Web.Areas.POS
{
    public class POSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "POS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
         //   HttpContext.Current.Session.SessionID = 1;
            SessionManager.CreateSessionObject();
            //SessionManager.Session.sysUserID = 1;
            context.MapRoute(
                "POS_default",
                "POS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}