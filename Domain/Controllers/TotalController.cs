using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EndPoints;
using Domain.Models;

namespace Domain.Controllers
{
    public class TotalController
    {
        private readonly ITotalAccess _totalAccess;
        public TotalController(ITotalAccess totalAccess)
        {
            _totalAccess = totalAccess;
        }
        public void AddTotal(int ID, int prodid, int sum)
        {
            Total total = new Total()
            {
                ID = ID,
                ProdID = prodid,
                Totprice = sum
            };
            _totalAccess.AddTotal(total);
        }
        public void UpdTotal(int ID, int userID, int prodid, int sum)
        {
            Total total = new Total()
            {
                ID = ID,
                UserID = userID,
                ProdID = prodid,
                Totprice = sum
            };
            _totalAccess.UpdTotal(total);
        }
        public void DelTotal(int ID)
        {
            Total total = new Total()
            {
                ID = ID
            };
            _totalAccess.DelTotal(total);
        }
    }
}
