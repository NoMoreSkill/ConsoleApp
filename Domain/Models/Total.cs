using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Total
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProdID { get; set; }
        public int Totprod { get; set; }
        public int Totprice { get; set; }
    }
}
