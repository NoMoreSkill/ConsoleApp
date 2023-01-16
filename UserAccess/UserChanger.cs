using System.Data.SqlClient;
using System.Xml.Linq;
using Domain.EndPoints;
using Domain.Models;

namespace UserAccess
{
    public class UserChanger:IUserAccess
    {
        private readonly string _connectionString;
        public UserChanger(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddUser(User user)
        {
            // название процедуры
            string sqlExpression = "CreateNewUser";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // параметр для ввода имени
                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@inlogin",
                    Value = user.Login
                };
                // добавляем параметр
                command.Parameters.Add(loginParam);
                // параметр для ввода возраста
                SqlParameter emailParam = new SqlParameter
                {
                    ParameterName = "@inemail",
                    Value = user.Email
                };
                command.Parameters.Add(emailParam);
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@inname",
                    Value = user.Name
                };
                command.Parameters.Add(nameParam);

                var result = command.ExecuteScalar();
                // если нам не надо возвращать id
                //var result = command.ExecuteNonQuery();

                Console.WriteLine("Пользователь добавлен в базу c id " + result);
            }
        }
        public void UpdUser(User user)
        {
            string sqlExpression = "UpdateUser";

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
                    Value = user.ID
                };
                // добавляем параметр
                command.Parameters.Add(IDParam);
                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@inlogin",
                    Value = user.Login
                };
                // добавляем параметр
                command.Parameters.Add(loginParam);
                // параметр для ввода возраста
                SqlParameter emailParam = new SqlParameter
                {
                    ParameterName = "@inemail",
                    Value = user.Email
                };
                command.Parameters.Add(emailParam);
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@inname",
                    Value = user.Name
                };
                command.Parameters.Add(nameParam);

                //var result = command.ExecuteScalar();
                // если нам не надо возвращать id
                var result = command.ExecuteNonQuery();

                Console.WriteLine("Пользователь изменен в базе");
            }
        }
        public void DelUser(User user)
        {
            string sqlExpression = "DeleteUser";

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
                    Value = user.ID
                };
                // добавляем параметр
                command.Parameters.Add(IDParam);
                var result = command.ExecuteScalar();
                // если нам не надо возвращать id
                //var result = command.ExecuteNonQuery();

                Console.WriteLine("Пользователь удален из базы");
            }
        }
        public List<User> GetUsers()
        {
            string sqlExpression = "ShowUserTable";
            List<User> users = new List<User>();
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
                    User user = new User();
                    user.ID = Convert.ToInt32(reader[0]);
                    user.Login = reader[1].ToString();
                    user.Email = reader[2].ToString();
                    user.Name = reader[3].ToString();
                    user.CreationDate = Convert.ToDateTime(reader[4]);
                    users.Add(user);
                }

                reader.Close();
            }

            return users;
        }
    }
}