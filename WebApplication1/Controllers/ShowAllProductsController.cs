using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Utility;

namespace WebApplication1.Controllers
{
    public class ShowAllProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShowAllProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShowAllProducts
        [HttpGet]
        public IActionResult Index()
        {
            return View( _context.Good.ToList());
        }

        //============= for Search Post --------------
        [HttpPost]
        public IActionResult Index(decimal? lowAmount,decimal? largeAmount)
        {
            ViewData["Idoffers"] = new SelectList(_context.Offers, "Id", "Id");
            var products = _context.Good.Where(c=>c.Price>=lowAmount &&
            c.Price<=largeAmount ).ToList();
            if(lowAmount==null || largeAmount==null)
            {
                products = _context.Good.ToList();
            }
            return View(products);
        }

        //=================== Details
        //[HttpGet]
        //public IActionResult Details()
        //{
        //    return View();
        //}

        //[HttpPost]
        public IActionResult Detail(int? id)
        {
            var pro = _context.Good.Find(id);
            if(pro==null)
            {
                return RedirectToAction("Index");
            }
            return View(pro);
        }
        //===============================
        [HttpPost]
        [ActionName("Detail")]
        public IActionResult ProductDetail(int? id)
        {
            List<Good> products = new List<Good>();
            var pro = _context.Good.Find(id);

            products = HttpContext.Session.Get<List<Good>>("products");
            if(products==null)
            {
                products = new List<Good>();
            }

            products.Add(pro);
            HttpContext.Session.Set("products", products);
            // return View(pro);  // if i want remain in the same page details
            return RedirectToAction(nameof(Index));   // if i want to move into index page  
        }

        //======== remove any products 
        [HttpPost]
        public IActionResult Remove( int? id)
        {
            List<Good> products = HttpContext.Session.Get<List<Good>>("products");
            if(products!=null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if(product!=null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }


        //======== remove any products  from checkout --- Cart ---
        [ActionName("Remove")]
        public IActionResult RemoveToCart(int? id)
        {
            List<Good> products = HttpContext.Session.Get<List<Good>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        //============== display all products in cart 
        public IActionResult Cart()
        {
            List<Good> products = HttpContext.Session.Get<List<Good>>("products");
            if(products==null)
            {
                products = new List<Good>();
            }
            return View(products);
        }
    }
}
