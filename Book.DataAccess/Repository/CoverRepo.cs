using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CoverRepo : Repository<Cover>, ICoverRepo
    {
        private readonly ApplicationDbContext _db;

        public CoverRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Cover cover)
        {
            _db.Update(cover);
        }
    }
}
