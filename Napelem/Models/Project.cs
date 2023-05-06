using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napelem.Models
{
    public class Project
    {
        public int projectID { get; set; }
        public int employeeID { get; set; }
        public string? name { get; set; }
        public string? status { get; set; }
        public int project_price { get; set; }
        public string? objectType { get; set; }

    }
}
