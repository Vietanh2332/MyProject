using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
    public class LoginController : Controller
    {
        // Phương thức GET để hiển thị form đăng nhập
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Phương thức POST để xử lý yêu cầu khi nhấn nút Sign In
        [HttpPost]
        public IActionResult SignIn(string email, string password, bool rememberMe)
        {
            // Xử lý thông tin đăng nhập ở đây
            // Kiểm tra thông tin đăng nhập, thực hiện các thao tác liên quan.

            // Sử dụng ViewBag để truyền dữ liệu vào View
            ViewBag.Email = email;
            ViewBag.Password = password;
            ViewBag.RememberMe = rememberMe;

            // Trả về View "SignIn" (hoặc tên view của bạn) để hiển thị dữ liệu đã nhập.
            return View("SignIn");
        }
    }
}
