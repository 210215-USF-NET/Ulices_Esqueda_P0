using System;

namespace SModels
{
    public class Customers
    {
        public int CustomerID { get; set; }
        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string Email { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string getCustomerFullName(){
            return CustomerFirstName + " " + CustomerLastName;
        }
    }
}