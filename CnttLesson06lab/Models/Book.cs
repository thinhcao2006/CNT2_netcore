using Microsoft.AspNetCore.Mvc.Rendering;

namespace CnttLesson06lab.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; } = string.Empty;
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; } = string.Empty;

        // Danh sách các cuốn sách (nhờ using System.Collections.Generic)
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 2,
                    Image = "/images/products/b1.jpg",
                    Price = 500000,
                    TotalPage = 250,
                    Sumary = "Tác phẩm nổi tiếng của Nam Cao về người nông dân."
                },
                new Book()
                {
                    Id = 2,
                    Title = "Lão Hạc",
                    AuthorId = 1,
                    GenreId = 2,
                    Image = "/images/products/b2.jpg",
                    Price = 700000,
                    TotalPage = 180,
                    Sumary = "Câu chuyện cảm động về người nông dân và con chó."
                },
                new Book()
                {
                    Id = 4,
                    Title = "Cánh Đồng Bất Tận",
                    AuthorId = 3,
                    GenreId = 2,
                    Image = "/images/products/b3.jpg",
                    Price = 850000,
                    TotalPage = 320,
                    Sumary = "Tác phẩm văn học hiện đại Việt Nam."
                },
                new Book()
                {
                    Id = 6,
                    Title = "Đường Xưa Mây Trắng",
                    AuthorId = 4,
                    GenreId = 3,
                    Image = "/images/products/b4.jpg",
                    Price = 850000,
                    TotalPage = 560,
                    Sumary = "Tác phẩm của Thiền sư Thích Nhất Hạnh."
                },
            };
            return books;
        }

        // Chỉ tiết một cuốn sách theo id (nhờ using System.Linq)
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id)!;
            return book;
        }

        // SelectListItem Authors (using Microsoft.AspNetCore.Mvc.Rendering)
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Nam Cao" },
            new SelectListItem { Value = "2", Text = "Ngô Tất Tố" },
            new SelectListItem { Value = "3", Text = "Adamkhoon" },
            new SelectListItem { Value = "4", Text = "Thiền sư Thích Nhất Hạnh" }
        };

        // SelectListItem Genres
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Truyện tranh" },
            new SelectListItem { Value = "2", Text = "Văn học đương đại" },
            new SelectListItem { Value = "3", Text = "Phật học phổ thông" },
            new SelectListItem { Value = "4", Text = "Truyện cuối" }
        };
    }
}
