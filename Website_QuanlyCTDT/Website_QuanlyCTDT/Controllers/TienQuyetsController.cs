using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Website_QuanlyCTDT.Models;

namespace Website_QuanlyCTDT.Controllers
{
    public class TienQuyetsController : Controller
    {
        private readonly QuanLyCTDTContext _context;

        public TienQuyetsController(QuanLyCTDTContext context)
        {
            _context = context;
        }

        // GET: TienQuyets
        public async Task<IActionResult> Index()
        {
            List<getMHhasTQ__Result> listmon = _context.getMHhasTQ().ToList();
            List<IEnumerable<getMHTQ_Result>> mhtq = new List<IEnumerable<getMHTQ_Result>>();
            for (int i=0;i<listmon.Count;i++)
            {
                mhtq.Add(_context.getMHTQ(listmon[i].maMH).ToList());
            }
            //var quanLyCTDTContext = _context.MhtienQuyets.Include(m => m.MaMhNavigation).Include(m => m.MaMhtqNavigation);
            ViewBag.listmon = listmon;
            ViewBag.mhtq = mhtq;
            return View();
        }

        // GET: TienQuyets/Details/5
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

            return View(monHoc);
        }

        // GET: TienQuyets/Create
        public IActionResult Create()
        {
            ViewData["MaMh"] = new SelectList(_context.MonHocs, "MaMh", "MaMh");
            ViewData["MaMhtq"] = new SelectList(_context.MonHocs, "MaMh", "MaMh");
            return View();
        }

        // POST: TienQuyets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaMh,MaMhtq")] MhtienQuyet mhtienQuyet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mhtienQuyet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaMh"] = new SelectList(_context.MonHocs, "MaMh", "MaMh", mhtienQuyet.MaMh);
            ViewData["MaMhtq"] = new SelectList(_context.MonHocs, "MaMh", "MaMh", mhtienQuyet.MaMhtq);
            return View(mhtienQuyet);
        }

        // GET: TienQuyets/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mhtienQuyet = await _context.MhtienQuyets.FindAsync(id);
            if (mhtienQuyet == null)
            {
                return NotFound();
            }
            ViewData["MaMh"] = new SelectList(_context.MonHocs, "MaMh", "MaMh", mhtienQuyet.MaMh);
            ViewData["MaMhtq"] = new SelectList(_context.MonHocs, "MaMh", "MaMh", mhtienQuyet.MaMhtq);
            return View(mhtienQuyet);
        }

        // POST: TienQuyets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaMh,MaMhtq")] MhtienQuyet mhtienQuyet)
        {
            if (id != mhtienQuyet.MaMh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mhtienQuyet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MhtienQuyetExists(mhtienQuyet.MaMh))
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
            ViewData["MaMh"] = new SelectList(_context.MonHocs, "MaMh", "MaMh", mhtienQuyet.MaMh);
            ViewData["MaMhtq"] = new SelectList(_context.MonHocs, "MaMh", "MaMh", mhtienQuyet.MaMhtq);
            return View(mhtienQuyet);
        }

        // GET: TienQuyets/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mhtienQuyet = await _context.MhtienQuyets
                .Include(m => m.MaMhNavigation)
                .Include(m => m.MaMhtqNavigation)
                .FirstOrDefaultAsync(m => m.MaMh == id);
            if (mhtienQuyet == null)
            {
                return NotFound();
            }

            return View(mhtienQuyet);
        }

        // POST: TienQuyets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mhtienQuyet = await _context.MhtienQuyets.FindAsync(id);
            _context.MhtienQuyets.Remove(mhtienQuyet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MhtienQuyetExists(string id)
        {
            return _context.MhtienQuyets.Any(e => e.MaMh == id);
        }
    }
}
