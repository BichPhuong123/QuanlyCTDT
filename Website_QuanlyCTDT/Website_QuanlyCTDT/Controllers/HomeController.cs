using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;


using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Syncfusion.Drawing;

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Tables;
using Website_QuanlyCTDT.Models;

namespace Website_QuanlyCTDT.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment Environment;
        private readonly QuanLyCTDTContext _context;
        public HomeController(IHostingEnvironment _environment, QuanLyCTDTContext context)
        {
            Environment = _environment;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ImportPdf(IFormFile postedFile)
        {
            string path = System.IO.Path.Combine(this.Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = System.IO.Path.GetFileName(postedFile.FileName);
            using (FileStream stream = new FileStream(System.IO.Path.Combine(path, fileName), FileMode.Create))
            {
                postedFile.CopyTo(stream);
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
                return View();
            }
            string ten = newLines[2].Split(':')[1];
            int sotinchi = Convert.ToInt32(newLines[3].Split(':')[1]);
            string motamh = mota[1].Split('\n')[1];
            string[] ndmh = noidung[0].Split('\n');
            ndmh = ndmh.Where(val => val != "").ToArray();
            string[] mtmh = muctieu[0].Split('\n');
            mtmh = mtmh.Where(val => val != "").ToArray();
            string[] daura = muctieu[1].Split('\n');
            daura = daura.Where(val => val != "").ToArray();
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
            mtdr[0] = Convert.ToInt32(c[9]);
            for (int j = 10; j < c.Length; j++)
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
                if (ndmh[j] != "Nội dung GD tại lớp:" && ndmh[j] != "Nội dung tại nhà:")
                {
                    chuong[sochuong] += ndmh[j] + " ";
                }
                if (ndmh[j] == "Nội dung GD tại lớp:")
                {
                    sochuong++;
                    chuong[sochuong] = "";
                    for (int k = j + 1; k < ndmh.Length; k++)
                    {
                        if (ndmh[k] != "Nội dung tại nhà:")
                        {
                            pclop[solop] += ndmh[k] + " ";
                        }

                        if (ndmh[k] == "Nội dung tại nhà:")
                        {

                            j = k;
                            solop++;
                            pclop[solop] = "";
                            break;


                        }
                    }

                }
                if (ndmh[j] == "Nội dung tại nhà:")

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
                    if(mtdr[j] ==0)
                    {
                        break;
                    }
                    if(mtdr[j]==idmtdr[i])
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
            for (int i=0;i<chuong.Length;i++)
            {
                if(chuong[i]==null)
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
                string[] f= pclop[i].Split('+');
                f = f.Where(val => val != "").ToArray();
                for (int k = 0; k < f.Length; k++)
                {
                    PhanCongLop lop = new PhanCongLop();
                    lop.Mota= f[k].Trim();
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
            return View();
        }
            //[HttpPost]
        //public ActionResult ExportPdf()
        //{
        //    //Create a new PDF document.
        //    PdfDocument doc = new PdfDocument();
        //    //Add a page.
        //    PdfPage page = doc.Pages.Add();
        //    //Create a PdfGrid.
        //    PdfGraphics graphics = page.Graphics;

        //    //Set the standard font
        //    PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
        //    PdfPen pen = new PdfPen(Color.Black, 1f);
        //    PdfStringFormat format = new PdfStringFormat();
        //    format.Alignment = PdfTextAlignment.Center;
        //    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
        //    PdfTextElement element = new PdfTextElement("INVOICE",font);
        //    element.StringFormat = format;
        //    PdfLayoutResult result = element.Draw(page, new PointF(0, 0));
        //    //Draw the text
        //    //graphics.DrawString("Hello World!!! \n\n", font, PdfBrushes.Black, new PointF(0, 0));
        //    PdfLightTable pdfLightTable = new PdfLightTable();

        //    //Set the Data source as direct
        //    pdfLightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;

        //    //Create columns
        //    pdfLightTable.Columns.Add(new PdfColumn("Roll Number"));
        //    pdfLightTable.Columns.Add(new PdfColumn("Name"));
        //    pdfLightTable.Columns.Add(new PdfColumn("Class"));

        //    //Add rows
        //   pdfLightTable.Rows.Add(new object[] { "111", "Maxim", "III" });
        //    //pdfLightTable.Rows[0].Values = new object[] { "222" };
        //    //pdfLightTable.Rows[0].Values = new object[] { "", "abc", "" };
        //    //pdfLightTable.Rows[0].Values = new object[] { "", "", "abc" };
        //    //Draw grid to the page of PDF document.
        //    pdfLightTable.Draw(page, new PointF(10, result.Bounds.Bottom + 10));
        //    //Save the PDF document to stream
        //    MemoryStream stream = new MemoryStream();
        //    doc.Save(stream);
        //    //If the position is not set to '0' then the PDF will be empty.
        //    stream.Position = 0;
        //    //Close the document.
        //    doc.Close(true);
           

        //    //Creates a FileContentResult object by using the file contents, content type, and file name.
        //    FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
        //    fileStreamResult.FileDownloadName = "Sample.pdf";

        //    return fileStreamResult;
        //}
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
