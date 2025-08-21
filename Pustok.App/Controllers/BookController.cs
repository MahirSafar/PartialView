using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.App.DAL.Context;

namespace Pustok.App.Controllers
{
    public class BookController(PustokDbContext pustokDbContext) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
                return NotFound("Book ID cannot be null");

            var book = pustokDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genre) 
                .Include(b => b.BookImages)
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound($"Book with ID {id} not found");

            return View(book);
        }
        //public IActionResult Test()
        //{
        //    var books = pustokDbContext.Books
        //        .Include(b => b.Author)
        //        .Include(b => b.Genre)
        //        .ToList();
        //    return PartialView("_BooksPartial",books);
        //}
    }
}
