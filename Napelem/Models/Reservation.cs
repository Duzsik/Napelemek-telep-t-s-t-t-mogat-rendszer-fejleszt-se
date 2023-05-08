using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napelem.Models
{
    public class Reservation
    {
        public int reservationID { get; set; }
        public int projectID { get; set; }
        public int componentID { get; set; }
        public string? objectType { get; set; }
    }
}
