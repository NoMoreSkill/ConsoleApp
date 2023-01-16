using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.EndPoints
{
    public interface IProductAccess
    {
        void AddProduct(Product product);
        void UpdProduct(Product product);
        void DelProduct(Product product);
        List<Product> GetProducts();
    }
}
