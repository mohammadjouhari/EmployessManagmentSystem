using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryDeparment : Repository<Department>, IRepositoryDepartment
    {
        public RepositoryDeparment(DBContext dbContext)
            : base(dbContext)
        {
        }
    }
}
