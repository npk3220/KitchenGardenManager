using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class HomeGardenContext : DbContext
    {
        public HomeGardenContext() { }
        public HomeGardenContext(DbContextOptions<HomeGardenContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Garden> Gardens { get; set; }
        public virtual DbSet<GardenHistory> GardenHistories { get; set; }
        public virtual DbSet<Plant> Plants { get; set; }
        public virtual DbSet<GardenPlantRelation> GardenPlantRelations { get; set; }
        public virtual DbSet<PlantMaster> PlantMasters { get; set; }
        public virtual DbSet<PlantHistory> PlantHistories { get; set; }
        public virtual  DbSet<PlantStatusMaster> PlantStatusMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Garden>()
                .HasKey(g => g.GardenId);

            modelBuilder.Entity<Garden>()
                .Property(g => g.GardenId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Garden>()
                .HasOne(g => g.User)
                .WithMany(u => u.Gardens)
                .HasForeignKey(g => g.UserId);

            modelBuilder.Entity<GardenHistory>()
                .HasKey(gh => gh.GardenHistoryId);

            modelBuilder.Entity<GardenHistory>()
                .Property(gh => gh.GardenHistoryId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<GardenHistory>()
                .HasOne(gh => gh.Garden)
                .WithMany(g => g.GardenHistories)
                .HasForeignKey(gh => gh.GardenId);

            modelBuilder.Entity<GardenHistory>()
                .HasKey(gh => gh.GardenHistoryId);

            modelBuilder.Entity<GardenHistory>()
                .Property(gh => gh.GardenHistoryId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<GardenPlantRelation>()
                .HasKey(gpr => gpr.GardenPlantRelationId);

            modelBuilder.Entity<GardenPlantRelation>()
                .Property(gpr => gpr.GardenPlantRelationId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<GardenPlantRelation>()
                .HasOne(gpr => gpr.Garden)
                .WithMany(g => g.GardenPlantRelations)
                .HasForeignKey(gpr => gpr.GardenId);

            modelBuilder.Entity<GardenPlantRelation>()
                .HasOne(gpr => gpr.Plant)
                .WithMany(p => p.GardenPlantRelations)
                .HasForeignKey(gpr => gpr.PlantId);

            modelBuilder.Entity<PlantHistory>()
                .HasKey(ph => ph.PlantHistoryId);

            modelBuilder.Entity<PlantHistory>()
                .Property(ph => ph.PlantHistoryId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PlantHistory>()
                .HasOne(ph => ph.Plant)
                .WithMany(p => p.PlantHistories)
                .HasForeignKey(ph => ph.PlantId);

            modelBuilder.Entity<PlantHistory>()
                .HasOne(ph => ph.PlantStatus)
                .WithMany()
                .HasForeignKey(ph => ph.PlantStatusId);

            /*AddSeeder*/
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "admin",
                    Email = "admin@example.com",
                    PasswordHash = "hashed_password_123",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new User
                {
                    UserId = 2,
                    UserName = "user1",
                    Email = "user1@example.com",
                    PasswordHash = "hashed_password_456",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<Garden>().HasData(
                new Garden
                {
                    GardenId = 1,
                    UserId = 1,
                    Name = "Main Garden",
                    Location = "Backyard",
                    Size = 100.5,
                    IsManagementEnded = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Garden
                {
                    GardenId = 2,
                    UserId = 1,
                    Name = "Front Yard Garden",
                    Location = "Front Yard",
                    Size = 50.0,
                    IsManagementEnded = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<PlantMaster>().HasData(
                new PlantMaster
                {
                    PlantMasterId = 1,
                    PlantName = "Tomato",
                    ScientificName = "Solanum lycopersicum",
                    PlantFamily = "Solanaceae",
                    Description = "A red fruit commonly used in cooking.",
                    OptimalConditions = "Full sun, moderate watering",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new PlantMaster
                {
                    PlantMasterId = 2,
                    PlantName = "Carrot",
                    ScientificName = "Daucus carota",
                    PlantFamily = "Apiaceae",
                    Description = "An orange root vegetable.",
                    OptimalConditions = "Full sun, well-drained soil",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<Plant>().HasData(
                new Plant
                {
                    PlantId = 1,
                    Name = "Tomato",
                    PlantMasterId = 1, // PlantMasterに存在する場合
                    Quantity = 10,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Plant
                {
                    PlantId = 2,
                    Name = "Mystery Plant",
                    PlantMasterId = null, // PlantMasterに存在しない場合
                    Quantity = 5,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );


            modelBuilder.Entity<PlantStatusMaster>().HasData(
                new PlantStatusMaster
                {
                    PlantStatusMasterId = 1,
                    StatusName = "plant",
                    Description = "The plant has been planted.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new PlantStatusMaster
                {
                    PlantStatusMasterId = 2,
                    StatusName = "sprouting",
                    Description = "The plant has sprouted.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new PlantStatusMaster
                {
                    PlantStatusMasterId = 3,
                    StatusName = "harvest",
                    Description = "The plant has been harvested.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new PlantStatusMaster
                {
                    PlantStatusMasterId = 4,
                    StatusName = "blooming",
                    Description = "The plant is blooming.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new PlantStatusMaster
                {
                    PlantStatusMasterId = 5,
                    StatusName = "withering",
                    Description = "The plant has withered.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new PlantStatusMaster
                {
                    PlantStatusMasterId = 6,
                    StatusName = "fertilization",
                    Description = "Fertilization has been applied.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new PlantStatusMaster
                {
                    PlantStatusMasterId = 7,
                    StatusName = "pest",
                    Description = "The plant is affected by pests or diseases.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new PlantStatusMaster
                {
                    PlantStatusMasterId = 8,
                    StatusName = "remove",
                    Description = "The plant has been removed.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new PlantStatusMaster
                {
                    PlantStatusMasterId = 9,
                    StatusName = "other",
                    Description = "Other status not specified.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );


            modelBuilder.Entity<GardenHistory>().HasData(
                new GardenHistory
                {
                    GardenHistoryId = 1,//シードにはIDを指定する必要がある？
                    GardenId = 1,
                    ActionType = "Fertilization",
                    Details = "Added compost",
                    ActionDate = DateTime.Now.AddDays(-10),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new GardenHistory
                {
                    GardenHistoryId = 2,//シードにはIDを指定する必要がある？
                    GardenId = 1,
                    ActionType = "Measurement",
                    Details = "Soil pH measured",
                    ActionDate = DateTime.Now.AddDays(-5),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new GardenHistory
                {
                    GardenHistoryId = 3,//シードにはIDを指定する必要がある？
                    GardenId = 2,
                    ActionType = "Fertilization",
                    Details = "Added compost",
                    ActionDate = DateTime.Now.AddDays(-10),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<GardenPlantRelation>().HasData(
                new GardenPlantRelation
                {
                    GardenPlantRelationId = 1,
                    GardenId = 1,
                    PlantId = 1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new GardenPlantRelation
                {
                    GardenPlantRelationId = 2,
                    GardenId = 1,
                    PlantId = 2,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<PlantHistory>().HasData(
                new PlantHistory
                {
                    PlantHistoryId = 1,
                    PlantId = 1,
                    PlantStatusId = 1,
                    EventDate = DateTime.Now.AddDays(-30),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new PlantHistory
                {
                    PlantHistoryId = 2,
                    PlantId = 1,
                    PlantStatusId = 2,
                    EventDate = DateTime.Now.AddDays(-5),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new PlantHistory
                {
                    PlantHistoryId = 3,
                    PlantId = 2,
                    PlantStatusId = 1,
                    EventDate = DateTime.Now.AddDays(-20),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
}
