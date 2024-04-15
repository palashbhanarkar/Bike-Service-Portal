using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using Oracle.ManagedDataAccess.Client;

namespace DAL
{
    public class CustomerDBManager
    {

        //static string DBConnString = "DATA SOURCE=XE;USER ID=PALASH;PASSWORD=root123;";
        static Random r = new Random();
        static int count = r.Next(200,300);
        
        public static bool insert(BSP_CUSTOMER customer)
        {
            bool status = false;
            

            //Connect to Database
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = UserDBManager.DBConnString;

            //Fire query and fetch data
            string SQLQuery = "select * from bsp_customer";

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn as OracleConnection;
            cmd.CommandText = SQLQuery;

            OracleDataAdapter adapter = new OracleDataAdapter(cmd as OracleCommand);
            DataSet customerDS = new DataSet();

                 try
                   {
                    OracleCommandBuilder cmdbldr = new OracleCommandBuilder(adapter);
                    adapter.Fill(customerDS);
                    
                    DataRow newRow = customerDS.Tables[0].NewRow();
                    customerDS.Tables[0].PrimaryKey = new DataColumn[] { customerDS.Tables[0].Columns["CUST_ID"] };
                    newRow["CUST_ID"] = count;
                    newRow["F_NAME"] = customer.F_NAME;
                    newRow["L_NAME"] = customer.L_NAME;
                    newRow["EMAIL"] = customer.EMAIL;
                    newRow["GENDER"] = customer.GENDER;
                    newRow["MOBILE"] = customer.MOBILE;
                    newRow["PASSWORD"] = customer.PASSWORD;
                    newRow["DATE_OF_BIRTH"] = customer.DATE_OF_BIRTH;

                    customerDS.Tables[0].Rows.Add(newRow);

                    adapter.Update(customerDS);
                    count++;
                    status = true;
            }
            catch (OracleException e)
            {
                throw e;
            }

            finally
            {
                conn.Close();
            }
            return status;
        }

        public static List<BSP_APPOINTMENT_SLOTNO> GetSlotTimes()
        {
            List<BSP_APPOINTMENT_SLOTNO> slotnos = new List<BSP_APPOINTMENT_SLOTNO>();

            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = UserDBManager.DBConnString;

            string SQLQuery = "select slot_time from BSP_APPOINTMENT_SLOTNO where status = 'Available'";

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn as OracleConnection;
            cmd.CommandText = SQLQuery;
            OracleDataAdapter adap = new OracleDataAdapter(cmd as OracleCommand);
            DataSet ds = new DataSet();


            try
            {
                adap.Fill(ds);
                //Create DataTable instance in Dataset

                DataTable avengerDt = ds.Tables[0];
                foreach (DataRow datarow in avengerDt.Rows)
                {
                    BSP_APPOINTMENT_SLOTNO slot_time = new BSP_APPOINTMENT_SLOTNO();
                    slot_time.SLOT_TIME = int.Parse(datarow["SLOT_TIME"].ToString());
                    
                    slotnos.Add(slot_time);

                    Console.WriteLine(slot_time);

                }
            }
            catch (OracleException exp)
            {
                exp.GetBaseException();
            }
            finally
            {
                conn.Close();
            }


            return slotnos; ;

            
        }

        public static bool BookAppointment(DateTime? date, int? slot)
        {
            bool status = false;


            //Connect to Database
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = UserDBManager.DBConnString;
            string book = "Booked";
            //Fire query and fetch data
            string SQLQuery = "update bsp_appointment_slotno Set status = '"+book+"' where appointment_slotno = "+slot;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn as OracleConnection;
            cmd.CommandText = SQLQuery;

            //cmd.Parameters.Add(new OracleParameter(":slot", slot));
            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.UpdateCommand = new OracleCommand(SQLQuery, conn);
            


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                
                

                
                
                status = true;
            }
            catch (OracleException e)
            {
                throw e;
            }

            finally
            {
                conn.Close();
            }
            return status;
        }
    }
}
