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
        }
    }
}
