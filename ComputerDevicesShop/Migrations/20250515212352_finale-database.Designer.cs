﻿// <auto-generated />
using System;
using ComputerDevicesShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComputerDevicesShop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250515212352_finale-database")]
    partial class finaledatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ComputerDevicesShop.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_корзины");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_пользователя");

                    b.HasKey("CartId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Корзина");

                    b.HasData(
                        new
                        {
                            CartId = 1,
                            UserId = 1
                        },
                        new
                        {
                            CartId = 2,
                            UserId = 2
                        },
                        new
                        {
                            CartId = 3,
                            UserId = 3
                        },
                        new
                        {
                            CartId = 4,
                            UserId = 4
                        },
                        new
                        {
                            CartId = 5,
                            UserId = 5
                        },
                        new
                        {
                            CartId = 6,
                            UserId = 6
                        });
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.CartDetail", b =>
                {
                    b.Property<int>("CartDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_деталей_корзины");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartDetailId"));

                    b.Property<int>("CartId")
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_корзины");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_устройства");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Количество");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float")
                        .HasColumnName("Цена_товара");

                    b.HasKey("CartDetailId");

                    b.HasIndex("CartId");

                    b.HasIndex("DeviceId");

                    b.ToTable("Детали_Корзины");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_категории");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Название");

                    b.HasKey("CategoryId");

                    b.ToTable("Категория");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Графический процессор"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Центральный процессор"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Батарея"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Оперативная память"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Звуковая карта"
                        },
                        new
                        {
                            CategoryId = 6,
                            Name = "Материнская катра"
                        },
                        new
                        {
                            CategoryId = 7,
                            Name = "HDD-диск"
                        },
                        new
                        {
                            CategoryId = 8,
                            Name = "SSD-диск"
                        });
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Device", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_устройства");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_категории");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Описание");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Изображение");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Название");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("Цена");

                    b.Property<double?>("Rate")
                        .HasColumnType("float")
                        .HasColumnName("Рейтинг_товара");

                    b.HasKey("DeviceId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Устройства");

                    b.HasData(
                        new
                        {
                            DeviceId = 1,
                            CategoryId = 1,
                            Description = "Описание GeForce RTX 4070",
                            Name = "Видеокарта GeForce RTX 4070",
                            Price = 3279.0
                        },
                        new
                        {
                            DeviceId = 2,
                            CategoryId = 1,
                            Description = "Описание GeForce RTX 5070",
                            Name = "Видеокарта GeForce RTX 5070",
                            Price = 2700.0
                        },
                        new
                        {
                            DeviceId = 3,
                            CategoryId = 1,
                            Description = "Описание GeForce RTX 4060",
                            Name = "Видеокарта GeForce RTX 4060",
                            Price = 3100.0
                        },
                        new
                        {
                            DeviceId = 4,
                            CategoryId = 1,
                            Description = "Описание GeForce RTX 3070",
                            Name = "Видеокарта GeForce RTX 3070",
                            Price = 2430.0
                        },
                        new
                        {
                            DeviceId = 5,
                            CategoryId = 3,
                            Description = "Описание Montech Century 850",
                            Name = "Блок питания Montech Century 850",
                            Price = 387.0
                        },
                        new
                        {
                            DeviceId = 6,
                            CategoryId = 3,
                            Description = "Описание DeepCool PN750M",
                            Name = "Блок питания DeepCool PN750M",
                            Price = 374.0
                        },
                        new
                        {
                            DeviceId = 7,
                            CategoryId = 3,
                            Description = "Описание DeepCool PN450M",
                            Name = "Блок питания DeepCool PN450M",
                            Price = 164.0
                        },
                        new
                        {
                            DeviceId = 8,
                            CategoryId = 2,
                            Description = "Описание AMD Ryzen 5 7500F",
                            Name = "Процессор AMD Ryzen 5 7500F",
                            Price = 450.0
                        },
                        new
                        {
                            DeviceId = 9,
                            CategoryId = 2,
                            Description = "Описание AMD Ryzen 7 7800X3D",
                            Name = "Процессор AMD Ryzen 7 7800X3D",
                            Price = 1358.0
                        },
                        new
                        {
                            DeviceId = 10,
                            CategoryId = 2,
                            Description = "Описание AMD Ryzen 5 5600 ",
                            Name = "Процессор AMD Ryzen 5 5600",
                            Price = 269.0
                        },
                        new
                        {
                            DeviceId = 11,
                            CategoryId = 5,
                            Description = "Описание Creative Sound G6",
                            Name = "Звуковая карта Creative Sound G6",
                            Price = 713.0
                        },
                        new
                        {
                            DeviceId = 12,
                            CategoryId = 5,
                            Description = "Описание ASUS Xonar SE",
                            Name = "Звуковая карта ASUS Xonar SE",
                            Price = 153.0
                        },
                        new
                        {
                            DeviceId = 13,
                            CategoryId = 7,
                            Description = "Описание WD Red Plus 4TB",
                            Name = "Жесткий диск WD Red Plus 4TB",
                            Price = 380.0
                        },
                        new
                        {
                            DeviceId = 14,
                            CategoryId = 7,
                            Description = "Описание Seagate Barracuda 2TB",
                            Name = "Жесткий диск Seagate Barracuda 2TB",
                            Price = 210.0
                        },
                        new
                        {
                            DeviceId = 15,
                            CategoryId = 8,
                            Description = "Описание SSD ADATA Legend 900 1TB",
                            Name = "SSD ADATA Legend 900 1TB",
                            Price = 233.0
                        },
                        new
                        {
                            DeviceId = 16,
                            CategoryId = 8,
                            Description = "Описание SSD ADATA XPG GAMMIX S70",
                            Name = "SSD ADATA XPG GAMMIX S70 Blade 1TB",
                            Price = 274.0
                        });
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_заказа");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Адрес");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Дата");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Почта");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit")
                        .HasColumnName("Оплата");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Номер_телефона");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Название");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_статуса_заказа");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_пользовалетеля");

                    b.HasKey("OrderId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Заказ");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            Address = "Солигирск, ул.Октябрьская 95",
                            CreateDate = new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@gmail.com",
                            IsPaid = true,
                            MobileNumber = "+375292146857",
                            Name = "Админ",
                            OrderStatusId = 2,
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            Address = "Солигирск, ул.Моложежная 1",
                            CreateDate = new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "pavel@gmail.com",
                            IsPaid = false,
                            MobileNumber = "+375291234567",
                            Name = "Павел",
                            OrderStatusId = 1,
                            UserId = 3
                        },
                        new
                        {
                            OrderId = 3,
                            Address = "Солигирск, ул.Судиловского 35",
                            CreateDate = new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "anton@gmail.com",
                            IsPaid = false,
                            MobileNumber = "+375297654321",
                            Name = "Антон",
                            OrderStatusId = 1,
                            UserId = 5
                        });
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_деталей_заказа");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int>("DeviceId")
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_устройства");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_заказа");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Количество");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float")
                        .HasColumnName("Цена_товара");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("DeviceId");

                    b.HasIndex("OrderId");

                    b.ToTable("Детали_Заказа");

                    b.HasData(
                        new
                        {
                            OrderDetailId = 1,
                            DeviceId = 1,
                            OrderId = 1,
                            Quantity = 3,
                            UnitPrice = 3279.0
                        },
                        new
                        {
                            OrderDetailId = 2,
                            DeviceId = 6,
                            OrderId = 1,
                            Quantity = 2,
                            UnitPrice = 374.0
                        },
                        new
                        {
                            OrderDetailId = 3,
                            DeviceId = 8,
                            OrderId = 1,
                            Quantity = 1,
                            UnitPrice = 450.0
                        },
                        new
                        {
                            OrderDetailId = 4,
                            DeviceId = 3,
                            OrderId = 1,
                            Quantity = 1,
                            UnitPrice = 3100.0
                        },
                        new
                        {
                            OrderDetailId = 5,
                            DeviceId = 2,
                            OrderId = 2,
                            Quantity = 2,
                            UnitPrice = 2700.0
                        },
                        new
                        {
                            OrderDetailId = 6,
                            DeviceId = 4,
                            OrderId = 2,
                            Quantity = 4,
                            UnitPrice = 2430.0
                        },
                        new
                        {
                            OrderDetailId = 7,
                            DeviceId = 5,
                            OrderId = 3,
                            Quantity = 5,
                            UnitPrice = 387.0
                        },
                        new
                        {
                            OrderDetailId = 8,
                            DeviceId = 7,
                            OrderId = 3,
                            Quantity = 2,
                            UnitPrice = 164.0
                        },
                        new
                        {
                            OrderDetailId = 9,
                            DeviceId = 10,
                            OrderId = 3,
                            Quantity = 1,
                            UnitPrice = 269.0
                        });
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_статуса_заказа");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderStatusId"));

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_заказа");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Название");

                    b.HasKey("OrderStatusId");

                    b.ToTable("Статус_Заказа");

                    b.HasData(
                        new
                        {
                            OrderStatusId = 1,
                            StatusId = 0,
                            StatusName = "Отправлено"
                        },
                        new
                        {
                            OrderStatusId = 2,
                            StatusId = 0,
                            StatusName = "Доставлено"
                        },
                        new
                        {
                            OrderStatusId = 3,
                            StatusId = 0,
                            StatusName = "Возврат"
                        });
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Rate", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_пользователя");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_устройства");

                    b.Property<double>("Rateing")
                        .HasColumnType("float")
                        .HasColumnName("Оценка");

                    b.HasKey("UserId", "DeviceId");

                    b.HasIndex("DeviceId");

                    b.ToTable("Рейтинг");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_роли");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Название");

                    b.HasKey("RoleId");

                    b.ToTable("Роли");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "User"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "Admin"
                        },
                        new
                        {
                            RoleId = 3,
                            Name = "MainAdmin"
                        });
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_склада");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockId"));

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("Количество");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_устройства");

                    b.HasKey("StockId");

                    b.HasIndex("DeviceId")
                        .IsUnique();

                    b.ToTable("Склад");

                    b.HasData(
                        new
                        {
                            StockId = 1,
                            Count = 20,
                            DeviceId = 1
                        },
                        new
                        {
                            StockId = 2,
                            Count = 20,
                            DeviceId = 2
                        },
                        new
                        {
                            StockId = 3,
                            Count = 20,
                            DeviceId = 3
                        },
                        new
                        {
                            StockId = 4,
                            Count = 20,
                            DeviceId = 4
                        },
                        new
                        {
                            StockId = 5,
                            Count = 20,
                            DeviceId = 5
                        },
                        new
                        {
                            StockId = 6,
                            Count = 20,
                            DeviceId = 6
                        },
                        new
                        {
                            StockId = 7,
                            Count = 20,
                            DeviceId = 7
                        },
                        new
                        {
                            StockId = 8,
                            Count = 20,
                            DeviceId = 8
                        },
                        new
                        {
                            StockId = 9,
                            Count = 20,
                            DeviceId = 9
                        },
                        new
                        {
                            StockId = 10,
                            Count = 20,
                            DeviceId = 10
                        },
                        new
                        {
                            StockId = 11,
                            Count = 20,
                            DeviceId = 11
                        },
                        new
                        {
                            StockId = 12,
                            Count = 20,
                            DeviceId = 12
                        },
                        new
                        {
                            StockId = 13,
                            Count = 20,
                            DeviceId = 13
                        },
                        new
                        {
                            StockId = 14,
                            Count = 20,
                            DeviceId = 14
                        },
                        new
                        {
                            StockId = 15,
                            Count = 20,
                            DeviceId = 15
                        },
                        new
                        {
                            StockId = 16,
                            Count = 20,
                            DeviceId = 16
                        });
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Идентификатор_пользовалетеля");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Почта_пользовалетеля");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Имя_пользовалетеля");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Пароль");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("Роль");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Пользователи");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "admin@gmail.com",
                            Name = "Админ",
                            Password = "123Qw~",
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 2,
                            Email = "uri@gmail.com",
                            Name = "Юрий",
                            Password = "123Qw~",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 3,
                            Email = "pavel@gmail.com",
                            Name = "Павел",
                            Password = "123Qw~",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 4,
                            Email = "igor@gmail.com",
                            Name = "Игорь",
                            Password = "123Qw~",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 5,
                            Email = "anton@gmail.com",
                            Name = "Антон",
                            Password = "123Qw~",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 6,
                            Email = "anastasia@gmail.com",
                            Name = "Анастасия",
                            Password = "123Qw~",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 7,
                            Email = "mainadmin@gmail.com",
                            Name = "ГлАдмин",
                            Password = "123Qw~",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Cart", b =>
                {
                    b.HasOne("ComputerDevicesShop.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("ComputerDevicesShop.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.CartDetail", b =>
                {
                    b.HasOne("ComputerDevicesShop.Models.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerDevicesShop.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Device", b =>
                {
                    b.HasOne("ComputerDevicesShop.Models.Category", "Category")
                        .WithMany("Devices")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Order", b =>
                {
                    b.HasOne("ComputerDevicesShop.Models.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerDevicesShop.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.OrderDetail", b =>
                {
                    b.HasOne("ComputerDevicesShop.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerDevicesShop.Models.Order", "Order")
                        .WithMany("OrderDetail")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Rate", b =>
                {
                    b.HasOne("ComputerDevicesShop.Models.Device", "Device")
                        .WithMany("Rates")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputerDevicesShop.Models.User", "User")
                        .WithMany("Rates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Stock", b =>
                {
                    b.HasOne("ComputerDevicesShop.Models.Device", "Device")
                        .WithOne("Stock")
                        .HasForeignKey("ComputerDevicesShop.Models.Stock", "DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.User", b =>
                {
                    b.HasOne("ComputerDevicesShop.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Category", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Device", b =>
                {
                    b.Navigation("Rates");

                    b.Navigation("Stock")
                        .IsRequired();
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Order", b =>
                {
                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ComputerDevicesShop.Models.User", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}
