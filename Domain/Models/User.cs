using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
