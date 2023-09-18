
using KNILA.Data;
using KNILA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace KNILA.Controllers
{
    public class BookController : Controller
    {
        public ApplicationDbContext _db;
        private SqlConnection _connection;
        public BookController(ApplicationDbContext db, IConfiguration configuration)
        {
            _db= db;
            _connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        }

        public IActionResult Index()
        {
            List<Book> book = _db.Books.ToList();

            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book obj)
        {

            if (ModelState.IsValid)
            {
                _db.Books.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Created Successfully";
                return RedirectToAction("Index");
            }

            return View();


        }

        public IActionResult Edit(int? bookId)
        {
            if (bookId is null || bookId == 0)
            {
                return NotFound();
            }


            Book book = _db.Books.FirstOrDefault(a => a.BookId == bookId);

            if (book is null)
            {
                return NotFound();
            }

            return View(book);

        }

        [HttpPost]
        public IActionResult Edit(Book obj)
        {

            if (ModelState.IsValid)
            {

                _db.Books.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Updated Successfully";

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? bookId)
        {

            if (bookId is null || bookId == 0)
            {
                return NotFound();
            }

            Book book = _db.Books.FirstOrDefault(a => a.BookId == bookId);

            if (book is null)
            {
                return NotFound();
            }

            return View(book);
        }



        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? bookId)
        {
            Book book = _db.Books.Find(bookId);


            if (book == null)
            {
                return NotFound();

            }

            _db.Remove(book);

            _db.SaveChanges();

            TempData["Success"] = "Deleted Successfully";

            return RedirectToAction("Index");
        }


     

    }
}
