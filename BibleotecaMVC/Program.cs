using BibleotecaMVC.Context;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
//Agregamos el servicio de autenticacion 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => 
    {
        //Phat o direccion del login
        option.LoginPath = "/Acceso/Index";
        //Indicamos el tiempo de duracion de la sesion
        option.ExpireTimeSpan = TimeSpan.FromMinutes(14);
        //La siguiente propiedad redirige a la vista Home/Index
        option.AccessDeniedPath = "/Home/Index";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();
//Razor nos permite actualizar las vistas en tiempo de ejecucion
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddSqlServer<LibroContext>(builder.Configuration.GetConnectionString("cnBibleoteca"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Index}/{id?}");

app.Run();
