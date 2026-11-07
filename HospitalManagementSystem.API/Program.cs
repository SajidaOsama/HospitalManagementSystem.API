using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Infrastructure.Data;
using HospitalManagementSystem.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddControllers();

// إضافة خدمات الـ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// تسجيل الـ DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// تسجيل الـ Application Services
builder.Services.AddScoped<IPatientService, PatientService>();

var app = builder.Build();

// 2. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // تفعيل واجهة الـ Swagger الرسمية
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();