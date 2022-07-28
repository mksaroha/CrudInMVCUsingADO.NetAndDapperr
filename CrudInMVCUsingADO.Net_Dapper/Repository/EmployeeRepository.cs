using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using CrudInMVCUsingADO.Net_Dapper.Models;
using Dapper;
using System.Data;

namespace CrudInMVCUsingADO.Net_Dapper.Repository
{
    public class EmployeeRepository
    {
        public SqlConnection con;
        //To Handle connection related activities      
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            con = new SqlConnection(constr);
        }


        //To Add Employee details      
        public void AddEmployee(EmployeeModel objEmp)
        {

            //Additing the employess      
            try
            {
                connection();
                con.Open();
                con.Execute("AddNewEmpDetails",objEmp, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //To view employee details with generic list       
        public List<EmployeeModel> GetAllEmployees()
        {
            try
            {
                connection();
                con.Open();
                IList<EmployeeModel> EmpList = SqlMapper.Query<EmployeeModel>(con, "GetEmployees").ToList();
                con.Close();
                return EmpList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //To Update Employee details      
        public void UpdateEmployee(EmployeeModel objUpdate)
        {
            try
            {
                connection();
                con.Open();
                con.Execute("UpdateEmpDetails", objUpdate, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }


        //To delete Employee details      
        public bool DeleteEmployee(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", Id);
                connection();
                con.Open();
                con.Execute("DeleteEmpById", param, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Log error as per your need       
                throw ex;
            }
        }
    }
}