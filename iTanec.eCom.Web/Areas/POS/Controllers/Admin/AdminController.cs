using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iTanec.eCom.Web.Areas.POS.Controllers.Admin
{
    public class AdminController : BaseController
    {
        // GET: POS/Admin
        public ActionResult Index()
        {
            return View();
        }
        // GET: POS/Admin
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}