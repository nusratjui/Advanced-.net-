using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Product_Vone.Models.Entities;
using System.Data.SqlClient;
using Product_Vone.Models;

namespace Product_Vone.Controllers
{
    public class ProductController : Controller
    {
        
        public ActionResult Index()
        {
            Database db = new Database();
            var products = db.Products.Get();
            return View(products);
       
        }
        [HttpGet]
        public ActionResult Create()
        {
            Product p = new Product();
            return View(p);
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Create(p);
                
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Database db = new Database();
            var s = db.Products.Get(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
             Database db = new Database();
             db.Products.Edit(p);
             return RedirectToAction("Index");          
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Database db = new Database();
            var p = db.Products.Delete(id);
            return RedirectToAction("Index");
        }
    }
}