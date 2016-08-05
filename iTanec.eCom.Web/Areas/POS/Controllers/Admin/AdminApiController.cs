using iTanec.eCom.BusinessComponents.Admin;
using iTanec.eCom.BusinessObjects.ViewModel.Admin;
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
        IEmployeeService employeeService;

        public AdminApiController(IDashboardService  manager)
        {
            _dashboardService = manager;
        }
        public AdminApiController(IEmployeeService manager)
        {
            employeeService = manager;
        }

        [Route("GetDashboradInfo")]
        [HttpGet]
        public string GetDashboradInfo(int Id)
        {
            return _dashboardService.GetDashBoradManagementDetails();
        }
        [Route("GetEmployeeInfo")]
        [HttpGet]
        public UserListVM GetUserInfo(int EmpId)
        {
            return employeeService.GetEmployee(EmpId);
        }
    }
}
