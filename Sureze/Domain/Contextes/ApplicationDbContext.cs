

using Microsoft.EntityFrameworkCore;
using Sureze.Domain.Entities;

namespace Sureze.Domain.Contextes
{



    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<PatientAddresses> PatientAddresses { get; set; }
    }


   


}