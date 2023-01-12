using DTO;
using Newtonsoft.Json;
using System.Net;

namespace EmployeesManagmentSystemWeb.Services
{
    public class EmployeeService : IEmployeeService
    {
     
        public IEnumerable<Employee> GetAll()
        {
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] + 
                "/api/Employee/List";
            WebClient client = new WebClient();
            var response = client.DownloadString(apiUrl);
            List<DTO.Employee> employees = JsonConvert.DeserializeObject<List<DTO.Employee>>(response);
            return employees;
        }
        public void Add(Employee employee)
        {
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                "/api/Employee/Add";
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string Json = Newtonsoft.Json.JsonConvert.SerializeObject(employee);
                client.UploadString(apiUrl, Json);
            }
        }

        public void GetEmployee(Employee employee)
        {
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                "/api/Employee/Add";
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string Json = Newtonsoft.Json.JsonConvert.SerializeObject(employee);
                client.UploadString(apiUrl, Json);
            }
        }

        public Employee Get(int Id)
        {
           
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                  "/api/Employee/GetEmployee?id=" +Id;
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.DownloadString(apiUrl);
            DTO.Employee employeeResult = JsonConvert.DeserializeObject<DTO.Employee>(response);
            return employeeResult;
        }

        public void Update(Employee employee)
        {
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                "/api/Employee/Edit";
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string Json = Newtonsoft.Json.JsonConvert.SerializeObject(employee);
                var response = client.UploadString(apiUrl, Json);
            }
        }

        public void Delete(int id)
        {
            var apiUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["BaseUrl"] +
                  "/api/Employee/Delete?id=" + id;
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.DownloadString(apiUrl);
        }
    }
}
