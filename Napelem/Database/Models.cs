using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napelem.Database
{
    
        public class Employee
        {
            public int employeeID { get; set; }
            public string name { get; set; }
            public string role { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }

        public class Project
        {
            public int projectID { get; set; }
            public int  employeeID { get; set; }
            public string  name { get; set; }
            public string  status { get; set; }
            public int  projectPrice { get; set; }
        }

        public class Log
        {
            public int logID { get; set; }
            public int projectID { get; set; }
            public string status { get; set; }
            public DateTime timestamp { get; set; }
        }
        public class Reservation
        {
            public int reservationID { get; set; }
            public int projectID { get; set; }
            public int componentID { get; set; }
        }
        public class Storage
        {
            public int storageID { get; set; }
            public int componentID { get; set; }
            public int row { get; set; }
            public int column { get; set; }
            public int level { get; set; }
        }

        public class Component
        {
            public int componentID { get; set; }
            public string name { get; set; }
            public int quantity { get; set; }
            public int maxQuantity { get; set; }
            public int price { get; set; }
        }
    }

