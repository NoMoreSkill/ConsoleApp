using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using Domain.EndPoints;
using Domain.Models;

namespace UserAccess
{
    public class ProductChanger : IProductAccess
    {
        private readonly string _connectionString;
        public ProductChanger(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddProduct(Product product)
        {
            string sqlExpression = "CreateProduct";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@inname",
                    Value = product.Name
                };
                // добавляем параметр
                command.Parameters.Add(nameParam);
                SqlParameter priceParam = new SqlParameter
                {
                    ParameterName = "@inprice",
                    Value = product.Price
                };
                // добавляем параметр
                command.Parameters.Add(priceParam);
                SqlParameter instockParam = new SqlParameter
                {
                    ParameterName = "@ininstock",
                    Value = product.Instock
                };
                // добавляем параметр
                command.Parameters.Add(instockParam);
                var result = command.ExecuteScalar();
                Console.WriteLine("Товар добавлен в базу c id " + result);
            }
        }
        public void UpdProduct(Product product)
        {
            string sqlExpression = "UpdateProduct";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // параметр для ввода имени
                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@inID",
                    Value = product.ID
                };
                // добавляем параметр
                command.Parameters.Add(IDParam);
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@inname",
                    Value = product.Name
                };
                // добавляем параметр
                command.Parameters.Add(nameParam);
                // параметр для ввода возраста
                SqlParameter priceParam = new SqlParameter
                {
                    ParameterName = "@inprice",
                    Value = product.Price
                };
                command.Parameters.Add(priceParam);
                SqlParameter instockParam = new SqlParameter
                {
                    ParameterName = "@ininstock",
                    Value = product.Instock
                };
                command.Parameters.Add(instockParam);

                //var result = command.ExecuteScalar();
                // если нам не надо возвращать id
                var result = command.ExecuteNonQuery();

                Console.WriteLine("Товар изменен в базе");
            }
        }
        public void DelProduct(Product product)
        {
            string sqlExpression = "DeleteProduct";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // параметр для ввода имени
                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@inID",
                    Value = product.ID
                };
                // добавляем параметр
                command.Parameters.Add(IDParam);
                var result = command.ExecuteScalar();
                // если нам не надо возвращать id
                //var result = command.ExecuteNonQuery();

                Console.WriteLine("Товар удален из базы");
            }
        }
        public List<Product> GetProducts()
        {
            string sqlExpression = "ShowProdTable";
            List<Product> prods = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                // если нам не надо возвращать id
                //var result = command.ExecuteNonQuery();

                while (reader.Read())
                {
                    Product product = new Product();
                    product.ID = Convert.ToInt32(reader[0]);
                    product.Name = reader[1].ToString();
                    product.Price = Convert.ToInt32(reader[2]);
                    product.Instock = Convert.ToInt32(reader[3]);
                    prods.Add(product);
                }
                reader.Close();
            }
            return prods;
        }
    }
}
