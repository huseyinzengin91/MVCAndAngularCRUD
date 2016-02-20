using MVCAndAngularCRUD.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCAndAngularCRUD.Controllers
{
    public class HomeController : Controller
    {
        public static List<Book> bookList;
        private int lastID = 0;

        public HomeController()
        {
            if (bookList == null)
            {
                bookList = new Book().GetSampleBookList();
            }
            lastID = bookList.Last().ID + 1;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetBookList()
        {
            return Json(bookList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void DeleteBooks(List<int> ID)
        {
            if (ID != null)
            {
                foreach (int item in ID)
                {
                    bookList.Remove(bookList.First(z => z.ID == item));
                }
            }
        }

        [HttpPost]
        public int NewBook(Book book)
        {
            book.ID = lastID;
            bookList.Add(book);

            return lastID;
        }
    }
}