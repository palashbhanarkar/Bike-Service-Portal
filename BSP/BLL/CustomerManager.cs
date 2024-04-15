using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class CustomerManager
    {
        public static bool insert(BSP_CUSTOMER customer)
        {
            return CustomerDBManager.insert(customer);
        }

        public static List<BSP_APPOINTMENT_SLOTNO> slot_times()
        {
            return CustomerDBManager.GetSlotTimes();
        }

        public static bool BookAppointment(DateTime? date, int slot, int cust_id)
        {
            return CustomerDBManager.BookAppointment(date, slot, cust_id);
        }

        public static List<BSP_APPOINTMENT> getAppts(int cust_id)
        {
            return CustomerDBManager.showCustomerAppointments(cust_id);
        }

        public static bool insertBike(int modelid, string REGSTR_ID, int  CUST_ID, string ENGINE_ID)
        {
            return CustomerDBManager.insertBike(modelid, REGSTR_ID, CUST_ID, ENGINE_ID);
        }

        public static List<BSP_BIKE_MODELS_ALL> GetAllModels()
        {
            return CustomerDBManager.GetAllModels();
        }

    }
}
