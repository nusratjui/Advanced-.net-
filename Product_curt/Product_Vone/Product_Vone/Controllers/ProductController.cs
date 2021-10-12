using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Product_Vone.Models.Entities;
using System.Data.SqlClient;
using Product_Vone.Models;
using System.Web.Script.Serialization;

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
            var s = db.Products.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Shop()
        {
            Database db = new Database();
            var products = db.Products.Get();
            return View(products);
        }
        public ActionResult AddtoCart(int id)
        {
            Database db = new Database();
            var product = db.Products.Get(id);

            if (Session["cart"] == null)
            {
                List<Product> cartproduct = new List<Product>();
                cartproduct.Add(product);
                var json = new JavaScriptSerializer().Serialize(cartproduct);
                Session["cart"] = json;
                return RedirectToAction("Shop");
            }
            else
            {
                var cart = Session["cart"];
                var cartproduct = new JavaScriptSerializer().Deserialize<List<Product>>(cart.ToString());
                cartproduct.Add(product);
                var json = new JavaScriptSerializer().Serialize(cartproduct);
                Session["cart"] = json;
                return RedirectToAction("Shop");
            }
        }
        public ActionResult ShowCart()
        {
            if (Session["cart"]!= null)
            {
                var cart = Session["cart"];
                var productAddedToCart = new JavaScriptSerializer().Deserialize<List<Product>>(cart.ToString());
                return View(productAddedToCart);
            }
            else
            {return View();}
        }
        public ActionResult ConfirmOrder()
        {
            if (Session["cart"] != null)
            {
                Database db = new Database();
                var cart = Session["cart"];
                var productAddedToCart = new JavaScriptSerializer().Deserialize<List<Product>>(cart.ToString());
                Order order = null;
                foreach (var product in productAddedToCart)
                {
                    order = new Order();
                    order.Name = product.Name;
                    order.Price = product.Price;
                    order.ProductId = product.Id;
                    db.Order.Add(order);
                }
            }
            return RedirectToAction("Shop");
        }
        public ActionResult DeleteOrder(int id)
        {
            Database db = new Database();
            var p = db.Products.Get(id);
            var cart = Session["cart"];
            var cartproduct = new JavaScriptSerializer().Deserialize<List<Product>>(cart.ToString());
            var thing = cartproduct.SingleOrDefault(x => x.Id == id);
            if (thing != null)
                cartproduct.Remove(thing);

            var json = new JavaScriptSerializer().Serialize(cartproduct);
            Session["cart"] = json;
            return RedirectToAction("ShowCart");
        }
    }
}