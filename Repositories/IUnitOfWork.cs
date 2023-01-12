using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUnitOfWork
    {
        IRepositoryEmployee Employee { get; }
        IRepositoryCountry Country { get; }
        IRepositoryDepartment Deparmtnet { get; }

        void Complete();
        void Dispose();
        void Clear();
    }
}
