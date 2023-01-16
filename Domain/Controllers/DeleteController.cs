using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EndPoints;
using Domain.Models;

namespace Domain.Controllers
{
    public class DeleteController
    {
        private readonly IDelByParam _purifyAccess;
        public DeleteController(IDelByParam purityAccess)
        {
            _purifyAccess = purityAccess;
        }
        public void DeleteByParameter(int prodsum, int totalsum)
        {
            Purify purify = new Purify()
            {
                Prodsum = prodsum,
                Totalsum = totalsum
            };
            _purifyAccess.DeleteByParameter(purify);
        }
    }
}
