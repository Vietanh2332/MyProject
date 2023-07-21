using System; // Import các namespace khác liên quan đến việc kết nối và truy vấn database
using DAL;
using MySql.Data.MySqlClient;

namespace MyProject.Models
{
    public class LoginModel
    {
        private static string? query;

        private static MySqlDataReader? reader;
        // Phương thức kiểm tra thông tin đăng nhập
        public static bool CheckCredentials(string email, string password)
        {
            // Thực hiện kết nối và truy vấn database để kiểm tra thông tin đăng nhập
            query = $"select * from User where Email = '{email}' and Password = '{password}'";
            DbHelper.OpenConnection();
            reader = DbHelper.ExecQuery(query);

            if (reader!= null && reader.HasRows)
            {
                // Đăng nhập thành công, xử lý thông tin đăng nhập ở đây nếu cần
                // Ví dụ: lấy thông tin user từ reader và lưu vào biến hoặc đối tượng
                // Sau đó, đóng kết nối và trả về true để chỉ ra đăng nhập thành công
                DbHelper.CloseConnection();
                return true;
            }
            else
            {
                // Đăng nhập thất bại, đóng kết nối và trả về false
                DbHelper.CloseConnection();
                return false;
            }
        }
    }
}
