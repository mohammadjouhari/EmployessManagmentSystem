using EmployeesManagmentSystemWeb.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace EmployeesManagmentSystemWeb.Pages
{
    public class AddEmployeeModel : PageModel
    {
        [BindProperty]
        public List<Department> Departments { get; set; }
        [BindProperty]
        public List<Country> Countries { get; set; }
        public IUnitOfWork UnitOfWork { get; }
        public IEmployeeService EmployeeService { get; }

        public AddEmployeeModel(IUnitOfWork unitOfWork, IEmployeeService employeeService)
        {
            UnitOfWork = unitOfWork;
            EmployeeService = employeeService;
        }

        public void OnGet()
        {
            Countries = UnitOfWork.Country.GetAll().ToList();
            Departments = UnitOfWork.Deparmtnet.GetAll().ToList();
        }

        public void OnPost()
        {
            // Get the Model;
            var emp = new DTO.Employee();
            emp.FirstName = Request.Form["name"].ToString();
            emp.DepartmentId= int.Parse(Request.Form["Departments"][0].ToString());
            emp.Salary = decimal.Parse(Request.Form["Salary"].ToString());
            emp.Mobile = Request.Form["mobile"].ToString();
            emp.CountrytId = int.Parse(Request.Form["Countries"][0].ToString());
            emp.DepartmentName = "";
            emp.CountryName = "";
            EmployeeService.Add(emp);
            Response.Redirect("Employees");
        }
    }
}
