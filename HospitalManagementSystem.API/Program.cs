using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Infrastructure.Data;
using HospitalManagementSystem.Application.Services.Doctor;
using HospitalManagementSystem.Application.Services.Appointment;
using HospitalManagementSystem.Application.Services.Patient;
using HospitalManagementSystem.Application.Services.Receptionist;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddControllers();

//  Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Application Services
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IReceptionistService, ReceptionistService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();


var app = builder.Build();
// 2. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();