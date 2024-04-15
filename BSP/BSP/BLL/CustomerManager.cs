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

        public static bool BookAppointment(DateTime? date, int? slot)
        {
            return CustomerDBManager.BookAppointment(date, slot);
        }

    }
}
