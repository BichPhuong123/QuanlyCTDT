using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website_QuanlyCTDT.Models;

namespace Website_QuanlyCTDT.Controllers
{
    public class AdminKhoahocController : Controller
    {
        private readonly QuanLyCTDTContext _context;

        public AdminKhoahocController(QuanLyCTDTContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                IEnumerable<KhoaHoc> khoahoc = _context.KhoaHocs.ToList();
                return View(khoahoc);
               
            }
            return RedirectToAction("Login", "AdminHome");
        }
        [HttpPost]
        public JsonResult Create([Bind("Id,TenKh")] KhoaHoc khoaHoc)
        {
            int a;
            List<KhoaHoc> kh = _context.KhoaHocs.Where(m => m.Id == khoaHoc.Id).ToList();
            if (kh.Count > 0)

            {
                a = 0;
            }
            else
            {

                khoaHoc.TenKh = khoaHoc.TenKh.Trim();
                try
                {
                    _context.Add(khoaHoc);
                    _context.SaveChanges();
                }
                catch { }
                a = 1;
            }
            return Json(a);
        }
        [HttpPost]
        public JsonResult Edit([Bind("Id,TenKh")] KhoaHoc khoaHoc)
        {
            int a =1;


            KhoaHoc khoa = _context.KhoaHocs.FirstOrDefault(x => x.Id == khoaHoc.Id);
                khoa.TenKh = khoaHoc.TenKh.Trim();
                try
                {
                    _context.Update(khoa);
                    _context.SaveChanges();
                }
                catch { }
               
          
            return Json(a);
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            int a = 1;


            KhoaHoc khoa = _context.KhoaHocs.FirstOrDefault(x => x.Id == Id);
           
            try
            {
                _context.Remove(khoa);
                _context.SaveChanges();
            }
            catch { }


            return Json(a);
        }
    }
}
