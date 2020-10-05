using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EmployeeWebApi.Models;
namespace EmployeeWebApi.Data
{
    public class EmployeeDAL
    {


        #region Member Variables
        private SqlConnection con;
        private SqlCommand cmd;
        List<EmployeeDTO> obj1 = new List<EmployeeDTO>();
        #endregion        

        #region User defined Methods
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["employeeconnection"].ToString();
            con = new SqlConnection(constr);
        }
        public int AddEditEmployees(EmployeeDTO Emp)
        {
            int result = -1;
            try
            {
                connection();
                if (Emp.EmployeeId == 0)
                {
                    cmd = new SqlCommand("p_Employee_InsertOrUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", Emp.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", Emp.LastName);
                    cmd.Parameters.AddWithValue("@Department", Emp.Department);
                    cmd.Parameters.AddWithValue("@Address1", Emp.Address1);
                    cmd.Parameters.AddWithValue("@City", Emp.City);
                    cmd.Parameters.AddWithValue("@State", Emp.State);
                    cmd.Parameters.AddWithValue("@Country", Emp.Country);
                    cmd.Parameters.AddWithValue("@phone", Emp.Phone);
                    con.Open();

                    var res = cmd.ExecuteScalar();
                    if (res != null)
                        result = Convert.ToInt32(res);
                }
                else
                {
                    cmd = new SqlCommand("p_Employee_InsertOrUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", Emp.EmployeeId);
                    cmd.Parameters.AddWithValue("@FirstName", Emp.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", Emp.LastName);
                    cmd.Parameters.AddWithValue("@Department", Emp.Department);
                    cmd.Parameters.AddWithValue("@Address1", Emp.Address1);
                    cmd.Parameters.AddWithValue("@City", Emp.City);
                    cmd.Parameters.AddWithValue("@State", Emp.State);
                    cmd.Parameters.AddWithValue("@Country", Emp.Country);
                    cmd.Parameters.AddWithValue("@phone", Emp.Phone);
                    con.Open();

                    var res = cmd.ExecuteScalar();
                    if (res != null)
                        result = Convert.ToInt32(res);

                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public int DeleteEmployee(int empId)
        {
            var result = -1;
            connection();
            try
            {
                cmd = new SqlCommand("p_Employee_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", empId);
                con.Open();
                var res = cmd.ExecuteScalar();
                if (res != null)
                    result = Convert.ToInt32(res);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return 0;
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public IList<EmployeeDTO> SelectEmployee(int empId = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                connection();
                cmd = new SqlCommand("p_Employee_GetDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (empId > 0)
                    cmd.Parameters.AddWithValue("@EmpId", empId);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        EmployeeDTO emp = new EmployeeDTO();
                        emp.EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
                        emp.FirstName = dt.Rows[i]["FirstName"].ToString();
                        emp.LastName = dt.Rows[i]["LastName"].ToString();
                        emp.DateOfJoin = dt.Rows[i]["DateOfJoin"].ToString();
                        emp.Department = dt.Rows[i]["Department"].ToString();
                        emp.Address1 = dt.Rows[i]["Address1"].ToString();
                        emp.City = dt.Rows[i]["City"].ToString();
                        emp.State = dt.Rows[i]["State"].ToString();
                        emp.Country = dt.Rows[i]["Country"].ToString();
                        emp.Phone = dt.Rows[i]["Phone"].ToString();
                        obj1.Add(emp);
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return obj1;
        }
        #endregion

    }
}