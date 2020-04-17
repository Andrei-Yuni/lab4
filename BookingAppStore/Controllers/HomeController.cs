using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingAppStore.Models;

namespace BookingAppStore.Controllers
{
     public class HomeController : Controller
     {
          BookContext db = new BookContext();
          public ActionResult Index()
          {
               var books = db.Books;
               ViewBag.Books = books;
               return View();
          }
         
          [HttpGet]
          public ActionResult Create()
          {
               return View();
          }
          [HttpPost]
          public ActionResult Create(Book book)
          {
               db.Books.Add(book);
               db.SaveChanges();

               return RedirectToAction("Index");
          }

         

          [HttpGet]
          public ActionResult Delete(int id)
          {
               Book b = db.Books.Find(id);
               if (b == null)
               {
                    return HttpNotFound();
               }
               return View(b);
          }
          [HttpPost, ActionName("Delete")]
          public ActionResult DeleteConfirmed(int id)
          {
               Book b = db.Books.Find(id);
               if (b == null)
               {
                    return HttpNotFound();
               }
               db.Books.Remove(b);
               db.SaveChanges();
               return RedirectToAction("Index");
          }

          [HttpGet]
          public ActionResult Buy(int id)
          {
               ViewBag.Books = id;
               return View();
          }
         
          [HttpPost]
          public string Buy(Purchase purchase)
          {
               purchase.Date = DateTime.Now;
               // добавляем информацию о покупке в базу данных
               db.Purchases.Add(purchase);
               // сохраняем в бд все изменения
               db.SaveChanges();
               return "Спасибо," + purchase.Person + ", за покупку!";
          }

          public ActionResult About()
          {
               ViewBag.Message = "Your application description page.";

               return View();
          }

          public ActionResult Contact()
          {
               ViewBag.Message = "Your contact page.";

               return View();
          }
     }
}