using EmployeeService.Data;
using EmployeeService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnection")));


builder.Services.AddScoped<IEmployeeContext, EmployeeContext>();
builder.Services.AddScoped<IEmployeeService, EmployeeService.Services.EmployeeService>();
builder.Services.AddScoped<IEmploymentTypeService, EmployeeService.Services.EmploymentTypeService>();

builder.Services.AddCors();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<EmployeeContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
