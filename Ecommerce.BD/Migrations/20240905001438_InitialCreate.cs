using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.BD.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cat_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cat_ImagenUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__F353C1E5CBB5F520", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Colecciones",
                columns: table => new
                {
                    ColeccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Col_Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Col_Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Col_ImagenUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    Col_Activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Coleccio__FC447A26E7CA124E", x => x.ColeccionId);
                });

            migrationBuilder.CreateTable(
                name: "Colores",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Col_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Col_Hexadecimal = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Colores__8DA7674DC6AC5C29", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "Cupones",
                columns: table => new
                {
                    CuponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cup_Codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cup_Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Cup_PorcentajeDescuento = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Cup_MontoDescuento = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cup_FechaInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cup_FechaExpiracion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cup_Activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cupones__C4356897A621BD92", x => x.CuponId);
                });

            migrationBuilder.CreateTable(
                name: "Descuentos",
                columns: table => new
                {
                    DescuentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Des_Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Des_Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Des_Porcentaje = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Des_Activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Descuent__0C2C1118D7EE1399", x => x.DescuentoId);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gen_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gen_Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Generos__A99D02488A917313", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mar_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Marcas__D5B1CD8B405F1601", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "Promociones",
                columns: table => new
                {
                    PromocionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prom_Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prom_Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Prom_FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    Prom_FechaFin = table.Column<DateTime>(type: "datetime", nullable: false),
                    Prom_DescuentoPorcentaje = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Prom_DescuentoMonto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Prom_Activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Promocio__2DA61D9D949AC34D", x => x.PromocionId);
                });

            migrationBuilder.CreateTable(
                name: "Tallas",
                columns: table => new
                {
                    TallaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tal_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tal_OrdenVisualizacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tallas__9BF1376DE095399A", x => x.TallaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Usu_Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Usu_Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Usu_FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Usu_Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Usu_Activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__2B3DE7B816446567", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProCodigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pro_Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pro_DescripcionCorta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pro_Descripción = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Pro_Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pro_Stock = table.Column<int>(type: "int", nullable: false),
                    Pro_Peso = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Pro_ImagenUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    Pro_Activo = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Pro_FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Pro_FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Pro_CategoriaId = table.Column<int>(type: "int", nullable: true),
                    Pro_MarcaId = table.Column<int>(type: "int", nullable: true),
                    Pro_ColeccionId = table.Column<int>(type: "int", nullable: true),
                    Pro_GeneroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__A430AEA35578B677", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK__Productos__Pro_C__46E78A0C",
                        column: x => x.Pro_CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId");
                    table.ForeignKey(
                        name: "FK__Productos__Pro_C__48CFD27E",
                        column: x => x.Pro_ColeccionId,
                        principalTable: "Colecciones",
                        principalColumn: "ColeccionId");
                    table.ForeignKey(
                        name: "FK__Productos__Pro_G__49C3F6B7",
                        column: x => x.Pro_GeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId");
                    table.ForeignKey(
                        name: "FK__Productos__Pro_M__47DBAE45",
                        column: x => x.Pro_MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "MarcaId");
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Carritos__778D586BA1ED1FCE", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK__Carritos__Usuari__6E01572D",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    DireccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Dir_Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Dir_Ciudad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dir_Departamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dir_CodigoPostal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Dir_Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dir_Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Dir_EsDireccionPrincipal = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Direccio__68906D64C64002D4", x => x.DireccionId);
                    table.ForeignKey(
                        name: "FK__Direccion__Usuar__75A278F5",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "ListaDeseo",
                columns: table => new
                {
                    ListaDeseoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ListaDeseo_Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ListaDeseo_FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ListaDes__5D65BA4B5195219B", x => x.ListaDeseoId);
                    table.ForeignKey(
                        name: "FK__ListaDese__Usuar__797309D9",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    Logs_Accion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Logs_Fecha = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Logs_Nivel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Logs__5E54864832324297", x => x.LogId);
                    table.ForeignKey(
                        name: "FK__Logs__UsuarioId__5BE2A6F2",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    NotificacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Not_Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Not_Mensaje = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Not_Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Not_FechaEnvio = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Not_Leido = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__BCC1202435B50722", x => x.NotificacionId);
                    table.ForeignKey(
                        name: "FK__Notificac__Usuar__0D7A0286",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    FavoritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    FechaAgregado = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Favorito__CFF711E540F8CB71", x => x.FavoritoId);
                    table.ForeignKey(
                        name: "FK__Favoritos__Produ__60A75C0F",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK__Favoritos__Usuar__5FB337D6",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "ProductoDescuentos",
                columns: table => new
                {
                    ProductoDescuentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    DescuentoId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__3F7761DE808F209F", x => x.ProductoDescuentoId);
                    table.ForeignKey(
                        name: "FK__ProductoD__Descu__5441852A",
                        column: x => x.DescuentoId,
                        principalTable: "Descuentos",
                        principalColumn: "DescuentoId");
                    table.ForeignKey(
                        name: "FK__ProductoD__Produ__534D60F1",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "ProductoImagenes",
                columns: table => new
                {
                    ImagenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: false),
                    EsPrincipal = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__0C7D20B7E0748E58", x => x.ImagenId);
                    table.ForeignKey(
                        name: "FK__ProductoI__Produ__4D94879B",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "ProductoTallas",
                columns: table => new
                {
                    ProductoTallaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    TallaId = table.Column<int>(type: "int", nullable: false),
                    CantidadStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__41E8D2EA3987EB02", x => x.ProductoTallaId);
                    table.ForeignKey(
                        name: "FK__ProductoT__Produ__59C55456",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK__ProductoT__Talla__5AB9788F",
                        column: x => x.TallaId,
                        principalTable: "Tallas",
                        principalColumn: "TallaId");
                });

            migrationBuilder.CreateTable(
                name: "PromocionProductos",
                columns: table => new
                {
                    PromocionProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromocionId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Promocio__64E32947221D40D5", x => x.PromocionProductoId);
                    table.ForeignKey(
                        name: "FK__Promocion__Produ__17F790F9",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK__Promocion__Promo__17036CC0",
                        column: x => x.PromocionId,
                        principalTable: "Promociones",
                        principalColumn: "PromocionId");
                });

            migrationBuilder.CreateTable(
                name: "Reseñas",
                columns: table => new
                {
                    ReseñaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Res_Puntuacion = table.Column<int>(type: "int", nullable: true),
                    Res_Comentario = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Res_FechaReseña = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reseñas__B17323A6DAD2CB63", x => x.ReseñaId);
                    table.ForeignKey(
                        name: "FK__Reseñas__Product__693CA210",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK__Reseñas__Usuario__6A30C649",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "CarritoItems",
                columns: table => new
                {
                    CarritoItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarritoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CarritoI__BFC8805AEE3A04DA", x => x.CarritoItemId);
                    table.ForeignKey(
                        name: "FK__CarritoIt__Carri__70DDC3D8",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "CarritoId");
                    table.ForeignKey(
                        name: "FK__CarritoIt__Produ__71D1E811",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Ped_FechaPedido = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Ped_Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ped_Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "Pendiente"),
                    DireccionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pedidos__09BA14307DF6022C", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK__Pedidos__Direcci__03F0984C",
                        column: x => x.DireccionId,
                        principalTable: "Direcciones",
                        principalColumn: "DireccionId");
                    table.ForeignKey(
                        name: "FK__Pedidos__Usuario__02FC7413",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "ListaDeseoItems",
                columns: table => new
                {
                    ListaDeseoItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListaDeseoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    FechaAgregado = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ListaDes__5844A70CDFF15584", x => x.ListaDeseoItemId);
                    table.ForeignKey(
                        name: "FK__ListaDese__Lista__7D439ABD",
                        column: x => x.ListaDeseoId,
                        principalTable: "ListaDeseo",
                        principalColumn: "ListaDeseoId");
                    table.ForeignKey(
                        name: "FK__ListaDese__Produ__7E37BEF6",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "Devoluciones",
                columns: table => new
                {
                    DevolucionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Dev_Motivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Dev_FechaDevolucion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Dev_Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "Pendiente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Devoluci__28E7B0C703AB552B", x => x.DevolucionId);
                    table.ForeignKey(
                        name: "FK__Devolucio__Pedid__1CBC4616",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId");
                    table.ForeignKey(
                        name: "FK__Devolucio__Produ__1DB06A4F",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "PedidoItems",
                columns: table => new
                {
                    PedidoItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PedidoIt__4A8A527373B0A299", x => x.PedidoItemId);
                    table.ForeignKey(
                        name: "FK__PedidoIte__Pedid__10566F31",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId");
                    table.ForeignKey(
                        name: "FK__PedidoIte__Produ__114A936A",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    TransaccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    Tra_Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tra_MetodoPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tra_Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tra_FechaTransaccion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transacc__86A849FEBEAD34F4", x => x.TransaccionId);
                    table.ForeignKey(
                        name: "FK__Transacci__Pedid__08B54D69",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId");
                    table.ForeignKey(
                        name: "FK__Transacci__Usuar__07C12930",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoItems_CarritoId",
                table: "CarritoItems",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoItems_ProductoId",
                table: "CarritoItems",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_UsuarioId",
                table: "Carritos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "UQ__Cupones__097EAC077A813031",
                table: "Cupones",
                column: "Cup_Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devoluciones_PedidoId",
                table: "Devoluciones",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Devoluciones_ProductoId",
                table: "Devoluciones",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_UsuarioId",
                table: "Direcciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_ProductoId",
                table: "Favoritos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_UsuarioId",
                table: "Favoritos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDeseo_UsuarioId",
                table: "ListaDeseo",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDeseoItems_ListaDeseoId",
                table: "ListaDeseoItems",
                column: "ListaDeseoId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaDeseoItems_ProductoId",
                table: "ListaDeseoItems",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UsuarioId",
                table: "Logs",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_UsuarioId",
                table: "Notificaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItems_PedidoId",
                table: "PedidoItems",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItems_ProductoId",
                table: "PedidoItems",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_DireccionId",
                table: "Pedidos",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "idx_ProductoId",
                table: "ProductoDescuentos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoDescuentos_DescuentoId",
                table: "ProductoDescuentos",
                column: "DescuentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoImagenes_ProductoId",
                table: "ProductoImagenes",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Pro_CategoriaId",
                table: "Productos",
                column: "Pro_CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Pro_ColeccionId",
                table: "Productos",
                column: "Pro_ColeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Pro_GeneroId",
                table: "Productos",
                column: "Pro_GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Pro_MarcaId",
                table: "Productos",
                column: "Pro_MarcaId");

            migrationBuilder.CreateIndex(
                name: "UQ__Producto__90746C23AD9BD623",
                table: "Productos",
                column: "ProCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTallas_ProductoId",
                table: "ProductoTallas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTallas_TallaId",
                table: "ProductoTallas",
                column: "TallaId");

            migrationBuilder.CreateIndex(
                name: "IX_PromocionProductos_ProductoId",
                table: "PromocionProductos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_PromocionProductos_PromocionId",
                table: "PromocionProductos",
                column: "PromocionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_ProductoId",
                table: "Reseñas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reseñas_UsuarioId",
                table: "Reseñas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_PedidoId",
                table: "Transacciones",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_UsuarioId",
                table: "Transacciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdentityUserId",
                table: "Usuarios",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarritoItems");

            migrationBuilder.DropTable(
                name: "Colores");

            migrationBuilder.DropTable(
                name: "Cupones");

            migrationBuilder.DropTable(
                name: "Devoluciones");

            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "ListaDeseoItems");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "PedidoItems");

            migrationBuilder.DropTable(
                name: "ProductoDescuentos");

            migrationBuilder.DropTable(
                name: "ProductoImagenes");

            migrationBuilder.DropTable(
                name: "ProductoTallas");

            migrationBuilder.DropTable(
                name: "PromocionProductos");

            migrationBuilder.DropTable(
                name: "Reseñas");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "ListaDeseo");

            migrationBuilder.DropTable(
                name: "Descuentos");

            migrationBuilder.DropTable(
                name: "Tallas");

            migrationBuilder.DropTable(
                name: "Promociones");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Colecciones");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
