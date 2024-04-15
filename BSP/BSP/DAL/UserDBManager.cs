
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using BOL;

namespace DAL
{
    public class UserDBManager
    {
        public static string DBConnString = "DATA SOURCE=XE;USER ID=PALASH;PASSWORD=root123;";

        public static BSP_EMPLOYEE validateEmployee(string first_name, string password)
        {
            Console.WriteLine(first_name + password);
            BSP_EMPLOYEE employee = new BSP_EMPLOYEE();

            //Connect to Database
            Console.WriteLine("DB Connecting...");
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = DBConnString;
            Console.WriteLine("DB Connected");

            //Fire Query and fetch data
            string SQLQuery = "select * from bsp_employee where first_name=:fname and password=:pwd";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = SQLQuery;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new OracleParameter(":fname", first_name));
            cmd.Parameters.Add(new OracleParameter(":pwd", password));

            OracleDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    employee.EMPLOYEE_ID = int.Parse(reader["EMPLOYEE_ID"].ToString());
                    employee.DEPARTMENT_NO = int.Parse(reader["DEPARTMENT_NO"].ToString());
                    employee.EMP_SALARY = decimal.Parse(reader["EMP_SALARY"].ToString());
                    employee.FIRST_NAME = reader["FIRST_NAME"].ToString();
                    employee.LAST_NAME = reader["LAST_NAME"].ToString();
                    employee.JOB_ROLE = reader["JOB_ROLE"].ToString();
                    employee.PASSWORD = reader["PASSWORD"].ToString();
                    employee.HIRE_DATE = DateTime.Parse(reader["HIRE_DATE"].ToString());
                }

            }
            catch (OracleException e)
            {
                throw e;
            }

            finally
            {
                conn.Close();
            }
            return employee;
        }

        public static BSP_CUSTOMER validateCustomer(string email, string password)
        {
            BSP_CUSTOMER customer = new BSP_CUSTOMER();

            //Connect to Database
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = DBConnString;

            //Fire query and fetch data
            string SQLQuery = "select * from bsp_customer where email=:em and password=:pwd";

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = SQLQuery;

            cmd.Parameters.Add(new OracleParameter(":em", email));
            cmd.Parameters.Add(new OracleParameter(":pwd", password));


            IDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer.CUST_ID = int.Parse(reader["CUST_ID"].ToString());
                    customer.F_NAME = reader["F_NAME"].ToString();
                    customer.L_NAME = reader["L_NAME"].ToString();
                    customer.EMAIL = reader["EMAIL"].ToString();
                    customer.GENDER = reader["GENDER"].ToString();
                    customer.MOBILE = reader["MOBILE"].ToString();
                    customer.PASSWORD = reader["PASSWORD"].ToString();
                    customer.DATE_OF_BIRTH = DateTime.Parse(reader["DATE_OF_BIRTH"].ToString());
                }

            }
            catch (OracleException e)
            {
                throw e;
            }

            finally
            {
                conn.Close();
            }
            return customer;
        }
    }


}
