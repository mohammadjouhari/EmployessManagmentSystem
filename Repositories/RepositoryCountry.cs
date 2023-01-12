using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryCountry : Repository<Country>, IRepositoryCountry
    {
        public RepositoryCountry(DBContext dbContext)
            : base(dbContext)
        {
        }
    }
}
