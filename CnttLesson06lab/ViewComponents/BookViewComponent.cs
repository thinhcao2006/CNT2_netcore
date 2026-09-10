using CnttLesson06lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace CnttLesson06lab.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        protected Book book = new Book();

        public IViewComponentResult Invoke()
        {
            var books = book.GetBookList();
            return View(books);
        }
    }
}
