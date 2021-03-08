using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string School { get; set; }
        public string Class { get; set; }
        public string Major { get; set; }

        public User()
        {
            
            ID = String.Empty;
            Name = String.Empty;
            Gender = String.Empty;
            School = String.Empty;
            Class = String.Empty;
            Major = String.Empty;
            
        }
        
    }
}
