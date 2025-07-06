using ComputerDevicesShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerDevicesShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Rate> Rates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rate>()
                .HasKey(r => new { r.UserId, r.DeviceId });

            modelBuilder.Entity<Rate>()
                .HasOne(r => r.User)
                .WithMany(v => v.Rates)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Rate>()
                .HasOne(r => r.Device)
                .WithMany(d => d.Rates)
                .HasForeignKey(r => r.DeviceId);
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "User" },
                new Role { RoleId = 2, Name = "Admin" },
                new Role { RoleId = 3, Name = "MainAdmin" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Графический процессор" },
                new Category { CategoryId = 2, Name = "Центральный процессор" },
                new Category { CategoryId = 3, Name = "Батарея" },
                new Category { CategoryId = 4, Name = "Оперативная память" },
                new Category { CategoryId = 5, Name = "Звуковая карта" },
                new Category { CategoryId = 6, Name = "Материнская катра" },
                new Category { CategoryId = 7, Name = "HDD-диск" },
                new Category { CategoryId = 8, Name = "SSD-диск" }
            );
            modelBuilder.Entity<Stock>().HasData(
                new Stock { StockId = 1, DeviceId = 1, Count = 20 },
                new Stock { StockId = 2, DeviceId = 2, Count = 20 },
                new Stock { StockId = 3, DeviceId = 3, Count = 20 },
                new Stock { StockId = 4, DeviceId = 4, Count = 20 },
                new Stock { StockId = 5, DeviceId = 5, Count = 20 },
                new Stock { StockId = 6, DeviceId = 6, Count = 20 },
                new Stock { StockId = 7, DeviceId = 7, Count = 20 },
                new Stock { StockId = 8, DeviceId = 8, Count = 20 },
                new Stock { StockId = 9, DeviceId = 9, Count = 20 },
                new Stock { StockId = 10, DeviceId = 10, Count = 20 },
                new Stock { StockId = 11, DeviceId = 11, Count = 20 },
                new Stock { StockId = 12, DeviceId = 12, Count = 20 },
                new Stock { StockId = 13, DeviceId = 13, Count = 20 },
                new Stock { StockId = 14, DeviceId = 14, Count = 20 },
                new Stock { StockId = 15, DeviceId = 15, Count = 20 },
                new Stock { StockId = 16, DeviceId = 16, Count = 20 }
            );
            modelBuilder.Entity<Device>().HasData(
                new Device { DeviceId = 1, Name = "Видеокарта GeForce RTX 4070", Price = 3279.0, Description = "Описание GeForce RTX 4070", CategoryId = 1},
                new Device { DeviceId = 2, Name = "Видеокарта GeForce RTX 5070", Price = 2700.0, Description = "Описание GeForce RTX 5070", CategoryId = 1 },
                new Device { DeviceId = 3, Name = "Видеокарта GeForce RTX 4060", Price = 3100.0, Description = "Описание GeForce RTX 4060", CategoryId = 1 },
                new Device { DeviceId = 4, Name = "Видеокарта GeForce RTX 3070", Price = 2430.0, Description = "Описание GeForce RTX 3070", CategoryId = 1 },
                new Device { DeviceId = 5, Name = "Блок питания Montech Century 850", Price = 387.0, Description = "Описание Montech Century 850", CategoryId = 3 },
                new Device { DeviceId = 6, Name = "Блок питания DeepCool PN750M", Price = 374.0, Description = "Описание DeepCool PN750M", CategoryId = 3 },
                new Device { DeviceId = 7, Name = "Блок питания DeepCool PN450M", Price = 164.0, Description = "Описание DeepCool PN450M", CategoryId = 3 },
                new Device { DeviceId = 8, Name = "Процессор AMD Ryzen 5 7500F", Price = 450.0, Description = "Описание AMD Ryzen 5 7500F", CategoryId = 2 },
                new Device { DeviceId = 9, Name = "Процессор AMD Ryzen 7 7800X3D", Price = 1358.0, Description = "Описание AMD Ryzen 7 7800X3D", CategoryId = 2 },
                new Device { DeviceId = 10, Name = "Процессор AMD Ryzen 5 5600", Price = 269.0, Description = "Описание AMD Ryzen 5 5600 ", CategoryId = 2 },
                new Device { DeviceId = 11, Name = "Звуковая карта Creative Sound G6", Price = 713.0, Description = "Описание Creative Sound G6", CategoryId = 5 },
                new Device { DeviceId = 12, Name = "Звуковая карта ASUS Xonar SE", Price = 153.0, Description = "Описание ASUS Xonar SE", CategoryId = 5 },
                new Device { DeviceId = 13, Name = "Жесткий диск WD Red Plus 4TB", Price = 380.0, Description = "Описание WD Red Plus 4TB", CategoryId = 7 },
                new Device { DeviceId = 14, Name = "Жесткий диск Seagate Barracuda 2TB", Price = 210.0, Description = "Описание Seagate Barracuda 2TB", CategoryId = 7 },
                new Device { DeviceId = 15, Name = "SSD ADATA Legend 900 1TB", Price = 233.0, Description = "Описание SSD ADATA Legend 900 1TB", CategoryId = 8 },
                new Device { DeviceId = 16, Name = "SSD ADATA XPG GAMMIX S70 Blade 1TB", Price = 274.0, Description = "Описание SSD ADATA XPG GAMMIX S70", CategoryId = 8 }
            );
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Админ", Email = "admin@gmail.com", Password = "123Qw~", RoleId = 2},
                new User { UserId = 2, Name = "Юрий", Email = "uri@gmail.com", Password = "123Qw~", RoleId = 1 },
                new User { UserId = 3, Name = "Павел", Email = "pavel@gmail.com", Password = "123Qw~", RoleId = 1 },
                new User { UserId = 4, Name = "Игорь", Email = "igor@gmail.com", Password = "123Qw~", RoleId = 1 },
                new User { UserId = 5, Name = "Антон", Email = "anton@gmail.com", Password = "123Qw~", RoleId = 1 },
                new User { UserId = 6, Name = "Анастасия", Email = "anastasia@gmail.com", Password = "123Qw~", RoleId = 1 },
                new User { UserId = 7, Name = "ГлАдмин", Email = "mainadmin@gmail.com", Password = "123Qw~", RoleId = 3 }
            );
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { OrderStatusId = 1, StatusName = "Отправлено"},
                new OrderStatus { OrderStatusId = 2, StatusName = "Доставлено"},
                new OrderStatus { OrderStatusId = 3, StatusName = "Возврат"}
            );
            modelBuilder.Entity<Cart>().HasData(
                new Cart { UserId = 1, CartId = 1},
                new Cart { UserId = 2, CartId = 2},
                new Cart { UserId = 3, CartId = 3 },
                new Cart { UserId = 4, CartId = 4 },
                new Cart { UserId = 5, CartId = 5 },
                new Cart { UserId = 6, CartId = 6 }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, UserId = 1, OrderStatusId = 2, CreateDate = new DateTime(2025, 5, 1), Name = "Админ", Email = "admin@gmail.com", MobileNumber = "+375292146857", Address = "Солигирск, ул.Октябрьская 95", IsPaid = true },
                new Order { OrderId = 2, UserId = 3, OrderStatusId = 1, CreateDate = new DateTime(2025, 5, 10), Name = "Павел", Email = "pavel@gmail.com", MobileNumber = "+375291234567", Address = "Солигирск, ул.Моложежная 1", IsPaid = false },
                new Order { OrderId = 3, UserId = 5, OrderStatusId = 1, CreateDate = new DateTime(2025, 5, 12), Name = "Антон", Email = "anton@gmail.com", MobileNumber = "+375297654321", Address = "Солигирск, ул.Судиловского 35", IsPaid = false }
            );
            modelBuilder.Entity<OrderDetail>().HasData(
               new OrderDetail { OrderDetailId = 1, OrderId = 1, DeviceId = 1, Quantity = 3, UnitPrice = 3279.0 },
               new OrderDetail { OrderDetailId = 2, OrderId = 1, DeviceId = 6, Quantity = 2, UnitPrice = 374.0 },
               new OrderDetail { OrderDetailId = 3, OrderId = 1, DeviceId = 8, Quantity = 1, UnitPrice = 450.0 },
               new OrderDetail { OrderDetailId = 4, OrderId = 1, DeviceId = 3, Quantity = 1, UnitPrice = 3100.0 },

               new OrderDetail { OrderDetailId = 5, OrderId = 2, DeviceId = 2, Quantity = 2, UnitPrice = 2700.0 },
               new OrderDetail { OrderDetailId = 6, OrderId = 2, DeviceId = 4, Quantity = 4, UnitPrice = 2430.0 },

               new OrderDetail { OrderDetailId = 7, OrderId = 3, DeviceId = 5, Quantity = 5, UnitPrice = 387.0 },
               new OrderDetail { OrderDetailId = 8, OrderId = 3, DeviceId = 7, Quantity = 2, UnitPrice = 164.0 },
               new OrderDetail { OrderDetailId = 9, OrderId = 3, DeviceId = 10, Quantity = 1, UnitPrice = 269.0 }
           );
        }

    }
}
