using System;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DbHelper
    {
        private static MySqlConnection connection;

        // Chuỗi kết nối đến database (cần thay đổi dựa vào thông tin của bạn)
        private static readonly string connectionString = @"server=localhost;port=3306;user=root;password=Vietanh2302;database=MyProject";

        // Hàm tạo DbHelper, khởi tạo kết nối khi lớp được khởi tạo
        static DbHelper()
        {
            connection = new MySqlConnection(connectionString);
        }

        // Phương thức lấy kết nối (connection)
        public static MySqlConnection GetConnection()
        {
            return connection;
        }

        // Phương thức mở kết nối
        public static void OpenConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi kết nối tại đây
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Phương thức đóng kết nối
        public static void CloseConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi đóng kết nối tại đây
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Phương thức thực hiện truy vấn SELECT và trả về MySqlDataReader
        public static MySqlDataReader? ExecQuery(string sqlCommand)
        {
            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(sqlCommand, connection);
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi truy vấn tại đây
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        // Phương thức thực hiện truy vấn INSERT, UPDATE, DELETE
        public static int ExecNonQuery(string sqlCommand)
        {
            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(sqlCommand, connection);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi truy vấn tại đây
                Console.WriteLine("Error: " + ex.Message);
                return -1;
            }
        }
    }
}
