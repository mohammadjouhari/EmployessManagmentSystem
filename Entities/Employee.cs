using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public string Mobile { get; set; }
        public int CountrytId { get; set; }

    }
}
