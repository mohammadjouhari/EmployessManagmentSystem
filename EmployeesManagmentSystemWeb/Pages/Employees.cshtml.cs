using EmployeesManagmentSystemWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Repositories;
using System.Data;
using System.Net;

namespace EmployeesManagmentSystemWeb.Pages
{
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeService employeeService;
        private readonly IUnitOfWork unitOfWork;

        [BindProperty]
        public List<DTO.Employee> Allemployees { get; set; }


        public EmployeesModel(IEmployeeService employeeService, IUnitOfWork unitOfWork)
        {
            this.employeeService = employeeService;
            this.unitOfWork = unitOfWork;
        }


        public IActionResult OnPostRedirect1()
        {
            return Redirect("~/AddEmployee");
        }

        public IActionResult OnPostRedirect2()
        {
            var empId = int.Parse(Request.Form["empId"].ToString());
            return Redirect("~/EditEmployee?id=" + empId);
        }

        public IActionResult OnPostRedirect3()
        {
            var empId = int.Parse(Request.Form["empId"].ToString());
            employeeService.Delete(empId);
            return Redirect("~/Employees");
        }

        public IActionResult OnPostLogout()
        {
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                "/api/Authenticate/Logout";
            WebClient client = new WebClient();
            var response = client.DownloadString(apiUrl);
            HttpContext.Session.SetString("Token", "");
            return Redirect("~/Employees");
        }


        public IActionResult OnGet()
        {

            var Token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(Token))
            {
                return RedirectToPage("Login");
                
            }
            else
            {
                Allemployees = employeeService.GetAll().ToList();
                return this.Page();
            }
        }
    }
}
