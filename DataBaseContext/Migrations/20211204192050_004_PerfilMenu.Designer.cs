﻿// <auto-generated />
using System;
using DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataBaseContext.Migrations
{
    [DbContext(typeof(LabDBContext))]
    [Migration("20211204192050_004_PerfilMenu")]
    partial class _004_PerfilMenu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DataBaseContext.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("Creado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("creado")
                        .HasDefaultValueSql("(CURRENT_TIMESTAMP)");

                    b.Property<int>("CreadoPor")
                        .HasColumnType("int")
                        .HasColumnName("creadoPor");

                    b.Property<string>("IconClass")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("iconClass");

                    b.Property<DateTime?>("Modificado")
                        .HasColumnType("datetime")
                        .HasColumnName("modificado");

                    b.Property<int?>("ModificadoPor")
                        .HasColumnType("int")
                        .HasColumnName("modificadoPor");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("nombre");

                    b.Property<int?>("PadreId")
                        .HasColumnType("int")
                        .HasColumnName("padreId");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.HasIndex("CreadoPor");

                    b.HasIndex("ModificadoPor");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("DataBaseContext.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("Activo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("activo");

                    b.Property<DateTime>("Creado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("creado")
                        .HasDefaultValueSql("(CURRENT_TIMESTAMP)");

                    b.Property<int>("CreadoPor")
                        .HasColumnType("int")
                        .HasColumnName("creadoPor");

                    b.Property<DateTime?>("Modificado")
                        .HasColumnType("datetime")
                        .HasColumnName("modificado");

                    b.Property<int?>("ModificadoPor")
                        .HasColumnType("int")
                        .HasColumnName("modificadoPor");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.HasIndex("CreadoPor");

                    b.HasIndex("ModificadoPor");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("DataBaseContext.Models.PerfilMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("Creado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("creado")
                        .HasDefaultValueSql("(CURRENT_TIMESTAMP)");

                    b.Property<int>("CreadoPor")
                        .HasColumnType("int")
                        .HasColumnName("creadoPor");

                    b.Property<int>("IdMenu")
                        .HasColumnType("int")
                        .HasColumnName("idMenu");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int")
                        .HasColumnName("idPerfil");

                    b.Property<DateTime?>("Modificado")
                        .HasColumnType("datetime")
                        .HasColumnName("modificado");

                    b.Property<int?>("ModificadoPor")
                        .HasColumnType("int")
                        .HasColumnName("modificadoPor");

                    b.HasKey("Id");

                    b.HasIndex("CreadoPor");

                    b.HasIndex("ModificadoPor");

                    b.ToTable("PerfilMenu");
                });

            modelBuilder.Entity("DataBaseContext.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("Activo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("activo");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("apellidos");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("contrasena");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("correo");

                    b.Property<DateTime>("Creado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("creado")
                        .HasDefaultValueSql("(CURRENT_TIMESTAMP)");

                    b.Property<int>("CreadoPor")
                        .HasColumnType("int")
                        .HasColumnName("creadoPor");

                    b.Property<DateTime?>("Modificado")
                        .HasColumnType("datetime")
                        .HasColumnName("modificado");

                    b.Property<int?>("ModificadoPor")
                        .HasColumnType("int")
                        .HasColumnName("modificadoPor");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.HasIndex("CreadoPor");

                    b.HasIndex("ModificadoPor");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("DataBaseContext.Models.Menu", b =>
                {
                    b.HasOne("DataBaseContext.Models.Usuario", "CreadoPorNavigation")
                        .WithMany("MenuCreadoPorNavigation")
                        .HasForeignKey("CreadoPor")
                        .HasConstraintName("FK_Menu_CreadoPor")
                        .IsRequired();

                    b.HasOne("DataBaseContext.Models.Usuario", "ModificadoPorNavigation")
                        .WithMany("MenuModificadoPorNavigation")
                        .HasForeignKey("ModificadoPor")
                        .HasConstraintName("FK_Menu_ModificadoPor");

                    b.Navigation("CreadoPorNavigation");

                    b.Navigation("ModificadoPorNavigation");
                });

            modelBuilder.Entity("DataBaseContext.Models.Perfil", b =>
                {
                    b.HasOne("DataBaseContext.Models.Usuario", "CreadoPorNavigation")
                        .WithMany("PerfilCreadoPorNavigation")
                        .HasForeignKey("CreadoPor")
                        .HasConstraintName("FK_Perfil_CreadoPor")
                        .IsRequired();

                    b.HasOne("DataBaseContext.Models.Usuario", "ModificadoPorNavigation")
                        .WithMany("PerfilModificadoPorNavigation")
                        .HasForeignKey("ModificadoPor")
                        .HasConstraintName("FK_Perfil_ModificadoPor");

                    b.Navigation("CreadoPorNavigation");

                    b.Navigation("ModificadoPorNavigation");
                });

            modelBuilder.Entity("DataBaseContext.Models.PerfilMenu", b =>
                {
                    b.HasOne("DataBaseContext.Models.Usuario", "CreadoPorNavigation")
                        .WithMany("PerfilMenuCreadoPorNavigation")
                        .HasForeignKey("CreadoPor")
                        .HasConstraintName("FK_PerfilMenu_CreadoPor")
                        .IsRequired();

                    b.HasOne("DataBaseContext.Models.Usuario", "ModificadoPorNavigation")
                        .WithMany("PerfilMenuModificadoPorNavigation")
                        .HasForeignKey("ModificadoPor")
                        .HasConstraintName("FK_PerfilMenu_ModificadoPor");

                    b.Navigation("CreadoPorNavigation");

                    b.Navigation("ModificadoPorNavigation");
                });

            modelBuilder.Entity("DataBaseContext.Models.Usuario", b =>
                {
                    b.HasOne("DataBaseContext.Models.Usuario", "CreadoPorNavigation")
                        .WithMany("InverseCreadoPorNavigation")
                        .HasForeignKey("CreadoPor")
                        .HasConstraintName("FK_Usuario_CreadoPor")
                        .IsRequired();

                    b.HasOne("DataBaseContext.Models.Usuario", "ModificadoPorNavigation")
                        .WithMany("InverseModificadoPorNavigation")
                        .HasForeignKey("ModificadoPor")
                        .HasConstraintName("FK_Usuario_ModificadoPor");

                    b.Navigation("CreadoPorNavigation");

                    b.Navigation("ModificadoPorNavigation");
                });

            modelBuilder.Entity("DataBaseContext.Models.Usuario", b =>
                {
                    b.Navigation("InverseCreadoPorNavigation");

                    b.Navigation("InverseModificadoPorNavigation");

                    b.Navigation("MenuCreadoPorNavigation");

                    b.Navigation("MenuModificadoPorNavigation");

                    b.Navigation("PerfilCreadoPorNavigation");

                    b.Navigation("PerfilMenuCreadoPorNavigation");

                    b.Navigation("PerfilMenuModificadoPorNavigation");

                    b.Navigation("PerfilModificadoPorNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
