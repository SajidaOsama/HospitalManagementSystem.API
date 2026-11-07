using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Domain.Entities;

namespace HospitalManagementSystem.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Receptionist> Receptionists { get; set; } = null!;
    public DbSet<Appointment> Appointments { get; set; } = null!;
}

