using Microsoft.EntityFrameworkCore;

namespace examen_pf.Models
{
    public class ApplicationContexte : DbContext
    {
        public ApplicationContexte(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
