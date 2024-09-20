using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.BD.Models;

public partial class EcommerceContext : IdentityDbContext<IdentityUser>
{
    public EcommerceContext()
    {
    }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banner> Banners { get; set; }
    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<CarritoItem> CarritoItems { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Subcategoria> Subcategorias { get; set; }

    public virtual DbSet<Coleccione> Colecciones { get; set; }

    public virtual DbSet<Colore> Colores { get; set; }

    public virtual DbSet<Cupone> Cupones { get; set; }

    public virtual DbSet<Descuento> Descuentos { get; set; }

    public virtual DbSet<Devolucione> Devoluciones { get; set; }

    public virtual DbSet<Direccione> Direcciones { get; set; }

    public virtual DbSet<Favorito> Favoritos { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<ListaDeseo> ListaDeseos { get; set; }

    public virtual DbSet<ListaDeseoItem> ListaDeseoItems { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Notificacione> Notificaciones { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoItem> PedidoItems { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoDescuento> ProductoDescuentos { get; set; }

    public virtual DbSet<ProductoImagene> ProductoImagenes { get; set; }

    public virtual DbSet<ProductoTalla> ProductoTallas { get; set; }

    public virtual DbSet<PromocionProducto> PromocionProductos { get; set; }

    public virtual DbSet<Promocione> Promociones { get; set; }

    public virtual DbSet<Reseña> Reseñas { get; set; }

    public virtual DbSet<Talla> Tallas { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-Q8DDEE0B\\SQLEXPRESS;Database=Ecommerce;User Id=DeveloperUno;Password=DeveloperUno;Trusted_Connection=False;Encrypt=False;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.CarritoId).HasName("PK__Carritos__778D586BA1ED1FCE");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carritos__Usuari__6E01572D");
        });

        modelBuilder.Entity<CarritoItem>(entity =>
        {
            entity.HasKey(e => e.CarritoItemId).HasName("PK__CarritoI__BFC8805AEE3A04DA");

            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Carrito).WithMany(p => p.CarritoItems)
                .HasForeignKey(d => d.CarritoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoIt__Carri__70DDC3D8");

            entity.HasOne(d => d.Producto).WithMany(p => p.CarritoItems)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoIt__Produ__71D1E811");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1E5CBB5F520");

            entity.Property(e => e.CatImagenUrl)
                .HasMaxLength(2083)
                .HasColumnName("Cat_ImagenUrl");
            entity.Property(e => e.CatNombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Cat_Nombre");
        });

        modelBuilder.Entity<Coleccione>(entity =>
        {
            entity.HasKey(e => e.ColeccionId).HasName("PK__Coleccio__FC447A26E7CA124E");

            entity.Property(e => e.ColActivo)
                .HasDefaultValue(false)
                .HasColumnName("Col_Activo");
            entity.Property(e => e.ColDescripcion)
                .HasMaxLength(500)
                .HasColumnName("Col_Descripcion");
            entity.Property(e => e.ColImagenUrl)
                .HasMaxLength(2083)
                .HasColumnName("Col_ImagenUrl");
            entity.Property(e => e.ColNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Col_Nombre");
        });

        modelBuilder.Entity<Colore>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Colores__8DA7674DC6AC5C29");

            entity.Property(e => e.Col_Hexadecimal)
                .IsRequired()
                .HasMaxLength(7)
                .HasColumnName("Col_Hexadecimal");
            entity.Property(e => e.Col_Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Col_Nombre");
        });

        modelBuilder.Entity<Cupone>(entity =>
        {
            entity.HasKey(e => e.CuponId).HasName("PK__Cupones__C4356897A621BD92");

            entity.HasIndex(e => e.CupCodigo, "UQ__Cupones__097EAC077A813031").IsUnique();

            entity.Property(e => e.CupActivo)
                .HasDefaultValue(false)
                .HasColumnName("Cup_Activo");
            entity.Property(e => e.CupCodigo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Cup_Codigo");
            entity.Property(e => e.CupDescripcion)
                .HasMaxLength(500)
                .HasColumnName("Cup_Descripcion");
            entity.Property(e => e.CupFechaExpiracion)
                .HasColumnType("datetime")
                .HasColumnName("Cup_FechaExpiracion");
            entity.Property(e => e.CupFechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("Cup_FechaInicio");
            entity.Property(e => e.CupMontoDescuento)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Cup_MontoDescuento");
            entity.Property(e => e.CupPorcentajeDescuento)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Cup_PorcentajeDescuento");
        });

        modelBuilder.Entity<Descuento>(entity =>
        {
            entity.HasKey(e => e.DescuentoId).HasName("PK__Descuent__0C2C1118D7EE1399");

            entity.Property(e => e.DesActivo)
                .HasDefaultValue(true)
                .HasColumnName("Des_Activo");
            entity.Property(e => e.DesDescripcion)
                .HasMaxLength(500)
                .HasColumnName("Des_Descripcion");
            entity.Property(e => e.DesNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Des_Nombre");
            entity.Property(e => e.DesPorcentaje)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Des_Porcentaje");
        });

        modelBuilder.Entity<Devolucione>(entity =>
        {
            entity.HasKey(e => e.DevolucionId).HasName("PK__Devoluci__28E7B0C703AB552B");

            entity.Property(e => e.DevEstado)
                .HasMaxLength(50)
                .HasDefaultValue("Pendiente")
                .HasColumnName("Dev_Estado");
            entity.Property(e => e.DevFechaDevolucion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Dev_FechaDevolucion");
            entity.Property(e => e.DevMotivo)
                .HasMaxLength(500)
                .HasColumnName("Dev_Motivo");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Devoluciones)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Devolucio__Pedid__1CBC4616");

            entity.HasOne(d => d.Producto).WithMany(p => p.Devoluciones)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Devolucio__Produ__1DB06A4F");
        });

        modelBuilder.Entity<Direccione>(entity =>
        {
            entity.HasKey(e => e.DireccionId).HasName("PK__Direccio__68906D64C64002D4");

            entity.Property(e => e.DirCiudad)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Dir_Ciudad");
            entity.Property(e => e.DirCodigoPostal)
                .HasMaxLength(20)
                .HasColumnName("Dir_CodigoPostal");
            entity.Property(e => e.DirDepartamento)
                .HasMaxLength(100)
                .HasColumnName("Dir_Departamento");
            entity.Property(e => e.DirDireccion)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("Dir_Direccion");
            entity.Property(e => e.DirEsDireccionPrincipal)
                .HasDefaultValue(false)
                .HasColumnName("Dir_EsDireccionPrincipal");
            entity.Property(e => e.DirPais)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Dir_Pais");
            entity.Property(e => e.DirTelefono)
                .HasMaxLength(20)
                .HasColumnName("Dir_Telefono");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Direccion__Usuar__75A278F5");
        });

        modelBuilder.Entity<Favorito>(entity =>
        {
            entity.HasKey(e => e.FavoritoId).HasName("PK__Favorito__CFF711E540F8CB71");

            entity.Property(e => e.FechaAgregado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Producto).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favoritos__Produ__60A75C0F");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favoritos__Usuar__5FB337D6");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.GeneroId).HasName("PK__Generos__A99D02488A917313");

            entity.Property(e => e.GenDescripcion)
                .HasMaxLength(255)
                .HasColumnName("Gen_Descripcion");
            entity.Property(e => e.GenNombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Gen_Nombre");
        });

        modelBuilder.Entity<ListaDeseo>(entity =>
        {
            entity.HasKey(e => e.ListaDeseoId).HasName("PK__ListaDes__5D65BA4B5195219B");

            entity.ToTable("ListaDeseo");

            entity.Property(e => e.ListaDeseoFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ListaDeseo_FechaCreacion");
            entity.Property(e => e.ListaDeseoNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ListaDeseo_Nombre");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ListaDeseos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ListaDese__Usuar__797309D9");
        });

        modelBuilder.Entity<ListaDeseoItem>(entity =>
        {
            entity.HasKey(e => e.ListaDeseoItemId).HasName("PK__ListaDes__5844A70CDFF15584");

            entity.Property(e => e.FechaAgregado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.ListaDeseo).WithMany(p => p.ListaDeseoItems)
                .HasForeignKey(d => d.ListaDeseoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ListaDese__Lista__7D439ABD");

            entity.HasOne(d => d.Producto).WithMany(p => p.ListaDeseoItems)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ListaDese__Produ__7E37BEF6");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Logs__5E54864832324297");

            entity.Property(e => e.LogsAccion)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("Logs_Accion");
            entity.Property(e => e.LogsFecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Logs_Fecha");
            entity.Property(e => e.LogsNivel)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Logs_Nivel");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Logs)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Logs__UsuarioId__5BE2A6F2");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marcas__D5B1CD8B405F1601");

            entity.Property(e => e.MarNombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Mar_Nombre");
        });

        modelBuilder.Entity<Notificacione>(entity =>
        {
            entity.HasKey(e => e.NotificacionId).HasName("PK__Notifica__BCC1202435B50722");

            entity.Property(e => e.NotFechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Not_FechaEnvio");
            entity.Property(e => e.NotLeido)
                .HasDefaultValue(false)
                .HasColumnName("Not_Leido");
            entity.Property(e => e.NotMensaje)
                .HasMaxLength(1000)
                .HasColumnName("Not_Mensaje");
            entity.Property(e => e.NotTipo)
                .HasMaxLength(50)
                .HasColumnName("Not_Tipo");
            entity.Property(e => e.NotTitulo)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Not_Titulo");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__Usuar__0D7A0286");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("PK__Pedidos__09BA14307DF6022C");

            entity.Property(e => e.PedEstado)
                .HasMaxLength(50)
                .HasDefaultValue("Pendiente")
                .HasColumnName("Ped_Estado");
            entity.Property(e => e.PedFechaPedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Ped_FechaPedido");
            entity.Property(e => e.PedTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Ped_Total");

            entity.HasOne(d => d.Direccion).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.DireccionId)
                .HasConstraintName("FK__Pedidos__Direcci__03F0984C");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__Usuario__02FC7413");
        });

        modelBuilder.Entity<PedidoItem>(entity =>
        {
            entity.HasKey(e => e.PedidoItemId).HasName("PK__PedidoIt__4A8A527373B0A299");

            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Pedido).WithMany(p => p.PedidoItems)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PedidoIte__Pedid__10566F31");

            entity.HasOne(d => d.Producto).WithMany(p => p.PedidoItems)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PedidoIte__Produ__114A936A");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AEA35578B677");

            entity.HasIndex(e => e.ProCodigo, "UQ__Producto__90746C23AD9BD623").IsUnique();

            entity.Property(e => e.ProActivo)
                .HasDefaultValue(false)
                .HasColumnName("Pro_Activo");
            entity.Property(e => e.ProCategoriaId).HasColumnName("Pro_CategoriaId");
            entity.Property(e => e.ProCodigo)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ProColeccionId).HasColumnName("Pro_ColeccionId");
            entity.Property(e => e.ProDescripcionCorta)
                .HasMaxLength(250)
                .HasColumnName("Pro_DescripcionCorta");
            entity.Property(e => e.ProDescripción)
                .HasMaxLength(500)
                .HasColumnName("Pro_Descripción");
            entity.Property(e => e.ProFechaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Pro_FechaActualizacion");
            entity.Property(e => e.ProFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Pro_FechaCreacion");
            entity.Property(e => e.ProGeneroId).HasColumnName("Pro_GeneroId");
            entity.Property(e => e.ProImagenUrl)
                .HasMaxLength(2083)
                .HasColumnName("Pro_ImagenUrl");
            entity.Property(e => e.ProMarcaId).HasColumnName("Pro_MarcaId");
            entity.Property(e => e.ProNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Pro_Nombre");
            entity.Property(e => e.ProPeso)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Pro_Peso");
            entity.Property(e => e.ProPrecio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Pro_Precio");
            entity.Property(e => e.ProStock).HasColumnName("Pro_Stock");

            entity.HasOne(d => d.ProCategoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProCategoriaId)
                .HasConstraintName("FK__Productos__Pro_C__46E78A0C");

            entity.HasOne(d => d.ProColeccion).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProColeccionId)
                .HasConstraintName("FK__Productos__Pro_C__48CFD27E");

            entity.HasOne(d => d.ProGenero).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProGeneroId)
                .HasConstraintName("FK__Productos__Pro_G__49C3F6B7");

            entity.HasOne(d => d.ProMarca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProMarcaId)
                .HasConstraintName("FK__Productos__Pro_M__47DBAE45");
        });

        modelBuilder.Entity<ProductoDescuento>(entity =>
        {
            entity.HasKey(e => e.ProductoDescuentoId).HasName("PK__Producto__3F7761DE808F209F");

            entity.HasIndex(e => e.ProductoId, "idx_ProductoId");

            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");

            entity.HasOne(d => d.Descuento).WithMany(p => p.ProductoDescuentos)
                .HasForeignKey(d => d.DescuentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductoD__Descu__5441852A");

            entity.HasOne(d => d.Producto).WithMany(p => p.ProductoDescuentos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductoD__Produ__534D60F1");
        });

        modelBuilder.Entity<ProductoImagene>(entity =>
        {
            entity.HasKey(e => e.ImagenId).HasName("PK__Producto__0C7D20B7E0748E58");

            entity.Property(e => e.EsPrincipal).HasDefaultValue(false);
            entity.Property(e => e.ImagenUrl)
                .IsRequired()
                .HasMaxLength(2083);

            entity.HasOne(d => d.Producto).WithMany(p => p.ProductoImagenes)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductoI__Produ__4D94879B");
        });

        modelBuilder.Entity<ProductoTalla>(entity =>
        {
            entity.HasKey(e => e.ProductoTallaId).HasName("PK__Producto__41E8D2EA3987EB02");

            entity.HasOne(d => d.Producto).WithMany(p => p.ProductoTallas)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductoT__Produ__59C55456");

            entity.HasOne(d => d.Talla).WithMany(p => p.ProductoTallas)
                .HasForeignKey(d => d.TallaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductoT__Talla__5AB9788F");
        });

        modelBuilder.Entity<PromocionProducto>(entity =>
        {
            entity.HasKey(e => e.PromocionProductoId).HasName("PK__Promocio__64E32947221D40D5");

            entity.HasOne(d => d.Producto).WithMany(p => p.PromocionProductos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Promocion__Produ__17F790F9");

            entity.HasOne(d => d.Promocion).WithMany(p => p.PromocionProductos)
                .HasForeignKey(d => d.PromocionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Promocion__Promo__17036CC0");
        });

        modelBuilder.Entity<Promocione>(entity =>
        {
            entity.HasKey(e => e.PromocionId).HasName("PK__Promocio__2DA61D9D949AC34D");

            entity.Property(e => e.PromActivo)
                .HasDefaultValue(true)
                .HasColumnName("Prom_Activo");
            entity.Property(e => e.PromDescripcion)
                .HasMaxLength(500)
                .HasColumnName("Prom_Descripcion");
            entity.Property(e => e.PromDescuentoMonto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Prom_DescuentoMonto");
            entity.Property(e => e.PromDescuentoPorcentaje)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Prom_DescuentoPorcentaje");
            entity.Property(e => e.PromFechaFin)
                .HasColumnType("datetime")
                .HasColumnName("Prom_FechaFin");
            entity.Property(e => e.PromFechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("Prom_FechaInicio");
            entity.Property(e => e.PromNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Prom_Nombre");
        });

        modelBuilder.Entity<Reseña>(entity =>
        {
            entity.HasKey(e => e.ReseñaId).HasName("PK__Reseñas__B17323A6DAD2CB63");

            entity.Property(e => e.ResComentario)
                .HasMaxLength(1000)
                .HasColumnName("Res_Comentario");
            entity.Property(e => e.ResFechaReseña)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Res_FechaReseña");
            entity.Property(e => e.ResPuntuacion).HasColumnName("Res_Puntuacion");

            entity.HasOne(d => d.Producto).WithMany(p => p.Reseñas)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reseñas__Product__693CA210");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reseñas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reseñas__Usuario__6A30C649");
        });

        modelBuilder.Entity<Talla>(entity =>
        {
            entity.HasKey(e => e.TallaId).HasName("PK__Tallas__9BF1376DE095399A");

            entity.Property(e => e.TalNombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Tal_Nombre");
            entity.Property(e => e.TalOrdenVisualizacion).HasColumnName("Tal_OrdenVisualizacion");
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.TransaccionId).HasName("PK__Transacc__86A849FEBEAD34F4");

            entity.Property(e => e.TraEstado)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Tra_Estado");
            entity.Property(e => e.TraFechaTransaccion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Tra_FechaTransaccion");
            entity.Property(e => e.TraMetodoPago)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Tra_MetodoPago");
            entity.Property(e => e.TraMonto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Tra_Monto");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacci__Pedid__08B54D69");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacci__Usuar__07C12930");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B816446567");

            entity.Property(e => e.UsuActivo)
                .HasDefaultValue(true)
                .HasColumnName("Usu_Activo");
            entity.Property(e => e.UsuApellido)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Usu_Apellido");
            entity.Property(e => e.UsuFechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Usu_FechaRegistro");
            entity.Property(e => e.UsuNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Usu_Nombre");
            entity.Property(e => e.UsuTelefono)
                .HasMaxLength(20)
                .HasColumnName("Usu_Telefono");
        });

        // Configuración de la relación entre Usuario y IdentityUser
        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.IdentityUser)
            .WithMany()
            .HasForeignKey(u => u.IdentityUserId)
            .IsRequired(false); // El IdentityUser puede ser opcional

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
