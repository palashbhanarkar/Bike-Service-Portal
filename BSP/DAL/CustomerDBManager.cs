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

            string SQLQuery = "select slot_time, APPOINTMENT_SLOTNO from BSP_APPOINTMENT_SLOTNO where status = 'Available'";

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn as OracleConnection;
            cmd.CommandText = SQLQuery;
            OracleDataAdapter adap = new OracleDataAdapter(cmd as OracleCommand);
            DataSet ds = new DataSet();


            try
            {
                adap.Fill(ds);
                //Create DataTable instance in Dataset

                DataTable customerDt = ds.Tables[0];
                foreach (DataRow datarow in customerDt.Rows)
                {
                    BSP_APPOINTMENT_SLOTNO slots = new BSP_APPOINTMENT_SLOTNO();
                    slots.SLOT_TIME = int.Parse(datarow["SLOT_TIME"].ToString());
                    slots.APPOINTMENT_SLOTNO = int.Parse(datarow["APPOINTMENT_SLOTNO"].ToString());
                    slotnos.Add(slots);
                    
                    Console.WriteLine(slots);

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

        public static bool BookAppointment(DateTime? date, int slot, int cust_id)
        {
            bool status = false;

            
            //Connect to Database
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = UserDBManager.DBConnString;
            
            //Fire query and fetch data
            string SQLQuery = "update bsp_appointment_slotno set status = 'Booked' where appointment_slotno = "+slot.ToString();
            string apptquery = "select * from bsp_appointment";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn as OracleConnection;
            cmd.CommandText = SQLQuery;

            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn as OracleConnection;
            cmd2.CommandText = apptquery;
            //cmd.Parameters.Add(new OracleParameter(":slot", slot));
            OracleDataAdapter adapter = new OracleDataAdapter(cmd2 as OracleCommand);
            DataSet apptDS = new DataSet();


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                OracleCommandBuilder cmdbldr = new OracleCommandBuilder(adapter);
                adapter.Fill(apptDS);

                DataRow newRow = apptDS.Tables[0].NewRow();
                apptDS.Tables[0].PrimaryKey = new DataColumn[] { apptDS.Tables[0].Columns["APPOINTMENT_ID"] };
                newRow["APPOINTMENT_ID"] = count;
                newRow["APPOINTMENT_DATE"] = date;
                newRow["APPOINTMENT_SLOTNO"] = slot;
                newRow["CUST_ID"] = cust_id;


                apptDS.Tables[0].Rows.Add(newRow);

                adapter.Update(apptDS);
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

        public static List<BSP_APPOINTMENT> showCustomerAppointments(int cust_id)
        {
            List<BSP_APPOINTMENT> appts = new List<BSP_APPOINTMENT>();

            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = UserDBManager.DBConnString;

            string SQLQuery = "select * from BSP_APPOINTMENT where cust_id = " + cust_id ;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn as OracleConnection;
            cmd.CommandText = SQLQuery;
            OracleDataAdapter adap = new OracleDataAdapter(cmd as OracleCommand);
            DataSet ds = new DataSet();


            try
            {
                adap.Fill(ds);
                //Create DataTable instance in Dataset

                DataTable apptDt = ds.Tables[0];
                foreach (DataRow datarow in apptDt.Rows)
                {
                    BSP_APPOINTMENT appt = new BSP_APPOINTMENT();
                    appt.APPOINTMENT_ID = int.Parse(datarow["APPOINTMENT_ID"].ToString());
                    appt.APPOINTMENT_SLOTNO = int.Parse(datarow["APPOINTMENT_SLOTNO"].ToString());
                    appt.APPOINTMENT_DATE = DateTime.Parse(datarow["APPOINTMENT_DATE"].ToString());
                    appt.CUST_ID = int.Parse(datarow["CUST_ID"].ToString());

                    appts.Add(appt);

                    Console.WriteLine(appt);

                }
            }
            catch (OracleException exp)
            {

            }
            finally
            {
                conn.Close();
            }


            return appts;
        }

        public static bool insertBike(int modelid, string REGSTR_ID, int CUST_ID, string ENGINE_ID)
        {
            bool status = false;

            
            //Connect to Database
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = UserDBManager.DBConnString;

            //Fire query and fetch data
            string SQLQuery = "select * from bsp_bike";

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn as OracleConnection;
            cmd.CommandText = SQLQuery;

            OracleDataAdapter adapter = new OracleDataAdapter(cmd as OracleCommand);
            DataSet bikeDS = new DataSet();

            try
            {
                OracleCommandBuilder cmdbldr = new OracleCommandBuilder(adapter);
                adapter.Fill(bikeDS);

                DataRow newRow = bikeDS.Tables[0].NewRow();
               // bikeDS.Tables[0].PrimaryKey = new DataColumn[] { bikeDS.Tables[0].Columns["BIKE_ID"] };
                newRow["BIKE_ID"] = count;
                
                newRow["REGSTR_ID"] = REGSTR_ID;
                newRow["MODEL_ID"] = modelid;
                newRow["CUST_ID"] = CUST_ID;
                newRow["ENGINE_ID"] = ENGINE_ID;
                bikeDS.Tables[0].Rows.Add(newRow);

                adapter.Update(bikeDS);
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

        public static List<BSP_BIKE_MODELS_ALL> GetAllModels()
        {
            List<BSP_BIKE_MODELS_ALL> models = new List<BSP_BIKE_MODELS_ALL>();

            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = UserDBManager.DBConnString;

            string SQLQuery = "select * from BSP_BIKE_MODELS_ALL ";

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn as OracleConnection;
            cmd.CommandText = SQLQuery;
            OracleDataAdapter adap = new OracleDataAdapter(cmd as OracleCommand);
            DataSet ds = new DataSet();


            try
            {
                adap.Fill(ds);
                //Create DataTable instance in Dataset

                DataTable customerDt = ds.Tables[0];
                foreach (DataRow datarow in customerDt.Rows)
                {
                    BSP_BIKE_MODELS_ALL model = new BSP_BIKE_MODELS_ALL();

                    
                    model.MODEL_CODE = int.Parse(datarow["MODEL_CODE"].ToString());
                    model.CC = int.Parse(datarow["CC"].ToString());
                    model.BRAND_NAME = datarow["BRAND_NAME"].ToString();
                    model.BHP = int.Parse(datarow["BHP"].ToString());
                    model.MODEL_NAME = datarow["MODEL_NAME"].ToString();
                    model.WEIGHT = int.Parse(datarow["WEIGHT"].ToString());
                    models.Add(model);

                    Console.WriteLine(model);

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



            return models;
        }
    }
}
