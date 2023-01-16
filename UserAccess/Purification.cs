using Domain.EndPoints;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccess
{
    public class Purification : IDelByParam
    {
        private readonly string _connectionString;
        public Purification(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void DeleteByParameter(Purify pure)
        {
            string sqlExpression = "DeleteByParam";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // параметр для ввода имени
                SqlParameter prodsumParam = new SqlParameter
                {
                    ParameterName = "@intotalprod",
                    Value = pure.Prodsum
                };
                // добавляем параметр
                command.Parameters.Add(prodsumParam);
                SqlParameter totalsumParam = new SqlParameter
                {
                    ParameterName = "@intotalprice",
                    Value = pure.Totalsum
                };
                // добавляем параметр
                command.Parameters.Add(totalsumParam);
                var result = command.ExecuteScalar();
                // если нам не надо возвращать id
                //var result = command.ExecuteNonQuery();

                Console.WriteLine("Сделки удалены из базы");
            }
        }
    }
}
