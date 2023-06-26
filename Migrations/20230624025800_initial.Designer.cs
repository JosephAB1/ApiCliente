﻿// <auto-generated />
using System;
using ApiCliente.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiCliente.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230624025800_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiCliente.Entity.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("cod_cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo_cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direc_cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("flotaId")
                        .HasColumnType("int");

                    b.Property<int?>("marcaId")
                        .HasColumnType("int");

                    b.Property<int>("nom_cliente")
                        .HasColumnType("int");

                    b.Property<string>("telef_cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("flotaId");

                    b.HasIndex("marcaId");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("ApiCliente.Entity.Flota", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("desc_flota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img_flota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("marcaId")
                        .HasColumnType("int");

                    b.Property<string>("tipo_flota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("marcaId");

                    b.ToTable("flota");
                });

            modelBuilder.Entity("ApiCliente.Entity.Marca", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("nom_marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("marca");
                });

            modelBuilder.Entity("ApiCliente.Entity.Cliente", b =>
                {
                    b.HasOne("ApiCliente.Entity.Flota", "flota")
                        .WithMany()
                        .HasForeignKey("flotaId");

                    b.HasOne("ApiCliente.Entity.Marca", "marca")
                        .WithMany()
                        .HasForeignKey("marcaId");

                    b.Navigation("flota");

                    b.Navigation("marca");
                });

            modelBuilder.Entity("ApiCliente.Entity.Flota", b =>
                {
                    b.HasOne("ApiCliente.Entity.Marca", "marca")
                        .WithMany()
                        .HasForeignKey("marcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("marca");
                });
#pragma warning restore 612, 618
        }
    }
}