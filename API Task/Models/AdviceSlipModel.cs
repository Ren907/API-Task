using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Task.Models
{


    public class Rootobject
    {
        public string total_results { get; set; }
        public string query { get; set; }

        public List<Slip> slips { get; set; }
    }

    public class Slip
    {
        public int id { get; set; }
        public string advice { get; set; }
        public string date { get; set; }
    }



}