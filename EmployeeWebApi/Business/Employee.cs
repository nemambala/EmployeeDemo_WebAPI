using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeWebApi.Data;
using EmployeeWebApi.Interfaces;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Business
{
    public class Employee : IEmployee
    {
        public int AddEditEmployees(EmployeeDTO Emp)
        {
            try
            {
                EmployeeDAL dal = new EmployeeDAL();
                return dal.AddEditEmployees(Emp);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return 0;
        }
        public int DeleteEmployee(int empId)
        {
            try
            {
                EmployeeDAL dal = new EmployeeDAL();
                return dal.DeleteEmployee(empId);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return 0;

        }
        public IList<EmployeeDTO> SelectEmployee(int empId)
        {
            try
            {
                EmployeeDAL dal = new EmployeeDAL();
                return dal.SelectEmployee(empId);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return null;
        }
    }
}