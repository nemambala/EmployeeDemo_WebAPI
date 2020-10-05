using EmployeeWebApi.Data;
using EmployeeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeWebApi.Controllers
{
    public class EmployeeController : ApiController
    {

        [HttpGet]
        [Route("api/Employee")]
        public IList<EmployeeDTO> GetAllEmployees(int id = 0)
        {
            EmployeeDAL emp = new EmployeeDAL();
            var lst = emp.SelectEmployee(id);
            return lst;
        }

        [HttpGet]
        [Route("api/Employee/{id}")]
        public IList<EmployeeDTO> GetEmployeeDetails(int id)
        {
            EmployeeDAL emp = new EmployeeDAL();
            var lst = emp.SelectEmployee(id);
            return lst;
        }

        [HttpGet]
        [Route("api/DeleteEmployee/{id}")]
        public int DeleteEmployeeDetails(int id)
        {
            EmployeeDAL emp = new EmployeeDAL();
            var result = emp.DeleteEmployee(id);
            return result;
        }

        [HttpPost]
        [Route("api/InsertEmployee")]
        public int InsertUpdateEmployee(EmployeeDTO employee)
        {
            EmployeeDAL emp = new EmployeeDAL();
            var result = emp.AddEditEmployees(employee);
            return result;
        }
    }
}
