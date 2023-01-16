using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EndPoints;
using Domain.Models;

namespace Domain.Controllers
{
    public class ProductController
    {
        private readonly IProductAccess _productAccess;
        public ProductController(IProductAccess prodAccess)
        {
            _productAccess = prodAccess;
        }
        public void AddProduct(string name, int price, int instock)
        {
            Product product = new Product()
            {
                Name = name,
                Price = price,
                Instock = instock
            };
            _productAccess.AddProduct(product);
        }
        public void UpdProduct(int ID, string name, int price, int instock)
        {
            Product product = new Product()
            {
                ID = ID,
                Name = name,
                Price = price,
                Instock = instock
            };
            _productAccess.UpdProduct(product);
        }
        public void DelProduct(int ID)
        {
            Product product = new Product()
            {
                ID = ID
            };
            _productAccess.DelProduct(product);
        }
    }
}
