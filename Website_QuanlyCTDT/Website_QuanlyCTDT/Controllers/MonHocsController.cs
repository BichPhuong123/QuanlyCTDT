using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Tables;
using Website_QuanlyCTDT.Models;

namespace Website_QuanlyCTDT.Controllers
{
    public class MonHocsController : Controller
    {
        private readonly QuanLyCTDTContext _context;

        public MonHocsController(QuanLyCTDTContext context)
        {
            _context = context;
        }

        // GET: KhoaHocs
        public async Task<IActionResult> Index()
        {
            IEnumerable<KhoaHoc> khoahoc = await _context.KhoaHocs.ToListAsync();
            return View(khoahoc);
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
        // GET: KhoaHocs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs
                .FirstOrDefaultAsync(m => m.MaMh == id);
            if (monHoc == null)
            {
                return NotFound();
            }
            List<Chuong> chuong = await _context.Chuongs.Where(c => c.MaMh == monHoc.MaMh).ToListAsync();

            List<List<PhanCongLop>> phanconglop = new List<List<PhanCongLop>>();
            List<List<PhanCongNha>> phancongnha = new List<List<PhanCongNha>>();
            for (int i = 0; i < chuong.Count; i++)
            {
                phanconglop.Add(await _context.PhanCongLops.Where(p => p.IdChuong == chuong[i].Id).ToListAsync());
                phancongnha.Add(await _context.PhanCongNhas.Where(p => p.IdChuong == chuong[i].Id).ToListAsync());
                chuong[i].MaMhNavigation = null;
                chuong[i].PhanCongLops = null;
                chuong[i].PhanCongNhas = null;
            }

            for (int j = 0; j < phanconglop.Count; j++)
            {
                for (int k = 0; k < phanconglop[j].Count; k++)
                {
                    phanconglop[j][k].IdChuongNavigation = null;
                }
            }
            ViewBag.monhoc = monHoc;
            ViewBag.chuong = chuong;
            ViewBag.phanconglop = phanconglop;
            ViewBag.phancongnha = phancongnha;
            return View();
        }
        [HttpPost]
        public ActionResult ExportPdf(string id)
        {
            MonHoc monHoc = _context.MonHocs.FirstOrDefault(m => m.MaMh == id);
            List<MucTieu> muctieu = _context.getMuctieuByMH(id).ToList();
           
            if (monHoc == null)
            {
                return NotFound();
            }
          
            List<Tuan> tuan = _context.Tuans.ToList();
          
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid.
            PdfGraphics graphics = page.Graphics;
            FileStream fontFileStream = new FileStream("font/ARIAL.TTF", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //Set the standard font
            PdfFont font = new PdfTrueTypeFont(fontFileStream, 13, PdfFontStyle.Regular);
            PdfFont font1 = new PdfTrueTypeFont(fontFileStream, 14, PdfFontStyle.Bold);
            PdfFont font2 = new PdfTrueTypeFont(fontFileStream, 13, PdfFontStyle.Bold);
          
            PdfTextElement element = new PdfTextElement("ĐỀ CƯƠNG CHI TIẾT", font1);
            PdfLayoutResult result = element.Draw(page, new PointF(10, 0));
            PdfTextElement element1 = new PdfTextElement("1. Mã môn học:" + monHoc.MaMh + "\n" + "2. Tên môn học:" + monHoc.Ten + "\n" + "3. Số tín chỉ: " + monHoc.Sotinchi + "\n" + "4. Mô tả môn học: \n" + monHoc.Mota +"\n"+ "5. Nội dung môn học:",font);
            PdfLayoutResult result1 = element1.Draw(page, new PointF(0, result.Bounds.Bottom + 10));
          
            PdfGrid pdfGrid = new PdfGrid();

            
            PdfGridColumn column1 = new PdfGridColumn(pdfGrid);
            column1.Width = 100;
            PdfGridColumn column2 = new PdfGridColumn(pdfGrid);
            column2.Width = 100;
            PdfGridColumn column3 = new PdfGridColumn(pdfGrid);
            column3.Width = 300;
            //Add three columns.
            pdfGrid.Columns.Add(column1);
            pdfGrid.Columns.Add(column2);
            pdfGrid.Columns.Add(column3);
            pdfGrid.Headers.Add(1);
            PdfGridRow pdfGridHeader = pdfGrid.Headers[0];
            pdfGridHeader.Cells[0].Value = "Tuần";
            pdfGridHeader.Cells[1].Value = "Chương";
            pdfGridHeader.Cells[2].Value = "Nội dung";
           
            for(int i=0;i<tuan.Count;i++)
            {
                List<Chuong> chuong = _context.Chuongs.Where(c => c.MaMh == monHoc.MaMh && c.IdTuan==tuan[i].Id).ToList();
                if(chuong.Count!=0)
                {
                    pdfGrid.Rows.Add().Cells[0].Value = tuan[i].Ten + "\n";

                    if (chuong.Count != 0)
                    {
                        pdfGrid.Rows[i].Cells[2].Value = "Nội dung GD tại lớp: \n";
                        List<List<PhanCongLop>> phanconglop = new List<List<PhanCongLop>>();

                        List<List<PhanCongNha>> phancongnha = new List<List<PhanCongNha>>();
                        for (int j = 0; j < chuong.Count; j++)
                        {

                            phanconglop.Add(_context.PhanCongLops.Where(p => p.IdChuong == chuong[j].Id).ToList());
                            phancongnha.Add(_context.PhanCongNhas.Where(p => p.IdChuong == chuong[j].Id).ToList());
                            pdfGrid.Rows[i].Cells[1].Value += chuong[j].Ten + "\n";

                        }
                        for (int k = 0; k < phanconglop.Count; k++)
                        {
                            for (int l = 0; l < phanconglop[k].Count; l++)
                            {
                                pdfGrid.Rows[i].Cells[2].Value += "+ " + phanconglop[k][l].Mota + " \n";
                            }
                        }
                        pdfGrid.Rows[i].Cells[2].Value += "Nội dung tại nhà: \n";
                        for (int m = 0; m < phancongnha.Count; m++)
                        {
                            for (int n = 0; n < phancongnha[m].Count; n++)
                            {
                                pdfGrid.Rows[i].Cells[2].Value += "+ " + phancongnha[m][n].Mota + " \n";
                            }
                        }
                    }
                }
               
                
                
            }
          
            pdfGrid.Style.Font = font;
            pdfGrid.Style.CellPadding.All = 3;
            pdfGridHeader.Style.Font = font2;

            PdfLayoutResult res = pdfGrid.Draw(page, new PointF(10, result1.Bounds.Bottom + 20));
            PdfTextElement e = new PdfTextElement("6. Mục tiêu môn học:", font);
            PdfLayoutResult r = e.Draw(page, new PointF(10, res.Bounds.Bottom + 20));
            PdfGrid pdfGrid1 = new PdfGrid();


            PdfGridColumn column4 = new PdfGridColumn(pdfGrid1);
            column4.Width = 100;
            PdfGridColumn column5 = new PdfGridColumn(pdfGrid1);
            column5.Width = 400;
          
            //Add three columns.
            pdfGrid1.Columns.Add(column4);
            pdfGrid1.Columns.Add(column5);
         
            pdfGrid1.Headers.Add(1);
            PdfGridRow pdfGridHeader1 = pdfGrid1.Headers[0];
            pdfGridHeader1.Cells[0].Value = "Mục tiêu";
            pdfGridHeader1.Cells[1].Value = "Mô tả";
            for (int i = 0; i < muctieu.Count; i++)
            {
                pdfGrid1.Rows.Add().Cells[0].Value = i +1 + "\n";
                pdfGrid1.Rows[i].Cells[1].Value = muctieu[i].Mota + "\n";
            }
            pdfGrid1.Style.Font = font;
            pdfGrid1.Style.CellPadding.All = 3;
            pdfGridHeader1.Style.Font = font2;

            PdfLayoutResult resul = pdfGrid1.Draw(page, new PointF(10, r.Bounds.Bottom + 20));
            PdfTextElement el = new PdfTextElement("7. Chuẩn đầu ra môn học:", font);
            PdfLayoutResult re = el.Draw(page, new PointF(10, resul.Bounds.Bottom + 20));

            PdfGrid pdfGrid2 = new PdfGrid();

            PdfGridColumn column6 = new PdfGridColumn(pdfGrid2);
            column6.Width = 100;
            PdfGridColumn column7 = new PdfGridColumn(pdfGrid2);
            column7.Width = 100;
            PdfGridColumn column8 = new PdfGridColumn(pdfGrid2);
            column8.Width = 300;

            //Add three columns.
            pdfGrid2.Columns.Add(column6);
            pdfGrid2.Columns.Add(column7);
            pdfGrid2.Columns.Add(column8);

            pdfGrid2.Headers.Add(1);
            PdfGridRow pdfGridHeader2 = pdfGrid2.Headers[0];
            pdfGridHeader2.Cells[0].Value = "Mục tiêu";
            pdfGridHeader2.Cells[1].Value = "Chuẩn đầu ra";
            pdfGridHeader2.Cells[2].Value = "Mô tả";
            int total = 0;
            for (int i = 0; i < muctieu.Count; i++)
            {
                List<ChuanDauRa> chuandaura = _context.ChuanDauRas.Where(m => m.MaMh == id && m.IdMuctieu ==muctieu[i].Id).ToList();
                if(chuandaura.Count !=0)
                {
                    pdfGrid2.Rows.Add().Cells[0].Value = i + 1 + "\n";
                    pdfGrid2.Rows[i].Cells[0].RowSpan = chuandaura.Count;
                    pdfGrid2.Rows[total].Cells[1].Value = total + 1 + "\n";
                    pdfGrid2.Rows[total].Cells[2].Value = chuandaura[0].Mota + "\n";
                    total++;
                    for (int j = 1; j < chuandaura.Count; j++)
                    {
                        pdfGrid2.Rows.Add().Cells[1].Value = total + 1 + "\n";
                        //pdfGrid2.Rows[total].Cells[1].Value = total + 1 + "\n";
                        pdfGrid2.Rows[total].Cells[2].Value = chuandaura[j].Mota + "\n";

                        total++;
                    }
                }

                

            }
            pdfGrid2.Style.Font = font;
            pdfGrid2.Style.CellPadding.All = 3;
            pdfGridHeader2.Style.Font = font2;

            PdfLayoutResult result2 = pdfGrid2.Draw(page, new PointF(10, re.Bounds.Bottom + 20));
          
            //PdfLightTable pdfLightTable = new PdfLightTable();

            ////Set the Data source as direct
            //pdfLightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;

            ////Create columns
            //pdfLightTable.Columns.Add(new PdfColumn("Tuần"));
            //pdfLightTable.Columns.Add(new PdfColumn("Nội dung"));
            //for (int i = 0; i < chuong.Count; i++)
            //{
            //  //  pdfLightTable.Rows[i].Values = 
            //  //  List <PhanCongLop> phanconglop = _context.PhanCongLops.Where(p => p.IdChuong == chuong[i].Id).ToList();
            //  //  List<PhanCongNha> phancongnha = _context.PhanCongNhas.Where(p => p.IdChuong == chuong[i].Id).ToList();
            //  //for(int j =0;j <=phanconglop.Count;j++)
            //  //  {

            //  //  }
            //}

            ////Add rows

            ////Draw grid to the page of PDF document.
            //pdfLightTable.Draw(page, new PointF(10, result.Bounds.Bottom + 10));
            //Save the PDF document to stream
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            doc.Close(true);


            //Creates a FileContentResult object by using the file contents, content type, and file name.
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf;charset=utf-8");
            fileStreamResult.FileDownloadName = "Sample.pdf";

            return fileStreamResult;
        }
        public async Task<IActionResult> Muctieu(string id)
        {
            List<MucTieu> muctieu = await _context.MucTieus.Where(c => c.MaMh == id).ToListAsync();
            List<ChuanDauRa> daura = _context.ChuanDauRas.Where(c => c.MaMh == id).ToList();
            List<ChuanDauRa> dauras = daura;
            for (int i = 0; i < muctieu.Count; i++)
            {


                for (int j = 0; j < daura.Count; j++)
                {
                    if (daura[j].IdMuctieu == muctieu[i].Id)
                    {
                        dauras[j].IdMuctieu = i;
                        dauras[j].IdMuctieuNavigation = null;
                    }
                 
                }

            }
                    
            ViewBag.muctieu = muctieu;
            ViewBag.daura = dauras;
            return View();
        }
        // GET: KhoaHocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoaHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenKh")] KhoaHoc khoaHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khoaHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoaHoc);
        }

        // GET: KhoaHocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoaHoc = await _context.KhoaHocs.FindAsync(id);
            if (khoaHoc == null)
            {
                return NotFound();
            }
            return View(khoaHoc);
        }

        // POST: KhoaHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenKh")] KhoaHoc khoaHoc)
        {
            if (id != khoaHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoaHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoaHocExists(khoaHoc.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(khoaHoc);
        }

        // GET: KhoaHocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoaHoc = await _context.KhoaHocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khoaHoc == null)
            {
                return NotFound();
            }

            return View(khoaHoc);
        }

        // POST: KhoaHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khoaHoc = await _context.KhoaHocs.FindAsync(id);
            _context.KhoaHocs.Remove(khoaHoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoaHocExists(int id)
        {
            return _context.KhoaHocs.Any(e => e.Id == id);
        }
    }
}
