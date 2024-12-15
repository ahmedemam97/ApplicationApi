using DataAccess.Config;
using Domain.Entities;
using Domain.Entities.Bookings;
using Domain.Entities.City;
using Domain.Entities.Clients;
using Domain.Entities.Company;
using Domain.Entities.CompanyAPP;
using Domain.Entities.CompleteBookings;
using Domain.Entities.DailyExpenses;
using Domain.Entities.DailyRevenue;
using Domain.Entities.Driver;
using Domain.Entities.DriverExpenses;
using Domain.Entities.Expened;
using Domain.Entities.Expenses;
using Domain.Entities.Maintenance;
using Domain.Entities.PrivateTours;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser, IdentityRole<string>,string,IdentityUserClaim<string>, IdentityUserRole<string>,IdentityUserLogin<string>, IdentityRoleClaim<string>,IdentityUserToken<string>>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole<string>>().ToTable(nameof(IdentityRole<string>), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable(nameof(IdentityUserRole<string>), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable(nameof(IdentityRoleClaim<string>), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable(nameof(IdentityUserLogin<string>), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable(nameof(IdentityUserToken<string>), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<ApplicationUser>(entity => { entity.ToTable(name: "Users", "CoreIdentity"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable(name: "UserClaim", "CoreIdentity"); });

            modelBuilder.ApplyConfiguration(new UserConfig());
            
            // لما يمسح البارينت مش هينفع لو جواه اطفال DeleteBehavior.Restrict
            // لو مسح الاوردر يمسح الايتم معاه DeleteBehavior.Cascade

        }
        // الايرادات
        public virtual DbSet<DailyRevenue> DailyRevenue { get; set; }
        public virtual DbSet<RevenueDetails> RevenueDetails { get; set; }
        /////////////////////////////////////////////////////////////////////////////////
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Maintenance> Maintenances { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<CompanyAPP> CompanyAPP { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<DriverExpenses> DriverExpenses { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<CompleteBookings> CompleteBookings { get; set; }
        public virtual DbSet<PrivateTours> PrivateTours { get; set; } 
        // المصاريف
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<Expened> Expened { get; set; }
        public virtual DbSet<DailyExpenses> DailyExpenses { get; set; }
        public virtual DbSet<ExpensesDetails> ExpensesDetails { get; set; }
        //////////////////////////////////////////////////////////////////////////////////
    }
}
