using EmployeesManagmentSystemWeb.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace EmployeesManagmentSystemWeb.Pages
{
    public class EditEmployeeModel : PageModel
    {
        public EditEmployeeModel(IEmployeeService employeeService, IUnitOfWork unitOfWork)
        {
            EmployeeService = employeeService;
            UnitOfWork = unitOfWork;
        }


        [BindProperty]
        public DTO.Employee Employee { get; set; }
        public IEmployeeService EmployeeService { get; }
        public IUnitOfWork UnitOfWork { get; }

        [BindProperty]
        public List<Department> Departments { get; set; }
        [BindProperty]
        public List<Country> Countries { get; set; }

        public void OnGet()
        {
            var id = int.Parse(Request.Query["id"]);
            Employee = EmployeeService.Get(id);
            Countries = UnitOfWork.Country.GetAll().ToList();
            Departments = UnitOfWork.Deparmtnet.GetAll().ToList(); 
            Employee.DepartmentName = Countries.Where(d => d.ID == Employee.DepartmentId).FirstOrDefault().Name;
            Employee.CountryName = Departments.Where(d => d.ID == Employee.DepartmentId).FirstOrDefault().Name;

        }

        public void OnPost()
        {
            var emp = new DTO.Employee();
            emp.ID = int.Parse(Request.Form["Id"].ToString());
            emp.FirstName = Request.Form["name"].ToString();
            emp.DepartmentId = int.Parse(Request.Form["Departments"][0].ToString());
            emp.Salary = decimal.Parse(Request.Form["Salary"].ToString());
            emp.Mobile = Request.Form["mobile"].ToString();
            emp.CountrytId = int.Parse(Request.Form["Countries"][0].ToString());
            emp.DepartmentName = "";
            emp.CountryName = "";
            EmployeeService.Update(emp);
            Response.Redirect("Employees");

        }
    }
}
