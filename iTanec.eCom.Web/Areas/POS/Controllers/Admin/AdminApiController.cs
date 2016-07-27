using iTanec.eCom.BusinessComponents.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iTanec.eCom.Web.Areas.POS.Controllers.Admin
{
    [RoutePrefix("api/Admin")]
    public class AdminApiController : ApiController
    {
        IDashboardService _dashboardService;

        public AdminApiController(IDashboardService  manager)
        {
            _dashboardService = manager;
        }

        [Route("GetDashboradInfo")]
        [HttpGet]
        public string GetDashboradInfo(int Id)
        {
            return _dashboardService.GetDashBoradManagementDetails();
        }
    }
}
