using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PhamQuocHuy_Template.Models;

namespace PhamQuocHuy_Template.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Industries> Industries { get; set; }
        public DbSet<IndustriesDetails> IndustriesDetails { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().HasKey(x => x.IdUser);
            modelBuilder.Entity<Industries>().HasKey(a => a.IdIndustries);
            modelBuilder.Entity<IndustriesDetails>().HasKey(x => x.IdIndustDetails);
            modelBuilder.Entity<IndustriesDetails>().HasOne<Users>(e => e.Users).WithMany(p => p.IndustriesDetails).HasForeignKey(a => a.IdUser);
			modelBuilder.Entity<IndustriesDetails>().HasOne<Industries>(e => e.Industries).WithMany(p => p.IndustriesDetails).HasForeignKey(a => a.IdIndustries);
		}
	}
}
