using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.LoginPath = "/Management/Account/Login"; 
    //action result = login
    //account = controller
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
//kimlik do�rulama
app.UseAuthorization();
//yetki do�rulama

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name:"Management",
        areaName:"Management",
        pattern:"Management/{controller=Dashboard}/{action=Index}/{id?}");
    //area isminin management oldugunu soyledik dashboarddaki indexe y�nlendirmesini yapar
    //management i�inde controllerlara farkl� isimler vermemiz laz�m panel i�indeki dashboard sitedeki Home
endpoints.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller}/{action}"
  //area ile birlikte controller ve actionlar� y�nlendirmesini yapar
);
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
//bu default sayfa ilk a��ld�g�ndaki index sayfas�n� a�mas�n� s�yler
app.Run();
