using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoServices_Kunal.Models
{
    public class Driver
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public List<Job> Jobs { get; set; }
    }
}