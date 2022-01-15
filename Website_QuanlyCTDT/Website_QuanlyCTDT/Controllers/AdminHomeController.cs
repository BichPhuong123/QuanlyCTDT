using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website_QuanlyCTDT.Models;

namespace Website_QuanlyCTDT.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly QuanLyCTDTContext _context;

        public AdminHomeController(QuanLyCTDTContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username")!=null)
            {
                return View();
            }
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            TaiKhoan user = _context.TaiKhoans.FirstOrDefault(x => x.Username == username && x.Matkhau == password);
            if(user!=null)
            {

                HttpContext.Session.SetString("username",username);

                return RedirectToAction("Index");
            }
            TempData["message"] = "Username hoặc password không hợp lệ ";
            return View();
          
        }
    }
}
