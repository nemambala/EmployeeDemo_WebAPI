using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Interfaces
{
    public interface IEmployee
    {
        int AddEditEmployees(EmployeeDTO Emp);
        int DeleteEmployee(int empId);
        IList<EmployeeDTO> SelectEmployee(int empId);
    }
}