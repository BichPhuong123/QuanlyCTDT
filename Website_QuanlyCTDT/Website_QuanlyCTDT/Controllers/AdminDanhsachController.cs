using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website_QuanlyCTDT.Models;

namespace Website_QuanlyCTDT.Controllers
{
    public class AdminDanhsachController : Controller
    {
        private readonly QuanLyCTDTContext _context;

        public AdminDanhsachController(QuanLyCTDTContext context)
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
        public async Task<IActionResult> Danhsach(int id)
        {
            List<Nganh> nganh = _context.Nganhs.ToList();
            List<IEnumerable<getMHByKhoa_Result>> monhoc = new List<IEnumerable<getMHByKhoa_Result>>();
            for (int i = 0; i < nganh.Count; i++)
            {
                monhoc.Add(_context.getMHByKhoa(id, nganh[i].Manganh).ToList());
            }
            ViewBag.listnganh = nganh;
            ViewBag.listmon = monhoc;
            ViewBag.id = id;
            return View();
        }
        public IActionResult Edit(int idk, string manganh)
        {
            List<getMHByKhoa_Result> monhoc = _context.getMHByKhoa(idk, manganh).ToList();
            List<getMonhoc> listmon = _context.getMonhoc().ToList();
            for (int i=0;i<monhoc.Count;i++)
            {
                var item = listmon.SingleOrDefault(x => x.maMh == monhoc[i].maMh);
                listmon.Remove(item);
            }
            ViewBag.listmon = listmon;
            ViewBag.monhoc = monhoc;
            ViewBag.khoa = idk;
            ViewBag.nganh = manganh;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(string[] mamh,int idk, string manganh)
        {
            List<getMHByKhoa_Result> monhoc = _context.getMHByKhoa(idk, manganh).ToList();
           
           
            for (int i =0;i<monhoc.Count;i++)
            {
                
                var item = _context.MonKhoas.SingleOrDefault(x => x.MaMh == monhoc[i].maMh && x.IdKhoahoc == idk && x.Manganh == manganh);
                try
                {
                    _context.MonKhoas.Remove(item);
                    _context.SaveChanges();
                }
                catch { }
                

                //if (res.Count > 1 )
                //{
                //    MonKhoa mk = new MonKhoa();
                //    mk.MaMh = monhoc[i].maMh;
                //    mk.IdKhoahoc = idk;
                //    try
                //    {
                //        _context.Add(mk);
                //        _context.SaveChanges();
                //    }
                //    catch { }
                //}
                //else
                //{
                //    if (res1.Count == 1)
                //    {
                //        var item1 = _context.MonNganhs.SingleOrDefault(x => x.MaMh == monhoc[i].maMh && x.Manganh == manganh);
                //        try
                //        {
                //            _context.MonNganhs.Remove(item1);
                //            _context.SaveChanges();
                //        }
                //        catch { }
                //    }
                //}
                //if (res1.Count == 1)
                //{
                //    var item1 = _context.MonNganhs.SingleOrDefault(x => x.MaMh == monhoc[i].maMh && x.Manganh == manganh);
                //    try
                //    {
                //        _context.MonNganhs.Remove(item1);
                //        _context.SaveChanges();
                //    }
                //    catch { }
                //}
                //try
                //{

                //    var item = _context.MonKhoas.SingleOrDefault(x => x.MaMh == monhoc[i].maMh && x.IdKhoahoc == idk);
                //    var item1 = _context.MonNganhs.SingleOrDefault(x => x.MaMh == monhoc[i].maMh && x.Manganh == manganh);
                //    _context.MonKhoas.Remove(item);
                //    _context.SaveChanges();
                //    _context.MonNganhs.Remove(item1);
                //    _context.SaveChanges();
                //}
                //catch
                //{

                //}
            }
            for (int i = 0; i < mamh.Length; i++)
            {
                MonKhoa monKhoa = new MonKhoa();
              
                monKhoa.IdKhoahoc = idk;
                monKhoa.MaMh = mamh[i];
                monKhoa.Manganh = manganh;
               
                    try
                    {
                        _context.Add(monKhoa);
                        _context.SaveChanges();
                    }
                    catch { }
             
               
                
              
            }
            IEnumerable<KhoaHoc> khoahoc = _context.KhoaHocs.ToList();
            TempData["message"] = "Success";
            return RedirectToAction("Index",khoahoc);
        }
        }
}
