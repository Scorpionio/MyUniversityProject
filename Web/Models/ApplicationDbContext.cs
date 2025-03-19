using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using Web.Models;

namespace Web.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            //Database.RenameTableAndColumns();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("DefaultConnection");
        //}

        //public void RenameTableAndColumns()
        //{
        //    string DeviceTable = "EXEC sp_rename 'Device', 'Устройство';";
        //    string DeviceId = "EXEC sp_rename 'Устройство.Id', 'Идентификатор', 'COLUMN';";
        //    string DeviceName = "EXEC sp_rename 'Устройство.Name', 'Название', 'COLUMN';";
        //    string DevicePrice = "EXEC sp_rename 'Устройство.Price', 'Цена', 'COLUMN';";
        //    string DeviceImgSrc = "EXEC sp_rename 'Устройство.ImgSrc', 'Фото', 'COLUMN';";

        //    using (SqlConnection connection = new SqlConnection(this.Database.GetConnectionString()))
        //    {
        //        connection.Open();

        //        using (SqlCommand command = new SqlCommand(DeviceTable, connection))
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        using (SqlCommand command = new SqlCommand(DeviceId, connection))
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        using (SqlCommand command = new SqlCommand(DeviceName, connection))
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        using (SqlCommand command = new SqlCommand(DevicePrice, connection))
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        using (SqlCommand command = new SqlCommand(DeviceImgSrc, connection))
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Device { get; set; } = null!;
        public DbSet<Processor> Processors { get; set; } = null!;
        public DbSet<GraphicCard> GraphicCard { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Processor>();
            //modelBuilder.Entity<GraphicCard>();

            modelBuilder.Entity<Processor>().ToTable("Processors").HasData(
                new Processor
                {
                    Id = 1,
                    Name = "Intel I7",
                    Price = 1530,
                    ImgSrc = "inteli7.png",
                    Cores = 20,
                    Threads = 28
                },
                new Processor
                {
                    Id = 3,
                    Name = "AMD Ryzen 7 9800X3D",
                    Price = 1050,
                    ImgSrc = "amdRyzen9000.jpg",
                    Cores = 8,
                    Threads = 16
                },
                new Processor
                {
                    Id = 4,
                    Name = "AMD_Ryzen 5 2600",
                    Price = 1300,
                    ImgSrc = "AMD_Ryzen_5_2600.png",
                    Cores = 6,
                    Threads = 12
                }
            );

            modelBuilder.Entity<GraphicCard>().ToTable("GraphicCards").HasData(
                new GraphicCard
                {
                    Id = 2,
                    Name = "MSI GeForce RTX 4060",
                    Price = 1555,
                    ImgSrc = "4060.jpg",
                    MemoryCapacity = 8192
                }
                //new GraphicCard
                //{
                //    Id = 2,
                //    Name = "TwT",
                //    Price = 1000,
                //    ImgSrc = "TwT.jpg",
                //    MemoryCapacity = 4096
                //}
            );
        }

    }
}
