using System.Configuration;
using System.Text;
using Api_Crud_Mysql_Core_MVC.Models;
using Api_Crud_Mysql_Core_MVC.Models.Common;
using Api_Crud_Mysql_Core_MVC.SQL;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
                             
builder.Services.AddScoped<ILogin, CtrlLogin>();// Dependencia para loguear, 
builder.Services.AddScoped<IStockUser, CtrlStockUser>();//Dependencia para que los usuarios tengan su propo stock privado
builder.Services.AddScoped<IRegister, CtrlRegister>();// Dependencia para registrarme en la base de datos
builder.Services.AddScoped<IPlanillaCabecera, CtrlPlanillaCabecera>(); // Dependencia para CRUD de las cabeceras en registros json de la bd
builder.Services.AddScoped<IDeposito_Computacion_Stock, CtrlDeposito>();// Dependencia para CRUD de una sola tabla global manipulada por cualquier usuario
builder.Services.AddScoped<IAuth, Auth>();// Dependencia para autentificarme con pass y email, la cual me retorna un token si coinciden

//configuracion de clase
var appAppSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appAppSettingsSection);

//configuraccion JWT

var appSettings = appAppSettingsSection.Get<AppSettings>();
var llave = Encoding.ASCII.GetBytes(appSettings.Secreto);

builder.Services.AddAuthentication(option => {
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
    .AddJwtBearer(option => {
        option.RequireHttpsMetadata = false;
        option.SaveToken = true;
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(llave),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
