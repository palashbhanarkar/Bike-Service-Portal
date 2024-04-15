using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;

namespace BLL
{
    public class UserManager
    {
        public static BSP_CUSTOMER validateCustomer(string email, string password)
        {
            Console.WriteLine(email + password);
            return UserDBManager.validateCustomer(email, password);

        }

        public static BSP_EMPLOYEE validateEmployee(string f_name, string password)
        {

            return UserDBManager.validateEmployee(f_name, password);

        }
    }
}
