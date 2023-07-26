using Microsoft.AspNetCore.Mvc;
using MyProject.Models; // Import namespace chứa LoginModel

namespace MyProject.Controllers
{
    public class RegisterController : Controller
    {
        // Phương thức GET để hiển thị form đăng ký
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string email, string password, string repeatpassword)
        {
            // Gọi phương thức CheckCredentials từ LoginModel để kiểm tra thông tin đăng ký
            bool isValidCredentials = RegisterModel.CheckEmail(email);

            if (isValidCredentials)
            {
                // Lưu thông tin đăng ký vào TempData để truy cập từ trang RegisterInformation.cshtml
                TempData["Email"] = email;
                TempData["Password"] = password;
                TempData["RepeatPassword"] = repeatpassword;

                // Chuyển hướng đến trang RegisterInformation.cshtml
                return View("~/Views/Register/RegisterInformation.cshtml");
            }
            else
            {
                // Xử lý khi thông tin đăng ký không hợp lệ
                // Chẳng hạn, hiển thị lại trang đăng ký với thông báo lỗi
                return View("Index");
            }
        }


        [HttpPost]
        public IActionResult RegisterInformation(string firstName, string lastName, string phone, string address)
        {
            TempData["firstName"] = firstName;
            TempData["lastName"] = lastName;
            TempData["phone"] = phone;
            TempData["address"] = address;
            return View("~/Views/Register/A.cshtml");
        }

    }
}
