using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ICategoryRepo Category { get; private set; }
        public ICoverRepo Cover { get; private set; }
        public IBookRepo Book { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepo(_db);
            Cover = new CoverRepo(_db);
            Book = new BookRepo(_db);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
