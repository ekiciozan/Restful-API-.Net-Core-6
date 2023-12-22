using Microsoft.EntityFrameworkCore;
using RestfulWebApi.DataLayer;
using RestfulWebApiEx.Repository;
using RestfulWebApiEx.Service;
using Microsoft.AspNetCore.Authentication;
using RestfulWebApiEx.Handler;

var builder = WebApplication.CreateBuilder(args);

//Ozan Start
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(       
builder.Configuration.GetConnectionString("DatabaseConnection")       

//Yukarıdaki satır appSettingsdeki DatabaseConnectionı okuyup burada sqlServerda yapılandırır.
));
//Yukarıdaki satır BasicAuthentication yapılandırmasını sağlar.

//Ozan End

// Add services to the container.



//Ozan Start
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(EFRepository<>));// Dependecy Injection kullanıldıgını belirttik.
//Ben sana  IGenericRepository yolladım sen bana EFRepository i newleyip ver.
builder.Services.AddScoped<IPostService, PostManager>();

//Ozan End



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions,BasicAuthenticationHandler>("BasicAuthentication",null);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//OzanEkici Start
app.UseAuthentication();
//OzanEkici End

app.UseAuthorization();


app.MapControllers();

app.Run();
