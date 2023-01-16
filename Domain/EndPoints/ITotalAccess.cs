using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.EndPoints
{
    public interface ITotalAccess
    {
        void AddTotal(Total total);
        void UpdTotal(Total total);
        public void DelTotal(Total total);
        List<Total> GetTotals();
    }
}
