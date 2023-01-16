using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.EndPoints;
using Domain.Models;

namespace UserAccess
{
    public class TotalChanger:ITotalAccess
    {
        private readonly string _connectionString;
        public TotalChanger(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddTotal(Total total)
        {
            string sqlExpression = "CreateTotal";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                //int price = GetPrice(prodid);
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@inID",
                    Value = total.ID
                };
                // добавляем параметр
                command.Parameters.Add(IDParam);
                SqlParameter prodidParam = new SqlParameter
                {
                    ParameterName = "@inprodid",
                    Value = total.ProdID
                };
                // добавляем параметр
                command.Parameters.Add(prodidParam);
                SqlParameter sumParam = new SqlParameter
                {
                    ParameterName = "@insum",
                    Value = total.Totprod
                };
                // добавляем параметр
                command.Parameters.Add(sumParam);
                SqlParameter totpriceParam = new SqlParameter
                {
                    ParameterName = "@intotprice",
                    Value = total.Totprice
                };
                // добавляем параметр
                command.Parameters.Add(totpriceParam);


                var result = command.ExecuteScalar();
                Console.WriteLine("Сделка добавлена в базу c id " + result);
            }
        }
        public void UpdTotal(Total total)
        {
            string sqlExpression = "UpdateTotal";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                //int price = GetPrice(prodID);
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // параметр для ввода имени
                SqlParameter IDParam = new SqlParameter
                {
                    ParameterName = "@inID",
                    Value = total.ID
                };
                // добавляем параметр
                command.Parameters.Add(IDParam);
                SqlParameter userIDParam = new SqlParameter
                {
                    ParameterName = "@inuserID",
                    Value = total.UserID
                };
                // добавляем параметр
                command.Parameters.Add(userIDParam);
                // параметр для ввода возраста
                SqlParameter prodIDParam = new SqlParameter
                {
                    ParameterName = "@inprodID",
                    Value = total.ProdID
                };
                // добавляем параметр
                command.Parameters.Add(prodIDParam);
                SqlParameter totprodParam = new SqlParameter
                {
                    ParameterName = "@intotprod",
                    Value = total.Totprod
                };
                command.Parameters.Add(totprodParam);
                SqlParameter totpriceParam = new SqlParameter
                {
                    ParameterName = "@intotprice",
                    Value = total.Totprice
                };
                // добавляем параметр
                command.Parameters.Add(totpriceParam);

                //var result = command.ExecuteScalar();
                // если нам не надо возвращать id
                var result = command.ExecuteNonQuery();

                Console.WriteLine("Параметры сделки изменены");
            }
        }
        public void DelTotal(Total total)
        {
            string sqlExpression = "DeleteTotals";

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
                    Value = total.ID
                };
                // добавляем параметр
                command.Parameters.Add(IDParam);
                var result = command.ExecuteScalar();
                // если нам не надо возвращать id
                //var result = command.ExecuteNonQuery();

                Console.WriteLine("Сделка удалена из базы");
            }
        }
        public List<Total> GetTotals()
        {
            string sqlExpression = "ShowTotalTable";
            List<Total> totals = new List<Total>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                // если нам не надо возвращать id
                //var result = command.ExecuteNonQuery();
                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    Total total = new Total();
                    total.ID = Convert.ToInt32(reader[0]);
                    total.UserID = Convert.ToInt32(reader[1]);
                    total.ProdID = Convert.ToInt32(reader[2]);
                    total.Totprod = Convert.ToInt32(reader[3]);
                    total.Totprice = Convert.ToInt32(reader[4]);
                    totals.Add(total);
                }

                reader.Close();
            }
            return totals;
        }
    }
}
