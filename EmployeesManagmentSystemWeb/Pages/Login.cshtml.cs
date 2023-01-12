using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace EmployeesManagmentSystemWeb.Pages
{
    public class LoginModel : PageModel
    {
        public bool InvalidLogin { get; set; }
        public void OnGet()
        {
           
        }

        public IActionResult OnPost() {
            // Get The User Name and password from the posted form.
            var userName = Request.Form["UserName"].ToString();
            var password = Request.Form["Password"].ToString();
            var login = new Models.Login();
            login.UserName = userName;
            login.Password = password;
            // Hit the api and check user name and password the request.
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                "/api/Authenticate/Authenticate";
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string Json = JsonConvert.SerializeObject(login);
                var response = client.UploadString(apiUrl, Json);
                var result = JsonConvert.DeserializeObject<Models.LoginResponseModel>(response);
                if(result.code != 200)
                {
                    InvalidLogin = true;
                    return this.Page();
                }
                else
                {
                    var s = result.Message;
                    HttpContext.Session.SetString("Token", result.Message);
                    return  new RedirectToPageResult("/Employees");
                }

            }
        }
    }
}
