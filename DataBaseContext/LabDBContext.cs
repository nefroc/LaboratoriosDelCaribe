using System;
using System.Data;
using DataBaseContext.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace DataBaseContext
{
    public partial class LabDBContext: DbContext, ITransactionDapperEntity
    {

        public LabDBContext(DbContextOptions<LabDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PerfilMenu> PerfilMenu { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<CatalogoTest> CatalogoTest { get; set; }
        public virtual DbSet<COVIDTest> COVIDTest { get; set; }

        public IDbConnection Connection => Database.GetDbConnection();


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity => {

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).IsRequired().HasColumnName("id");
                entity.Property(e => e.Correo).IsRequired().HasColumnName("correo");
                entity.Property(e => e.Contrasena).IsRequired().HasColumnName("contrasena");
                entity.Property(e => e.Nombre).IsRequired().HasColumnName("nombre");
                entity.Property(e => e.Apellidos).IsRequired().HasColumnName("apellidos");
                entity.Property(e => e.Activo).HasColumnName("activo");
                entity.Property(e => e.CreadoPor).HasColumnName("creadoPor");
                entity.Property(e => e.Creado).HasColumnName("creado").HasColumnType("datetime").HasDefaultValueSql("(CURRENT_TIMESTAMP)");
                entity.Property(e => e.ModificadoPor).HasColumnName("modificadoPor");
                entity.Property(e => e.Modificado).HasColumnName("modificado").HasColumnType("datetime");

                //Add
                entity.Property(e => e.IdPerfil).HasColumnName("idPerfil");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.InverseCreadoPorNavigation)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_CreadoPor");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.InverseModificadoPorNavigation)
                    .HasForeignKey(d => d.ModificadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_ModificadoPor");

                //Add
                entity.HasOne(d => d.PerfilNavigation)
                 .WithMany(p => p.UsuarioNavigation)
                 .HasForeignKey(d => d.IdPerfil)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Usuario_Perfil");
            });

            modelBuilder.Entity<Menu>(entity => {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.PadreId).HasColumnName("padreId");
                entity.Property(e => e.Nombre).HasColumnName("nombre");
                entity.Property(e => e.Url).HasColumnName("url");
                entity.Property(e => e.IconClass).HasColumnName("iconClass");
                entity.Property(e => e.CreadoPor).HasColumnName("creadoPor");
                entity.Property(e => e.Creado).HasColumnName("creado").HasColumnType("datetime").HasDefaultValueSql("(CURRENT_TIMESTAMP)");
                entity.Property(e => e.ModificadoPor).HasColumnName("modificadoPor");
                entity.Property(e => e.Modificado).HasColumnName("modificado").HasColumnType("datetime");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.MenuCreadoPorNavigation)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_CreadoPor");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.MenuModificadoPorNavigation)
                    .HasForeignKey(d => d.ModificadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_ModificadoPor");
            });

            modelBuilder.Entity<Perfil>(entity => {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre).HasColumnName("nombre");
                entity.Property(e => e.Activo).HasColumnName("activo");
                entity.Property(e => e.CreadoPor).HasColumnName("creadoPor");
                entity.Property(e => e.Creado).HasColumnName("creado").HasColumnType("datetime").HasDefaultValueSql("(CURRENT_TIMESTAMP)");
                entity.Property(e => e.ModificadoPor).HasColumnName("modificadoPor");
                entity.Property(e => e.Modificado).HasColumnName("modificado").HasColumnType("datetime");

                entity.HasOne(d => d.CreadoPorNavigation)
                   .WithMany(p => p.PerfilCreadoPorNavigation)
                   .HasForeignKey(d => d.CreadoPor)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Perfil_CreadoPor");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.PerfilModificadoPorNavigation)
                    .HasForeignKey(d => d.ModificadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perfil_ModificadoPor");
            });

            modelBuilder.Entity<PerfilMenu>(entity => {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdPerfil).HasColumnName("idPerfil");
                entity.Property(e => e.IdMenu).HasColumnName("idMenu");
                entity.Property(e => e.CreadoPor).HasColumnName("creadoPor");
                entity.Property(e => e.Creado).HasColumnName("creado").HasColumnType("datetime").HasDefaultValueSql("(CURRENT_TIMESTAMP)");
                entity.Property(e => e.ModificadoPor).HasColumnName("modificadoPor");
                entity.Property(e => e.Modificado).HasColumnName("modificado").HasColumnType("datetime");

                entity.HasOne(d => d.CreadoPorNavigation)
                   .WithMany(p => p.PerfilMenuCreadoPorNavigation)
                   .HasForeignKey(d => d.CreadoPor)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_PerfilMenu_CreadoPor");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.PerfilMenuModificadoPorNavigation)
                    .HasForeignKey(d => d.ModificadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerfilMenu_ModificadoPor");
            });

            modelBuilder.Entity<Cliente>(entity => {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre).HasColumnName("nombre");
                entity.Property(e => e.Edad).HasColumnName("edad");
                entity.Property(e => e.FechaNacimiento).HasColumnName("fechaNacimiento").HasColumnType("datetime");
                entity.Property(e => e.Sexo).HasColumnName("sexo");
                entity.Property(e => e.Telefono).HasColumnName("telefono");
                entity.Property(e => e.NombreDoctor).HasColumnName("nombreDoctor");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.NumeroPasaporte).HasColumnName("numeroPasaporte");
                entity.Property(e => e.CreadoPor).HasColumnName("creadoPor");
                entity.Property(e => e.Creado).HasColumnName("creado").HasColumnType("datetime").HasDefaultValueSql("(CURRENT_TIMESTAMP)");
                entity.Property(e => e.ModificadoPor).HasColumnName("modificadoPor");
                entity.Property(e => e.Modificado).HasColumnName("modificado").HasColumnType("datetime");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.ClienteCreadoPorNavigation)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_CreadoPor");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.ClienteModificadoPorNavigation)
                    .HasForeignKey(d => d.ModificadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_ModificadoPor");
            });

            modelBuilder.Entity<CatalogoTest>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre).HasColumnName("nombre");
                entity.Property(e => e.CreadoPor).HasColumnName("creadoPor");
                entity.Property(e => e.Creado).HasColumnName("creado").HasColumnType("datetime").HasDefaultValueSql("(CURRENT_TIMESTAMP)");
                entity.Property(e => e.ModificadoPor).HasColumnName("modificadoPor");
                entity.Property(e => e.Modificado).HasColumnName("modificado").HasColumnType("datetime");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.CatalogoTestCreadoPorNavigation)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatalogoTest_CreadoPor");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.CatalogoTestModificadoPorNavigation)
                    .HasForeignKey(d => d.ModificadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatalogoTest_ModificadoPor");
            });

            modelBuilder.Entity<COVIDTest>(entity => {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdCliente).HasColumnName("idCliente");
                entity.Property(e => e.IdCatalogoTest).HasColumnName("idCatalogoTest");
                entity.Property(e => e.Resultado).HasColumnName("resultado");
                entity.Property(e => e.NumeroAutorizacion).HasColumnName("numeroAutorizacion");
                entity.Property(e => e.RdRP).HasColumnName("RdRP");
                entity.Property(e => e.CreadoPor).HasColumnName("creadoPor");
                entity.Property(e => e.Creado).HasColumnName("creado").HasColumnType("datetime").HasDefaultValueSql("(CURRENT_TIMESTAMP)");
                entity.Property(e => e.ModificadoPor).HasColumnName("modificadoPor");
                entity.Property(e => e.Modificado).HasColumnName("modificado").HasColumnType("datetime");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.COVIDTestNavigation)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COVIDTest_Cliente");

                entity.HasOne(d => d.CreadoPorNavigation)
                    .WithMany(p => p.COVIDTestCreadoPorNavigation)
                    .HasForeignKey(d => d.CreadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COVIDTest_CreadoPor");

                entity.HasOne(d => d.ModificadoPorNavigation)
                    .WithMany(p => p.COVIDTestModificadoPorNavigation)
                    .HasForeignKey(d => d.ModificadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COVIDTest_ModificadoPor");

                entity.HasOne(d => d.CatalogoTestNavigation)
                    .WithMany(p => p.COVIDTestNavigation)
                    .HasForeignKey(d => d.ModificadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COVIDTest_CatalogoTest");
            });
        }
    }
}
