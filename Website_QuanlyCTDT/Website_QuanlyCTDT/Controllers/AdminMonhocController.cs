using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website_QuanlyCTDT.Models;

namespace Website_QuanlyCTDT.Controllers
{
    public class AdminMonhocController : Controller
    {
        private IHostingEnvironment Environment;
        private readonly QuanLyCTDTContext _context;
        public AdminMonhocController(IHostingEnvironment _environment, QuanLyCTDTContext context)
        {
            Environment = _environment;
            _context = context;
        }

        // GET: KhoaHocs
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                IEnumerable<KhoaHoc> khoahoc = await _context.KhoaHocs.ToListAsync();
                return View(khoahoc);
            }
            return RedirectToAction("Login","AdminHome");
           
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
        public JsonResult Search(int idkh, string idn, string keyword)
        {
            List<getMHByKhoa_Result> monhoc = _context.searchSubjects(idkh, idn, keyword).ToList();
            JsonResult a = Json(monhoc);
            return Json(monhoc);
        }
        public IActionResult CreateMonhoc(int idkh, string idn)
        {
            ViewBag.idkh = idkh;
            ViewBag.idn = idn;
            ViewBag.chuyennganh = _context.ChuyenNganhs.ToList();
            return View();
        }
        [HttpPost]
        public JsonResult CreateMonhoc([Bind("MaMh,Ten,Sotinchi,Mota,IdChuyennganh")] MonHoc monHoc,int idkh,string idn)
        {

            int a;
            List<MonHoc> mh = _context.MonHocs.Where(m => m.MaMh == monHoc.MaMh).ToList();
            if (mh.Count > 0)

            {
                a = 0;
            }
            else
            {
                monHoc.MaMh = monHoc.MaMh.Trim();
                monHoc.Ten = monHoc.Ten.Trim();
                monHoc.Mota = monHoc.Mota.Trim();
                try
                {
                    _context.Add(monHoc);
                    _context.SaveChanges();
                }
                catch { }
                MonKhoa monkhoa = new MonKhoa();
                monkhoa.MaMh = monHoc.MaMh.Trim();
                monkhoa.IdKhoahoc = idkh;
                monkhoa.Manganh = idn;
                try
                {
                    _context.Add(monkhoa);
                    _context.SaveChanges();
                }
                catch { }
               
                a = 1;
            }
          
          
            
            return Json(a);
        }
        public IActionResult CreateMuctieu(string MaMh)
        {
            ViewBag.mamh =MaMh;
            
            return View();
        }
        [HttpPost]
        public IActionResult CreateMuctieu(string[] Mota,string[] Daura,string MaMh)
        {


            for (int i = 0; i < Mota.Length; i++)
            {

                if (Mota[i] != null)
                {
                    MucTieu mucTieu = new MucTieu();
                    mucTieu.Mota = Mota[i].Trim();
                    mucTieu.MaMh = MaMh;
                    try
                    {
                        _context.Add(mucTieu);
                        _context.SaveChanges();
                    }
                    catch { }
                    if (Daura[i] != null)
                    {
                        string[] daura = Daura[i].Split("\r\n");
                        for (int j = 0; j < daura.Length; j++)
                        {
                            ChuanDauRa chuanDauRa = new ChuanDauRa();
                            chuanDauRa.Mota = daura[j].Trim();
                            chuanDauRa.MaMh = MaMh;
                            chuanDauRa.IdMuctieu = mucTieu.Id;
                            try
                            {
                                _context.Add(chuanDauRa);
                                _context.SaveChanges();
                            }
                            catch { }
                        }
                    }
                }



            }

            ViewBag.mamh = MaMh;
            ViewBag.Tuan = _context.Tuans.ToList(); 
            return View("CreateNoidung");
        }
        [HttpPost]
        public IActionResult CreateNoidung(string[] Ten, string[] lop,string[] nha,int[] Tuan, string MaMh)
        {


            for (int i = 0; i < Ten.Length; i++)
            {
                
               
                int tuan = Tuan[i];
                if(Ten[i]!=null){
                    Chuong chuong = new Chuong();
                    chuong.Ten = Ten[i].Trim();
                    chuong.MaMh = MaMh;
                    chuong.IdTuan = tuan;
                    try
                    {
                        _context.Add(chuong);
                        _context.SaveChanges();
                    }
                    catch { }
                    if (lop[i] != null)
                    {
                        string[] pclop = lop[i].Split("\r\n");
                        for (int j = 0; j < pclop.Length; j++)
                        {
                            PhanCongLop phanCongLop = new PhanCongLop();
                            phanCongLop.Mota = pclop[j].Trim();
                            phanCongLop.IdChuong = chuong.Id;

                            try
                            {
                                _context.Add(phanCongLop);
                                _context.SaveChanges();
                            }
                            catch { }
                        }
                    }
                    if (nha[i] != null)
                    {
                        string[] pcnha = nha[i].Split("\r\n");
                        for (int k = 0; k < pcnha.Length; k++)
                        {
                            PhanCongNha phanCongNha = new PhanCongNha();
                            phanCongNha.Mota = pcnha[k].Trim();
                            phanCongNha.IdChuong = chuong.Id;

                            try
                            {
                                _context.Add(phanCongNha);
                                _context.SaveChanges();
                            }
                            catch { }
                        }
                    }
                }
                


            }
            IEnumerable<KhoaHoc> khoahoc = _context.KhoaHocs.ToList();
           

            return View("Index", khoahoc);
        }
        [HttpPost]
        public JsonResult Delete(string mamh)
        {
            int a = 1;
           List<MonKhoa> monKhoas = _context.MonKhoas.Where(x => x.MaMh == mamh).ToList();
         
            List<MucTieu> mucTieus = _context.MucTieus.Where(x => x.MaMh == mamh).ToList();
            List<ChuanDauRa> chuanDauRas = _context.ChuanDauRas.Where(x => x.MaMh == mamh).ToList();
            List<MhtienQuyet> mhtienQuyets= _context.MhtienQuyets.Where(x => x.MaMh == mamh).ToList();
            List<MhtienQuyet> mhtienQuyet = _context.MhtienQuyets.Where(x => x.MaMhtq == mamh).ToList();
            List<Chuong> chuongs = _context.Chuongs.Where(x => x.MaMh == mamh).ToList();
            MonHoc monHoc = _context.MonHocs.FirstOrDefault(x => x.MaMh == mamh);

            for (int i=0;i<chuongs.Count;i++)
                    {
                List<PhanCongLop> phanCongLops = _context.PhanCongLops.Where(x => x.IdChuong == chuongs[i].Id).ToList();
                for (int j = 0; j < phanCongLops.Count; j++)
                {
                    try
                    {
                        _context.Remove(phanCongLops[j]);
                        _context.SaveChanges();
                    }
                    catch { }
                }

                List<PhanCongNha> phanCongNhas = _context.PhanCongNhas.Where(x => x.IdChuong == chuongs[i].Id).ToList();
                for (int k = 0; k < phanCongNhas.Count; k++)
                {
                    try
                    {
                        _context.Remove(phanCongNhas[k]);
                        _context.SaveChanges();
                    }
                    catch { }
                }
                try
                {
                    _context.Remove(chuongs[i]);
                    _context.SaveChanges();
                }
                catch { }
            }

           
            for (int i = 0; i < monKhoas.Count; i++)
            {
                try
                {
                    _context.Remove(monKhoas[i]);
                    _context.SaveChanges();
                }
                catch { }
            }
            //for (int i = 0; i < monNganhs.Count; i++)
            //{
            //    try
            //    {
            //        _context.Remove(monNganhs[i]);
            //        _context.SaveChanges();
            //    }
            //    catch { }
            //}
            for (int i = 0; i < mucTieus.Count; i++)
            {
                try
                {
                    _context.Remove(mucTieus[i]);
                    _context.SaveChanges();
                }
                catch { }
            }
            for (int i = 0; i < chuanDauRas.Count; i++)
            {
                try
                {
                    _context.Remove(chuanDauRas[i]);
                    _context.SaveChanges();
                }
                catch { }
            }
            for (int i = 0; i < mhtienQuyets.Count; i++)
            {
                try
                {
                    _context.Remove(mhtienQuyets[i]);
                    _context.SaveChanges();
                }
                catch { }
            }
            for (int i = 0; i < mhtienQuyet.Count; i++)
            {
                try
                {
                    _context.Remove(mhtienQuyet[i]);
                    _context.SaveChanges();
                }
                catch { }
            }
            try
            {
                _context.Remove(monHoc);
                _context.SaveChanges();
            }
            catch { }

            return Json(a);
        }
        public IActionResult Edit(string mamh)
        {
            
            ViewBag.chuyennganh = _context.ChuyenNganhs.ToList();
            MonHoc mon = _context.MonHocs.FirstOrDefault(x => x.MaMh == mamh);
            mon.IdChuyennganhNavigation = null;
            ViewBag.mamh = mon;
            return View();
                }
        [HttpPost]
        public IActionResult Edit([Bind("MaMh,Ten,Sotinchi,Mota,IdChuyennganh")] MonHoc monHoc)
        {

            monHoc.Ten.Trim();
            monHoc.Mota.Trim();
            try
            {
                _context.Update(monHoc);
                _context.SaveChanges();
            }
            catch { }
          
                IEnumerable<KhoaHoc> khoahocs = _context.KhoaHocs.ToList();
                TempData["message"] = "Success";
                return RedirectToAction("Index", khoahocs);
           
        }
        public IActionResult EditMuctieu(string mamh)
        {
            List<MucTieu> mucTieu = _context.MucTieus.Where(x => x.MaMh == mamh).ToList();
            List<string> chuanDauRas = new List<string>();
            for (int i = 0; i < mucTieu.Count; i++)
            {
                string a ="";
                List<ChuanDauRa> chuans = _context.ChuanDauRas.Where(x => x.IdMuctieu == mucTieu[i].Id).ToList();
                for (int j = 0; j < chuans.Count; j++)
                {
                    a += chuans[j].Mota +'\n';
                }
                chuanDauRas.Add(a);
                mucTieu[i].ChuanDauRas = null;
            }
           
            ViewBag.muctieu = mucTieu;
            ViewBag.mamh = mamh;
            ViewBag.chuandaura = chuanDauRas;
            return View();
        }
        [HttpPost]
        public IActionResult EditMuctieu(string[] Mota, string[] Daura,string MaMh,int[] id)
        {
           
            List<ChuanDauRa> chuanDauRas = _context.ChuanDauRas.Where(x => x.MaMh == MaMh).ToList();
            for(int i = 0; i < chuanDauRas.Count; i++)
            {
                try
                {
                    _context.Remove(chuanDauRas[i]);
                    _context.SaveChanges();
                }
                catch { }
                    }
           
            for (int i = 0; i < Mota.Length; i++)
            {

                if (Mota[i] != null)
                {
                    if(i<id.Length)
                    {
                        MucTieu mucTieu = _context.MucTieus.FirstOrDefault(x => x.Id == id[i]);
                        mucTieu.Mota = Mota[i].Trim();

                        try
                        {
                            _context.Update(mucTieu);
                            _context.SaveChanges();
                        }
                        catch { }
                        if (Daura[i] != null)
                        {
                            string[] daura = Daura[i].Split("\r\n");
                            daura = daura.Where(val => val != "").ToArray();
                            daura = daura.Where(val => val != " ").ToArray();
                            for (int j = 0; j < daura.Length; j++)
                            {
                                ChuanDauRa chuanDauRa = new ChuanDauRa();
                                chuanDauRa.Mota = daura[j].Trim();
                                chuanDauRa.MaMh = MaMh;
                                chuanDauRa.IdMuctieu = mucTieu.Id;
                                try
                                {
                                    _context.Add(chuanDauRa);
                                    _context.SaveChanges();
                                }
                                catch { }
                            }
                        }
                    }
                   
                   
                    else
                    {
                        MucTieu mucTieu1 = new MucTieu();
                        mucTieu1.Mota = Mota[i].Trim();
                        mucTieu1.MaMh = MaMh;
                        try
                        {
                            _context.Add(mucTieu1);
                            _context.SaveChanges();
                        }
                        catch { }
                        if (Daura[i] != null)
                        {
                            string[] daura = Daura[i].Split("\r\n");
                            daura = daura.Where(val => val != "").ToArray();
                            daura = daura.Where(val => val != " ").ToArray();
                            for (int j = 0; j < daura.Length; j++)
                            {
                                ChuanDauRa chuanDauRa = new ChuanDauRa();
                                chuanDauRa.Mota = daura[j].Trim();
                                chuanDauRa.MaMh = MaMh;
                                chuanDauRa.IdMuctieu = mucTieu1.Id;
                                try
                                {
                                    _context.Add(chuanDauRa);
                                    _context.SaveChanges();
                                }
                                catch { }
                            }
                        }
                    }
                    
                }



            }
            IEnumerable<KhoaHoc> khoahocs = _context.KhoaHocs.ToList();
            TempData["message"] = "Success";
            return RedirectToAction("Index", khoahocs);
        }
        public IActionResult EditNoidung(string mamh)
        {
            List<Chuong> chuongs= _context.Chuongs.Where(x => x.MaMh == mamh).ToList();
            List<string> lops = new List<string>();
            List<string> nhas = new List<string>();

            for (int i = 0; i < chuongs.Count; i++)
            {
                string a = "";
                string b = "";
                List<PhanCongLop> pclops = _context.PhanCongLops.Where(x => x.IdChuong == chuongs[i].Id).ToList();
                List<PhanCongNha> pcnhas = _context.PhanCongNhas.Where(x => x.IdChuong == chuongs[i].Id).ToList();
                for (int j = 0; j < pclops.Count; j++)
                {
                    a += pclops[j].Mota + '\n';
                }
                lops.Add(a);
                for (int j = 0; j < pcnhas.Count; j++)
                {
                    b += pcnhas[j].Mota + '\n';
                }
                nhas.Add(b);
                chuongs[i].PhanCongNhas = null;
                chuongs[i].PhanCongLops = null;
            }

            ViewBag.chuong = chuongs;
            ViewBag.phanconglop = lops;
            ViewBag.phancongnha = nhas;
            ViewBag.mamh = mamh;
            return View();
        }
        [HttpPost]
        public IActionResult EditNoidung(string[] Ten, string[] lop, string[] nha, int[] Tuan, string MaMh,int[] id)
        {
            List<Chuong> chuongs = _context.Chuongs.Where(x => x.MaMh == MaMh).ToList();
            for (int i = 0; i < chuongs.Count; i++)
            {
                List<PhanCongLop> lops = _context.PhanCongLops.Where(x => x.IdChuong == chuongs[i].Id).ToList();
                List<PhanCongNha> nhas = _context.PhanCongNhas.Where(x => x.IdChuong == chuongs[i].Id).ToList();
                for (int j = 0; j < lops.Count; j++)
                {
                    try
                    {
                        _context.Remove(lops[j]);
                        _context.SaveChanges();
                    }
                    catch { }
                }
                for (int j = 0; j < nhas.Count; j++)
                {
                    try
                    {
                        _context.Remove(nhas[j]);
                        _context.SaveChanges();
                    }
                    catch { }
                }
            }
                for (int i = 0; i < Ten.Length; i++)
            {


                int tuan = Tuan[i];
                if (Ten[i] != null)
                {
                    if(i<id.Length)
                    {
                        Chuong chuong = _context.Chuongs.FirstOrDefault(x => x.Id == id[i]);
                        chuong.Ten = Ten[i].Trim();
                        chuong.IdTuan = tuan;
                        try
                        {
                            _context.Update(chuong);
                            _context.SaveChanges();
                        }
                        catch { }
                        if (lop[i] != null)
                        {
                            string[] pclop = lop[i].Split("\r\n");
                            pclop = pclop.Where(val => val != "").ToArray();
                            pclop = pclop.Where(val => val != " ").ToArray();
                            for (int j = 0; j < pclop.Length; j++)
                            {
                                PhanCongLop phanCongLop = new PhanCongLop();
                                phanCongLop.Mota = pclop[j].Trim();
                                phanCongLop.IdChuong = chuong.Id;

                                try
                                {
                                    _context.Add(phanCongLop);
                                    _context.SaveChanges();
                                }
                                catch { }
                            }
                        }
                        if (nha[i] != null)
                        {
                            string[] pcnha = nha[i].Split("\r\n");
                            pcnha = pcnha.Where(val => val != "").ToArray();
                            pcnha = pcnha.Where(val => val != " ").ToArray();
                            for (int k = 0; k < pcnha.Length; k++)
                            {
                                PhanCongNha phanCongNha = new PhanCongNha();
                                phanCongNha.Mota = pcnha[k].Trim();
                                phanCongNha.IdChuong = chuong.Id;

                                try
                                {
                                    _context.Add(phanCongNha);
                                    _context.SaveChanges();
                                }
                                catch { }
                            }
                        }
                    }
                    
                  
                    else
                    {
                        Chuong chuong1 = new Chuong();
                        chuong1.Ten = Ten[i].Trim();
                        chuong1.MaMh = MaMh;
                        chuong1.IdTuan = tuan;
                        try
                        {
                            _context.Add(chuong1);
                            _context.SaveChanges();
                        }
                        catch { }
                        if (lop[i] != null)
                        {
                            string[] pclop = lop[i].Split("\r\n");
                            pclop = pclop.Where(val => val != "").ToArray();
                            pclop = pclop.Where(val => val != " ").ToArray();
                            for (int j = 0; j < pclop.Length; j++)
                            {
                                PhanCongLop phanCongLop = new PhanCongLop();
                                phanCongLop.Mota = pclop[j].Trim();
                                phanCongLop.IdChuong = chuong1.Id;

                                try
                                {
                                    _context.Add(phanCongLop);
                                    _context.SaveChanges();
                                }
                                catch { }
                            }
                        }
                        if (nha[i] != null)
                        {
                            string[] pcnha = nha[i].Split("\r\n");
                            pcnha = pcnha.Where(val => val != "").ToArray();
                            pcnha = pcnha.Where(val => val != " ").ToArray();
                            for (int k = 0; k < pcnha.Length; k++)
                            {
                                PhanCongNha phanCongNha = new PhanCongNha();
                                phanCongNha.Mota = pcnha[k].Trim();
                                phanCongNha.IdChuong = chuong1.Id;

                                try
                                {
                                    _context.Add(phanCongNha);
                                    _context.SaveChanges();
                                }
                                catch { }
                            }
                        }
                    }
                   
                    
                    
                   
                   
                }
               



            }
            IEnumerable<KhoaHoc> khoahocs = _context.KhoaHocs.ToList();
            TempData["message"] = "Success";
            return RedirectToAction("Index", khoahocs);
        }
        public IActionResult ImportPdf(IFormFile postedFile,int idkh,string idn)
        {
            string path = System.IO.Path.Combine(this.Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(postedFile.FileName);
            
            try
            {

                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
               
                   
               
            }
            catch
            {

              
                    
            }
            string currentText = string.Empty;
            var text = new StringBuilder();
            string[] newLines = null;
            string[] mota = null;
            string[] noidung = null;
            string[] muctieu = null;
            // byte[] bytes = System.IO.File.ReadAllBytes(System.IO.Path.Combine(path, fileName));
            PdfDocument pdfDocument = new PdfDocument(new PdfReader(path + '/' + fileName));
            // var doc = new PdfDocument(reader);
            var pageNumbers = pdfDocument.GetNumberOfPages();
            for (int i = 1; i <= pageNumbers; i++)
            {

                SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                PdfCanvasProcessor parser = new PdfCanvasProcessor(strategy);
                parser.ProcessPageContent(pdfDocument.GetPage(i));
                text.Append(strategy.GetResultantText());

                string[] tokens = text.ToString().Split(new[] { "5. Nội dung môn học:" }, StringSplitOptions.None);

                mota = tokens[0].Split(new[] { "4. Mô tả môn học:" }, StringSplitOptions.None);
                noidung = tokens[1].Split(new[] { "6. Mục tiêu môn học:" }, StringSplitOptions.None);
                muctieu = noidung[1].Split(new[] { "7. Chuẩn đầu ra môn học:" }, StringSplitOptions.None);
                text.ToString().Split('\n');
                currentText = text.ToString();
                newLines = currentText.Split('\n');
            }
            string mamh = newLines[1].Split(':')[1];
            if (_context.MonHocs.Where(m => m.MaMh == mamh.Trim()).Count() > 0)
            {
                IEnumerable<KhoaHoc> khoahocs = _context.KhoaHocs.ToList();
                TempData["message"] = "Import Fail!!!";
                return RedirectToAction("Index",khoahocs);
            }
            string ten = newLines[2].Split(':')[1];
            int sotinchi = Convert.ToInt32(newLines[3].Split(':')[1]);
            string motamh = mota[1].Split('\n')[1];
            string[] ndmh = noidung[0].Split('\n');
            ndmh = ndmh.Where(val => val != "").ToArray();
            ndmh = ndmh.Where(val => val != " ").ToArray();
            string[] mtmh = muctieu[0].Split('\n');
            mtmh = mtmh.Where(val => val != "").ToArray();
            mtmh = mtmh.Where(val => val != " ").ToArray();
            string[] daura = muctieu[1].Split('\n');
            daura = daura.Where(val => val != "").ToArray();
            daura = daura.Where(val => val != " ").ToArray();
            //string chuong = ndmh[1].Split(' ')[1];
            string[] chuong = new string[20];
            string[] pclop = new string[20];
            string[] pcnha = new string[20];
            string[] mt = new string[20];
            int[] mtdr = new int[20];
            int[] idmtdr = new int[20];
            string[] dr = new string[20];
            chuong[0] = "";
            pclop[0] = "";
            pcnha[0] = "";
            mt[0] = "";
            dr[0] = "";
            string[] a = mtmh[1].Split(' ');
            idmtdr[0] = Convert.ToInt32(a[0]);
            for (int j = 1; j < a.Length; j++)
            {
                mt[0] += a[j] + " ";
            }
            string[] c = daura[1].Split(' ');
            mtdr[0] = Convert.ToInt32(c[0]);
            for (int j = 2; j < c.Length; j++)
            {
                dr[0] += c[j] + " ";
            }
            int sochuong = 0;
            int solop = 0;
            int sonha = 0;
            int somt = 0;
            int sodr = 0;
            int somtdr = 0;
            int soidmtdr = 0;
            //int dem=1 ;
            for (int j = 1; j < ndmh.Length; j++)
            {
                if (ndmh[j].Trim() != "Nội dung GD tại lớp:" && ndmh[j].Trim() != "Nội dung tại nhà:")
                {
                    chuong[sochuong] += ndmh[j] + " ";
                }
                if (ndmh[j].Trim() == "Nội dung GD tại lớp:")
                {
                    sochuong++;
                    chuong[sochuong] = "";
                    for (int k = j + 1; k < ndmh.Length; k++)
                    {
                        if (ndmh[k].Trim() != "Nội dung tại nhà:")
                        {
                            pclop[solop] += ndmh[k] + " ";
                        }

                        if (ndmh[k].Trim() == "Nội dung tại nhà:")
                        {

                            j = k;
                            solop++;
                            pclop[solop] = "";
                            break;


                        }
                    }

                }
                if (ndmh[j].Trim() == "Nội dung tại nhà:")

                {
                    for (int l = j + 1; l < ndmh.Length; l++)
                    {

                        if (int.TryParse(ndmh[l].Split(' ')[0], out var parsedNumber))

                        {
                            sonha++;
                            pcnha[sonha] = "";
                            j = l - 1;
                            break;
                        }

                        else
                        {
                            pcnha[sonha] += ndmh[l] + " ";
                        }
                        if (l == ndmh.Length - 1)
                        {
                            j = l;
                        }

                    }
                }

            }
            for (int i = 2; i < mtmh.Length; i++)
            {

                if (!int.TryParse(mtmh[i].Split(' ')[0], out var parsedNumber))

                {
                    mt[somt] += mtmh[i] + " ";
                }
                else
                {
                    somt++;
                    soidmtdr++;
                    string[] b = mtmh[i].Split(' ');
                    mt[somt] = "";
                    idmtdr[soidmtdr] = Convert.ToInt32(b[0]);
                    for (int j = 1; j < b.Length; j++)
                    {
                        mt[somt] += b[j] + " ";
                    }

                }
            }

            for (int i = 2; i < daura.Length; i++)
            {

                if (!int.TryParse(daura[i].Split(' ')[0], out var parsedNumber))

                {
                    dr[sodr] += daura[i] + " ";
                }
                else
                {
                    sodr++;
                    somtdr++;
                    string[] d = daura[i].Split(' ');
                    dr[sodr] = "";
                    mtdr[somtdr] = Convert.ToInt32(d[0]);
                    for (int j = 2; j < d.Length; j++)
                    {
                        dr[sodr] += d[j] + " ";
                    }

                }
            }
            chuong = chuong.Where(val => val != "").ToArray();
            pclop = pclop.Where(val => val != "").ToArray();
            pcnha = pcnha.Where(val => val != "").ToArray();
            string[] chuongs = new string[20];
            int[] tuan = new int[20];
            chuongs[0] = "";
            int soc = 0;
            int sotuan = 0;
            MonHoc monHoc = new MonHoc();
            monHoc.MaMh = mamh.Trim();
            monHoc.Ten = ten.Trim();
            monHoc.Sotinchi = sotinchi;
            monHoc.Mota = motamh.Trim();
            try
            {
                _context.Add(monHoc);
                _context.SaveChanges();
            }
            catch { }
            MonKhoa monkhoa = new MonKhoa();
            monkhoa.MaMh = mamh.Trim();
            monkhoa.IdKhoahoc = idkh;
          monkhoa.Manganh = idn;
            try
            {
                _context.Add(monkhoa);
                _context.SaveChanges();
            }
            catch { }
           
            for (int i = 0; i < mt.Length; i++)
            {
                if (mt[i] == null)
                {
                    break;
                }
                MucTieu mucTieu = new MucTieu();
                mucTieu.MaMh = mamh.Trim();

                mucTieu.Mota = mt[i].Trim();
                try
                {
                    _context.Add(mucTieu);
                    _context.SaveChanges();
                }
                catch { }
                for (int j = 0; j < mtdr.Length; j++)
                {
                    if (mtdr[j] == 0)
                    {
                        break;
                    }
                    if (mtdr[j] == idmtdr[i])
                    {
                        mtdr[j] = mucTieu.Id;
                    }
                }
            }
            for (int i = 0; i < dr.Length; i++)
            {
                if (dr[i] == null)
                {
                    break;
                }
                ChuanDauRa chuanDauRa = new ChuanDauRa();
                chuanDauRa.MaMh = mamh.Trim();
                chuanDauRa.IdMuctieu = mtdr[i];
                chuanDauRa.Mota = dr[i].Trim();
                try
                {
                    _context.Add(chuanDauRa);
                    _context.SaveChanges();
                }
                catch { }
            }
            for (int i = 0; i < chuong.Length; i++)
            {
                if (chuong[i] == null)
                {
                    break;
                }
                string[] e = chuong[i].Split(' ');
                tuan[sotuan] = Convert.ToInt32(e[0]);
                for (int j = 1; j < e.Length; j++)
                {
                    chuongs[soc] += e[j] + " ";
                }
                Chuong chuong1 = new Chuong();
                chuong1.Ten = chuongs[soc].Trim();
                chuong1.IdTuan = tuan[sotuan];
                chuong1.MaMh = mamh.Trim();
                try
                {
                    _context.Add(chuong1);
                    _context.SaveChanges();
                }
                catch { }
                soc++;
                sotuan++;
                chuongs[soc] = "";
                string[] f = pclop[i].Split('+');
                f = f.Where(val => val != "").ToArray();
                for (int k = 0; k < f.Length; k++)
                {
                    PhanCongLop lop = new PhanCongLop();
                    lop.Mota = f[k].Trim();
                    lop.IdChuong = chuong1.Id;

                    try
                    {
                        _context.Add(lop);
                        _context.SaveChanges();
                    }
                    catch { }
                }
                string[] g = pcnha[i].Split('+');
                g = g.Where(val => val != "").ToArray();
                for (int l = 0; l < g.Length; l++)
                {
                    PhanCongNha nha = new PhanCongNha();
                    nha.Mota = g[l].Trim();
                    nha.IdChuong = chuong1.Id;

                    try
                    {
                        _context.Add(nha);
                        _context.SaveChanges();
                    }
                    catch { }
                }

            }
            IEnumerable<KhoaHoc> khoahoc = _context.KhoaHocs.ToList();
            TempData["message"] = "Import Success!!!";
            return RedirectToAction("Index", khoahoc);
           
        }

    }
}
