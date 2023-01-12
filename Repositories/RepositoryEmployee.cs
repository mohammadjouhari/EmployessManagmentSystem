﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryEmployee : Repository<Employee>, IRepositoryEmployee
    {
        public RepositoryEmployee(DBContext dbContext)
            : base(dbContext)
        {
        }
    }
}
