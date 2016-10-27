using iTanec.eCom.BusinessComponents.Admin;
using iTanec.eCom.BusinessObjects.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iTanec.eCom.Pos.API.Controllers
{
    public class AdminController : ApiController
    {
        IDashboardService _dashboardService;
        IEmployeeService employeeService;

        public AdminController(IDashboardService manager)
        {
            _dashboardService = manager;
        }
        public AdminController(IEmployeeService manager)
        {
            employeeService = manager;
        }

        [ActionName("GetDashboradInfo")]
        public string GetDashboradInfo(int Id)
        {
            return _dashboardService.GetDashBoradManagementDetails();
        }
        [ActionName("GetEmployeeInfo")]
        public UserListVM GetUserInfo(int EmpId)
        {
            return employeeService.GetEmployee(EmpId);
        }
    }
}
