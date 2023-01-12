using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        readonly DBContext _dbContext;
        public IRepositoryEmployee Employee { get; set; }

        public IRepositoryCountry Country { get; set; }
        public IRepositoryDepartment Deparmtnet { get; set; }

        public UnitOfWork(DBContext dbContext)
        {
            _dbContext = dbContext;
            Employee = new RepositoryEmployee(dbContext);
            Country = new RepositoryCountry(dbContext);
            Deparmtnet = new RepositoryDeparment(dbContext);
        }

        public void Complete()
        {
            _dbContext.SaveChanges();

        }

        public void Dispose()
        {

            _dbContext.Dispose();
        }

        public void Clear()
        {
            _dbContext.ChangeTracker.Clear();
        }
    }
}
