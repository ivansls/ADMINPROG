using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPROG
{
    class users
    {
        public int id_user { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int client_type_id { get; set; }
        public int discount_id { get; set; }
        public int visit_numbers { get; set; }
        public bool exist { get; set; }
    }
}
