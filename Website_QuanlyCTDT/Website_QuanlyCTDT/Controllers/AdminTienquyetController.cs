using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website_QuanlyCTDT.Models;

namespace Website_QuanlyCTDT.Controllers
{
    public class AdminTienquyetController : Controller
    {
        private readonly QuanLyCTDTContext _context;

        public AdminTienquyetController(QuanLyCTDTContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                List<getMHhasTQ__Result> listmon = _context.getMHhasTQ().ToList();
                List<IEnumerable<getMHTQ_Result>> mhtq = new List<IEnumerable<getMHTQ_Result>>();
                for (int i = 0; i < listmon.Count; i++)
                {
                    mhtq.Add(_context.getMHTQ(listmon[i].maMH).ToList());
                }
                //var quanLyCTDTContext = _context.MhtienQuyets.Include(m => m.MaMhNavigation).Include(m => m.MaMhtqNavigation);
                ViewBag.listmon = listmon;
                ViewBag.mhtq = mhtq;
                return View();

            }
            return RedirectToAction("Login", "AdminHome");
        }
        public JsonResult Search(string keyword)
        {
            List<MonHoc> monhoc = _context.searchSubject(keyword).ToList();
           
            return Json(monhoc);
        }
        public IActionResult Create()
        {

            List<getMHhasTQ__Result> listmon = _context.getMHhasTQ().ToList();
            List<getMonhoc> monhoc = _context.getMonhoc().ToList();
            for(int i=0;i<listmon.Count;i++)
            {
                var item = monhoc.SingleOrDefault(x => x.maMh == listmon[i].maMH);
                monhoc.Remove(item);
            }
           
            ViewBag.listmon = monhoc;

            return View();
        }
        public IActionResult CreateTienquyet(string mamh)
        {
            List<MonHoc> monhoc = _context.MonHocs.ToList();
            var item = monhoc.SingleOrDefault(x => x.MaMh == mamh);
            monhoc.Remove(item);
            ViewBag.listmon = monhoc;
            ViewBag.mamh =mamh ;

            return View();
        }
        [HttpPost]
        public IActionResult CreateTienquyet(string[] mamh,string monhoc)
        {
            for(int i=0;i<mamh.Length;i++)
            {
                MhtienQuyet mhtienQuyet = new MhtienQuyet();
                mhtienQuyet.MaMh = monhoc;
                mhtienQuyet.MaMhtq = mamh[i];
                try
                {
                    _context.Add(mhtienQuyet);
                    _context.SaveChanges();
                }
                catch { }
            }

            List<getMHhasTQ__Result> listmon = _context.getMHhasTQ().ToList();
            List<IEnumerable<getMHTQ_Result>> mhtq = new List<IEnumerable<getMHTQ_Result>>();
            for (int i = 0; i < listmon.Count; i++)
            {
                mhtq.Add(_context.getMHTQ(listmon[i].maMH).ToList());
            }
            //var quanLyCTDTContext = _context.MhtienQuyets.Include(m => m.MaMhNavigation).Include(m => m.MaMhtqNavigation);
            ViewBag.listmon = listmon;
            ViewBag.mhtq = mhtq;
          
            TempData["message"] = "Success";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string mamh)
        {
            if (mamh == null)
            {
                return NotFound();
            }
            List<getMHTQ_Result> listmon = _context.getMHTQ(mamh).ToList();
            List<getMonhoc> monhoc = _context.getMonhoc().ToList();
            var a = monhoc.SingleOrDefault(x => x.maMh == mamh);
            monhoc.Remove(a);
            List<getMonhoc> listtienquyet = new List<getMonhoc>();
            
            for (int i = 0; i < listmon.Count; i++)
            {
                var item = monhoc.SingleOrDefault(x => x.maMh == listmon[i].maMHTQ);
                listtienquyet.Add(item);
                monhoc.Remove(item);
                
            }
            
            ViewBag.mamh = mamh;
            ViewBag.tienquyet = listtienquyet;
            ViewBag.listmon = monhoc;
            
           
            return View();
        }
        [HttpPost]
        public IActionResult Edit(string[] mamh,string monhoc)
        {
            List<MhtienQuyet> mhtienQuyets = _context.MhtienQuyets.Where(x => x.MaMh == monhoc).ToList();
            for(int i=0;i<mhtienQuyets.Count;i++)
            {
                try
                {
                    _context.MhtienQuyets.Remove(mhtienQuyets[i]);
                    _context.SaveChanges();
                }
                catch { }
            }
            for(int j=0;j<mamh.Length;j++)
            {
                MhtienQuyet mhtienQuyet = new MhtienQuyet();
                mhtienQuyet.MaMh = monhoc;
                mhtienQuyet.MaMhtq = mamh[j];
                try
                {
                    _context.Add(mhtienQuyet);
                    _context.SaveChanges();
                }
                catch { }
            }
            List<getMHhasTQ__Result> listmon = _context.getMHhasTQ().ToList();
            List<IEnumerable<getMHTQ_Result>> mhtq = new List<IEnumerable<getMHTQ_Result>>();
            for (int i = 0; i < listmon.Count; i++)
            {
                mhtq.Add(_context.getMHTQ(listmon[i].maMH).ToList());
            }
            //var quanLyCTDTContext = _context.MhtienQuyets.Include(m => m.MaMhNavigation).Include(m => m.MaMhtqNavigation);
            ViewBag.listmon = listmon;
            ViewBag.mhtq = mhtq;

            TempData["message"] = "Success";
            return RedirectToAction("Index");
        }
        }
}
