using Microsoft.AspNetCore.Mvc;
using MyProject.Models; // Import namespace chứa LoginModel

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
            // Gọi phương thức CheckCredentials từ LoginModel để kiểm tra thông tin đăng nhập
            bool isValidCredentials = LoginModel.CheckCredentials(email, password);

            if (isValidCredentials)
            {
                // Xử lý khi thông tin đăng nhập hợp lệ
                // Chẳng hạn, chuyển hướng đến trang chính
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Xử lý khi thông tin đăng nhập không hợp lệ
                // Chẳng hạn, hiển thị thông báo lỗi
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View("Index");
            }
        }
    }
}
