using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ComputerDevicesShop.Migrations
{
    /// <inheritdoc />
    public partial class finaledatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Категория",
                columns: table => new
                {
                    Идентификатор_категории = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Категория", x => x.Идентификатор_категории);
                });

            migrationBuilder.CreateTable(
                name: "Роли",
                columns: table => new
                {
                    Идентификатор_роли = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Название = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Роли", x => x.Идентификатор_роли);
                });

            migrationBuilder.CreateTable(
                name: "Статус_Заказа",
                columns: table => new
                {
                    Идентификатор_статуса_заказа = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Идентификатор_заказа = table.Column<int>(type: "int", nullable: false),
                    Название = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Статус_Заказа", x => x.Идентификатор_статуса_заказа);
                });

            migrationBuilder.CreateTable(
                name: "Устройства",
                columns: table => new
                {
                    Идентификатор_устройства = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Идентификатор_категории = table.Column<int>(type: "int", nullable: false),
                    Название = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Цена = table.Column<double>(type: "float", nullable: false),
                    Описание = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Изображение = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Рейтинг_товара = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Устройства", x => x.Идентификатор_устройства);
                    table.ForeignKey(
                        name: "FK_Устройства_Категория_Идентификатор_категории",
                        column: x => x.Идентификатор_категории,
                        principalTable: "Категория",
                        principalColumn: "Идентификатор_категории",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Пользователи",
                columns: table => new
                {
                    Идентификатор_пользовалетеля = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Имя_пользовалетеля = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Почта_пользовалетеля = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Пароль = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Роль = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Пользователи", x => x.Идентификатор_пользовалетеля);
                    table.ForeignKey(
                        name: "FK_Пользователи_Роли_Роль",
                        column: x => x.Роль,
                        principalTable: "Роли",
                        principalColumn: "Идентификатор_роли",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Склад",
                columns: table => new
                {
                    Идентификатор_склада = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Идентификатор_устройства = table.Column<int>(type: "int", nullable: false),
                    Количество = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Склад", x => x.Идентификатор_склада);
                    table.ForeignKey(
                        name: "FK_Склад_Устройства_Идентификатор_устройства",
                        column: x => x.Идентификатор_устройства,
                        principalTable: "Устройства",
                        principalColumn: "Идентификатор_устройства",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Заказ",
                columns: table => new
                {
                    Идентификатор_заказа = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Идентификатор_пользовалетеля = table.Column<int>(type: "int", nullable: false),
                    Идентификатор_статуса_заказа = table.Column<int>(type: "int", nullable: false),
                    Дата = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Название = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Почта = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Номер_телефона = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Адрес = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Оплата = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Заказ", x => x.Идентификатор_заказа);
                    table.ForeignKey(
                        name: "FK_Заказ_Пользователи_Идентификатор_пользовалетеля",
                        column: x => x.Идентификатор_пользовалетеля,
                        principalTable: "Пользователи",
                        principalColumn: "Идентификатор_пользовалетеля",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Заказ_Статус_Заказа_Идентификатор_статуса_заказа",
                        column: x => x.Идентификатор_статуса_заказа,
                        principalTable: "Статус_Заказа",
                        principalColumn: "Идентификатор_статуса_заказа",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Корзина",
                columns: table => new
                {
                    Идентификатор_корзины = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Идентификатор_пользователя = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Корзина", x => x.Идентификатор_корзины);
                    table.ForeignKey(
                        name: "FK_Корзина_Пользователи_Идентификатор_пользователя",
                        column: x => x.Идентификатор_пользователя,
                        principalTable: "Пользователи",
                        principalColumn: "Идентификатор_пользовалетеля",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Рейтинг",
                columns: table => new
                {
                    Идентификатор_пользователя = table.Column<int>(type: "int", nullable: false),
                    Идентификатор_устройства = table.Column<int>(type: "int", nullable: false),
                    Оценка = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Рейтинг", x => new { x.Идентификатор_пользователя, x.Идентификатор_устройства });
                    table.ForeignKey(
                        name: "FK_Рейтинг_Пользователи_Идентификатор_пользователя",
                        column: x => x.Идентификатор_пользователя,
                        principalTable: "Пользователи",
                        principalColumn: "Идентификатор_пользовалетеля",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Рейтинг_Устройства_Идентификатор_устройства",
                        column: x => x.Идентификатор_устройства,
                        principalTable: "Устройства",
                        principalColumn: "Идентификатор_устройства",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Детали_Заказа",
                columns: table => new
                {
                    Идентификатор_деталей_заказа = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Идентификатор_заказа = table.Column<int>(type: "int", nullable: false),
                    Идентификатор_устройства = table.Column<int>(type: "int", nullable: false),
                    Количество = table.Column<int>(type: "int", nullable: false),
                    Цена_товара = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Детали_Заказа", x => x.Идентификатор_деталей_заказа);
                    table.ForeignKey(
                        name: "FK_Детали_Заказа_Заказ_Идентификатор_заказа",
                        column: x => x.Идентификатор_заказа,
                        principalTable: "Заказ",
                        principalColumn: "Идентификатор_заказа",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Детали_Заказа_Устройства_Идентификатор_устройства",
                        column: x => x.Идентификатор_устройства,
                        principalTable: "Устройства",
                        principalColumn: "Идентификатор_устройства",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Детали_Корзины",
                columns: table => new
                {
                    Идентификатор_деталей_корзины = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Идентификатор_корзины = table.Column<int>(type: "int", nullable: false),
                    Идентификатор_устройства = table.Column<int>(type: "int", nullable: false),
                    Количество = table.Column<int>(type: "int", nullable: false),
                    Цена_товара = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Детали_Корзины", x => x.Идентификатор_деталей_корзины);
                    table.ForeignKey(
                        name: "FK_Детали_Корзины_Корзина_Идентификатор_корзины",
                        column: x => x.Идентификатор_корзины,
                        principalTable: "Корзина",
                        principalColumn: "Идентификатор_корзины",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Детали_Корзины_Устройства_Идентификатор_устройства",
                        column: x => x.Идентификатор_устройства,
                        principalTable: "Устройства",
                        principalColumn: "Идентификатор_устройства",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Категория",
                columns: new[] { "Идентификатор_категории", "Название" },
                values: new object[,]
                {
                    { 1, "Графический процессор" },
                    { 2, "Центральный процессор" },
                    { 3, "Батарея" },
                    { 4, "Оперативная память" },
                    { 5, "Звуковая карта" },
                    { 6, "Материнская катра" },
                    { 7, "HDD-диск" },
                    { 8, "SSD-диск" }
                });

            migrationBuilder.InsertData(
                table: "Роли",
                columns: new[] { "Идентификатор_роли", "Название" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" },
                    { 3, "MainAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Статус_Заказа",
                columns: new[] { "Идентификатор_статуса_заказа", "Идентификатор_заказа", "Название" },
                values: new object[,]
                {
                    { 1, 0, "Отправлено" },
                    { 2, 0, "Доставлено" },
                    { 3, 0, "Возврат" }
                });

            migrationBuilder.InsertData(
                table: "Пользователи",
                columns: new[] { "Идентификатор_пользовалетеля", "Почта_пользовалетеля", "Имя_пользовалетеля", "Пароль", "Роль" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", "Админ", "123Qw~", 2 },
                    { 2, "uri@gmail.com", "Юрий", "123Qw~", 1 },
                    { 3, "pavel@gmail.com", "Павел", "123Qw~", 1 },
                    { 4, "igor@gmail.com", "Игорь", "123Qw~", 1 },
                    { 5, "anton@gmail.com", "Антон", "123Qw~", 1 },
                    { 6, "anastasia@gmail.com", "Анастасия", "123Qw~", 1 },
                    { 7, "mainadmin@gmail.com", "ГлАдмин", "123Qw~", 3 }
                });

            migrationBuilder.InsertData(
                table: "Устройства",
                columns: new[] { "Идентификатор_устройства", "Идентификатор_категории", "Описание", "Изображение", "Название", "Цена", "Рейтинг_товара" },
                values: new object[,]
                {
                    { 1, 1, "Описание GeForce RTX 4070", null, "Видеокарта GeForce RTX 4070", 3279.0, null },
                    { 2, 1, "Описание GeForce RTX 5070", null, "Видеокарта GeForce RTX 5070", 2700.0, null },
                    { 3, 1, "Описание GeForce RTX 4060", null, "Видеокарта GeForce RTX 4060", 3100.0, null },
                    { 4, 1, "Описание GeForce RTX 3070", null, "Видеокарта GeForce RTX 3070", 2430.0, null },
                    { 5, 3, "Описание Montech Century 850", null, "Блок питания Montech Century 850", 387.0, null },
                    { 6, 3, "Описание DeepCool PN750M", null, "Блок питания DeepCool PN750M", 374.0, null },
                    { 7, 3, "Описание DeepCool PN450M", null, "Блок питания DeepCool PN450M", 164.0, null },
                    { 8, 2, "Описание AMD Ryzen 5 7500F", null, "Процессор AMD Ryzen 5 7500F", 450.0, null },
                    { 9, 2, "Описание AMD Ryzen 7 7800X3D", null, "Процессор AMD Ryzen 7 7800X3D", 1358.0, null },
                    { 10, 2, "Описание AMD Ryzen 5 5600 ", null, "Процессор AMD Ryzen 5 5600", 269.0, null },
                    { 11, 5, "Описание Creative Sound G6", null, "Звуковая карта Creative Sound G6", 713.0, null },
                    { 12, 5, "Описание ASUS Xonar SE", null, "Звуковая карта ASUS Xonar SE", 153.0, null },
                    { 13, 7, "Описание WD Red Plus 4TB", null, "Жесткий диск WD Red Plus 4TB", 380.0, null },
                    { 14, 7, "Описание Seagate Barracuda 2TB", null, "Жесткий диск Seagate Barracuda 2TB", 210.0, null },
                    { 15, 8, "Описание SSD ADATA Legend 900 1TB", null, "SSD ADATA Legend 900 1TB", 233.0, null },
                    { 16, 8, "Описание SSD ADATA XPG GAMMIX S70", null, "SSD ADATA XPG GAMMIX S70 Blade 1TB", 274.0, null }
                });

            migrationBuilder.InsertData(
                table: "Заказ",
                columns: new[] { "Идентификатор_заказа", "Адрес", "Дата", "Почта", "Оплата", "Номер_телефона", "Название", "Идентификатор_статуса_заказа", "Идентификатор_пользовалетеля" },
                values: new object[,]
                {
                    { 1, "Солигирск, ул.Октябрьская 95", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", true, "+375292146857", "Админ", 2, 1 },
                    { 2, "Солигирск, ул.Моложежная 1", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "pavel@gmail.com", false, "+375291234567", "Павел", 1, 3 },
                    { 3, "Солигирск, ул.Судиловского 35", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "anton@gmail.com", false, "+375297654321", "Антон", 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Корзина",
                columns: new[] { "Идентификатор_корзины", "Идентификатор_пользователя" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "Склад",
                columns: new[] { "Идентификатор_склада", "Количество", "Идентификатор_устройства" },
                values: new object[,]
                {
                    { 1, 20, 1 },
                    { 2, 20, 2 },
                    { 3, 20, 3 },
                    { 4, 20, 4 },
                    { 5, 20, 5 },
                    { 6, 20, 6 },
                    { 7, 20, 7 },
                    { 8, 20, 8 },
                    { 9, 20, 9 },
                    { 10, 20, 10 },
                    { 11, 20, 11 },
                    { 12, 20, 12 },
                    { 13, 20, 13 },
                    { 14, 20, 14 },
                    { 15, 20, 15 },
                    { 16, 20, 16 }
                });

            migrationBuilder.InsertData(
                table: "Детали_Заказа",
                columns: new[] { "Идентификатор_деталей_заказа", "Идентификатор_устройства", "Идентификатор_заказа", "Количество", "Цена_товара" },
                values: new object[,]
                {
                    { 1, 1, 1, 3, 3279.0 },
                    { 2, 6, 1, 2, 374.0 },
                    { 3, 8, 1, 1, 450.0 },
                    { 4, 3, 1, 1, 3100.0 },
                    { 5, 2, 2, 2, 2700.0 },
                    { 6, 4, 2, 4, 2430.0 },
                    { 7, 5, 3, 5, 387.0 },
                    { 8, 7, 3, 2, 164.0 },
                    { 9, 10, 3, 1, 269.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Детали_Заказа_Идентификатор_заказа",
                table: "Детали_Заказа",
                column: "Идентификатор_заказа");

            migrationBuilder.CreateIndex(
                name: "IX_Детали_Заказа_Идентификатор_устройства",
                table: "Детали_Заказа",
                column: "Идентификатор_устройства");

            migrationBuilder.CreateIndex(
                name: "IX_Детали_Корзины_Идентификатор_корзины",
                table: "Детали_Корзины",
                column: "Идентификатор_корзины");

            migrationBuilder.CreateIndex(
                name: "IX_Детали_Корзины_Идентификатор_устройства",
                table: "Детали_Корзины",
                column: "Идентификатор_устройства");

            migrationBuilder.CreateIndex(
                name: "IX_Заказ_Идентификатор_пользовалетеля",
                table: "Заказ",
                column: "Идентификатор_пользовалетеля");

            migrationBuilder.CreateIndex(
                name: "IX_Заказ_Идентификатор_статуса_заказа",
                table: "Заказ",
                column: "Идентификатор_статуса_заказа");

            migrationBuilder.CreateIndex(
                name: "IX_Корзина_Идентификатор_пользователя",
                table: "Корзина",
                column: "Идентификатор_пользователя",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Пользователи_Роль",
                table: "Пользователи",
                column: "Роль");

            migrationBuilder.CreateIndex(
                name: "IX_Рейтинг_Идентификатор_устройства",
                table: "Рейтинг",
                column: "Идентификатор_устройства");

            migrationBuilder.CreateIndex(
                name: "IX_Склад_Идентификатор_устройства",
                table: "Склад",
                column: "Идентификатор_устройства",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Устройства_Идентификатор_категории",
                table: "Устройства",
                column: "Идентификатор_категории");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Детали_Заказа");

            migrationBuilder.DropTable(
                name: "Детали_Корзины");

            migrationBuilder.DropTable(
                name: "Рейтинг");

            migrationBuilder.DropTable(
                name: "Склад");

            migrationBuilder.DropTable(
                name: "Заказ");

            migrationBuilder.DropTable(
                name: "Корзина");

            migrationBuilder.DropTable(
                name: "Устройства");

            migrationBuilder.DropTable(
                name: "Статус_Заказа");

            migrationBuilder.DropTable(
                name: "Пользователи");

            migrationBuilder.DropTable(
                name: "Категория");

            migrationBuilder.DropTable(
                name: "Роли");
        }
    }
}
