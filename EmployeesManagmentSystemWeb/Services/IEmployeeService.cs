using DTO;

namespace EmployeesManagmentSystemWeb.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        void Add(Employee employee);
        Employee Get(int id);
        void Update(Employee employee);
        void Delete(int id);
    }
}
