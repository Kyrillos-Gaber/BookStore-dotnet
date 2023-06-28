using DataAccess.Repository.IRepository;
using Models;

namespace DataAccess.Repository
{
    public class BookRepo : Repository<Book>, IBookRepo
    {
        private readonly ApplicationDbContext _db;

        public BookRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Book book)
        {
            var dbBook = _db.Books.FirstOrDefault(x => x.Id == book.Id);
            if (dbBook != null)
            {
                dbBook.Title = book.Title;
                dbBook.Price = book.Price;
                dbBook.Description = book.Description;
                dbBook.Author = book.Author;
                dbBook.CoverTypeId = book.CoverTypeId;
                dbBook.CategoryId = book.CategoryId;
                if (book.ImageUrl != null) dbBook.ImageUrl = book.ImageUrl;
            }
            
        }
    }
}