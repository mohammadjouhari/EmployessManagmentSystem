using EmployeesManagmentSystemWeb;
using EmployeesManagmentSystemWeb.Services;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(40000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddDbContextPool<DBContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("HrSoultion"));
    Options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.MapRazorPages();
// Exception Handelr;
app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandler = new CustomExceptionHandler(app.Environment).Invoke
});
app.Run();
