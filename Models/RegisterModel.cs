using System; // Import các namespace khác liên quan đến việc kết nối và truy vấn database
using DAL;
using MySql.Data.MySqlClient;

namespace MyProject.Models
{
    public class RegisterModel
    {
        private static string? query;

        private static MySqlDataReader? reader;
        // Phương thức kiểm tra thông tin đăng nhập
        public static bool CheckEmail(string email)
        {
            // Thực hiện kết nối và truy vấn database để kiểm tra thông tin đăng nhập
            query = $"select * from User where Email = '{email}'";
            DbHelper.OpenConnection();
            reader = DbHelper.ExecQuery(query);

            if (reader!= null && reader.HasRows)
            {
                DbHelper.CloseConnection();
                return false;
            }
            else
            {
                DbHelper.CloseConnection();
                return true;
            }
        }
    }
}
