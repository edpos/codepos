using iTanec.eCom.BusinessObjects.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iTanec.eCom.Pos.API.Controllers
{
    /// <summary>
    /// API used to save the Employee Details
    /// </summary>
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// Get Info for a single employee
        /// </summary>
        /// <returns></returns>
        //[ActionName("GetEmplolyeeInfo")]
        [HttpGet]
        public string GetEmplolyee()
        {
            return "Edwin";
        }

        /// <summary>
        /// Get list of employee
        /// </summary>
        /// <returns>list</returns>
        //[ActionName("GetEmplolyeeList")]
        [HttpGet]
        public EmployeeModel ReadEmplolyee(int Id)
        {
            EmployeeModel EmployeeModelObj = new EmployeeModel();
            return EmployeeModelObj;
        }
        /// <summary>
        /// Get list of employee
        /// </summary>
        /// <returns>list</returns>
        //[ActionName("SaveEmployee")]
        [HttpPost]
        public bool SaveEmployeeInformation(EmployeeModel empolyeeModel)
        {
            return true;
        }
    }
}
