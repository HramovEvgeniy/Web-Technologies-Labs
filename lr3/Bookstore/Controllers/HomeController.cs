using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    
    public class HomeController : Controller
    {
        // создаем контекст данных
        BookContext db = new BookContext();
        ////errors
        // добавляем 2 метода для buy
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Buycomplete(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            ViewBag.Message = "Спасибо," + purchase.Person + ", за покупку!";
            //return View();
            return RedirectToAction("Index");
        }
        //Добавление данных
        //возврат представления с формой для добавления данных
        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }
        //прием даных для добавления
        [HttpPost]
        public ActionResult AddNew(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //удаление данных
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //находим и передаём удаляемый объект в представление 
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        //атерибут ActionName("Delete") указывает, что приведённый ниже метод
        //воспринимается как "Delete"
        //доделать так, чтобы не было 404 ошибки
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            //удаление объекта с сохранением изменений в БД
            db.Books.Remove(b);
            db.SaveChanges();
            //изменить
            return RedirectToAction("Index");
        }

        //редактирование данных
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return HttpNotFound();
        }
        [HttpPost]
        //EditBook
        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Book> books = db.Books;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = books;
            // возвращаем представление
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница с описанием.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница обратной звязи";

            return View();
        }
    }
}