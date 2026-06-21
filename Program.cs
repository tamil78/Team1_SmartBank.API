using Microsoft.EntityFrameworkCore;
using Team1_SmartBank.API.Data;
using Team1_SmartBank.API.Interfaces;
using Team1_SmartBank.API.Repositories;
using Team1_SmartBank.API.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add Controllers
builder.Services.AddControllers();

// ✅ Database Connection (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Dependency Injection (IMPORTANT)
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// ✅ Middleware Order (VERY IMPORTANT)
app.UseRouting();

// ✅ Enable Swagger (FORCE it always)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartBank API V1");
    c.RoutePrefix = "swagger"; // so /swagger works
});

// ✅ Authorization Middleware
app.UseAuthorization();

// ✅ Map Controllers
app.MapControllers();

app.Run();