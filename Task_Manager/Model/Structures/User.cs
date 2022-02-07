using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.Model.Structures
{
   public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Department_id { get; set; }
        public string Department { get; set; }
    }
}
