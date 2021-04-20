using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Admin_GoodsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public Admin_GoodsController(ApplicationDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Admin_Goods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Good.ToListAsync());
        }

        // GET: Admin_Goods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Good
                .FirstOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // GET: Admin_Goods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin_Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idtg,Name,Quantity,Size,Price,ExpireDate,ImagePath,Idoffers")] Good good)
        {
            if (ModelState.IsValid)
            {
                string wwwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(good.ImagePath.FileName);
                string extentions = Path.GetExtension(good.ImagePath.FileName);
                good.Images= fileName = fileName + DateTime.Now.ToString("yyymmss") + extentions;
                string path = Path.Combine(wwwwRootPath + "/image", fileName);
                using (var fileStram = new FileStream(path,FileMode.Create))
                {
                    await good.ImagePath.CopyToAsync(fileStram);
                }

                _context.Add(good);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(good);
        }

        // GET: Admin_Goods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Good.FindAsync(id);
            if (good == null)
            {
                return NotFound();
            }
            return View(good);
        }

        // POST: Admin_Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idtg,Name,Quantity,Size,Price,ExpireDate,Images,Idoffers")] Good good)
        {
            if (id != good.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   

                    _context.Update(good);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodExists(good.Id))
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
            return View(good);
        }

        // GET: Admin_Goods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Good
                .FirstOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // POST: Admin_Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var good = await _context.Good.FindAsync(id);



            //delete image from wwwroot//image
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", good.Images);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);


            //delete from database
            _context.Good.Remove(good);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodExists(int id)
        {
            return _context.Good.Any(e => e.Id == id);
        }
    }
}
