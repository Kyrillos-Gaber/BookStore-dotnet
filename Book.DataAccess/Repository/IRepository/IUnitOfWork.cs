using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepo Category { get; }

        ICoverRepo Cover { get; }

        void Commit();
    }
}
