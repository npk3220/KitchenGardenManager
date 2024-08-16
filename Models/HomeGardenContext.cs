using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class HomeGardenContext : DbContext
    {
        public HomeGardenContext() { }
        public HomeGardenContext(DbContextOptions<HomeGardenContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Garden> Gardens { get; set; }
        public DbSet<GardenHistory> GardenHistories { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<GardenPlantRelation> GardenPlantRelations { get; set; }
        public DbSet<PlantMaster> PlantMasters { get; set; }
        public DbSet<PlantHistory> PlantHistories { get; set; }
        public DbSet<PlantStatusMaster> PlantStatusMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Garden>()
                .HasOne(g => g.User)
                .WithMany(u => u.Gardens)
                .HasForeignKey(g => g.UserId);

            modelBuilder.Entity<GardenHistory>()
                .HasOne(gh => gh.Garden)
                .WithMany(g => g.GardenHistories)
                .HasForeignKey(gh => gh.GardenId);

            modelBuilder.Entity<GardenPlantRelation>()
                .HasOne(gpr => gpr.Garden)
                .WithMany(g => g.GardenPlantRelations)
                .HasForeignKey(gpr => gpr.GardenId);

            modelBuilder.Entity<GardenPlantRelation>()
                .HasOne(gpr => gpr.Plant)
                .WithMany(p => p.GardenPlantRelations)
                .HasForeignKey(gpr => gpr.PlantId);

            modelBuilder.Entity<PlantHistory>()
                .HasOne(ph => ph.Plant)
                .WithMany(p => p.PlantHistories)
                .HasForeignKey(ph => ph.PlantId);

            modelBuilder.Entity<PlantHistory>()
                .HasOne(ph => ph.PlantStatus)
                .WithMany()
                .HasForeignKey(ph => ph.PlantStatusId);
        }
    }
}
