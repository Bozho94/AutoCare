using AutoCare.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AutoCare.Data
{
    public class AutoCareDbContext : IdentityDbContext<IdentityUser>
    {
        public AutoCareDbContext(DbContextOptions<AutoCareDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<OilServiceRecord> OilServiceRecords { get; set; } = null!;
        public DbSet<BeltServiceRecord> BeltServiceRecords { get; set; } = null!;
        public DbSet<VignetteRecord> VignetteRecords { get; set; } = null!;
        public DbSet<TechnicalInspectionRecord> TechnicalInspectionRecords { get; set; } = null!;
        public DbSet<CivilLiabilityInsurance> CivilLiabilityInsurances { get; set; } = null!;

    }
}
