using CnttLesson06lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesson06lab.Controllers
{
    public class BookController : Controller
    {
        protected Book book = new Book();

        // GET: /Book hoặc /Book?genreId=2 (lọc theo thể loại)
        public IActionResult Index(int? genreId, int? authorId)
        {
            // Truyền danh sách authors và genres cho combobox lọc
            ViewBag.authors = book.Authors;
            ViewBag.genres  = book.Genres;
            ViewBag.GenreId  = genreId;
            ViewBag.AuthorId = authorId;

            var books = book.GetBookList();

            // Lọc theo thể loại nếu có
            if (genreId.HasValue)
                books = books.Where(b => b.GenreId == genreId.Value).ToList();

            // Lọc theo tác giả nếu có
            if (authorId.HasValue)
                books = books.Where(b => b.AuthorId == authorId.Value).ToList();

            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres  = book.Genres;
            Book model = new Book();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres  = book.Genres;
            Book model = book.GetBookById(id);
            return View(model);
        }

        // Trả về PartialView cho Ajax (Bài 3)
        public PartialViewResult PopularBook()
        {
            var books = book.GetBookList();
            return PartialView(books);
        }
    }
}
