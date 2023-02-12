﻿// <auto-generated />
using System;
using ActivitatiVoluntariatWEB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ActivitatiVoluntariatWEB.Migrations
{
    [DbContext(typeof(ActivitatiVoluntariatWEBContext))]
    [Migration("20230212133657_VoluntariCreate")]
    partial class VoluntariCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ActivitatiVoluntariatWEB.Models.Activitate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartamentID")
                        .HasColumnType("int");

                    b.Property<string>("NumeActivitate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Punctaj")
                        .HasColumnType("int");

                    b.Property<int?>("ResponsabilID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DepartamentID");

                    b.HasIndex("ResponsabilID");

                    b.ToTable("Activitate");
                });

            modelBuilder.Entity("ActivitatiVoluntariatWEB.Models.Departament", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Coordonator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumarVoluntari")
                        .HasColumnType("int");

                    b.Property<string>("NumeDepartament")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Departament");
                });

            modelBuilder.Entity("ActivitatiVoluntariatWEB.Models.Inscriere", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ActivitateID")
                        .HasColumnType("int");

                    b.Property<int?>("VoluntarID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ActivitateID");

                    b.HasIndex("VoluntarID");

                    b.ToTable("Inscriere");
                });

            modelBuilder.Entity("ActivitatiVoluntariatWEB.Models.Responsabil", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Functie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeResponsabil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Responsabil");
                });

            modelBuilder.Entity("ActivitatiVoluntariatWEB.Models.Voluntar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("DepartamentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DepartamentID");

                    b.ToTable("Voluntar");
                });

            modelBuilder.Entity("ActivitatiVoluntariatWEB.Models.Activitate", b =>
                {
                    b.HasOne("ActivitatiVoluntariatWEB.Models.Departament", "Departament")
                        .WithMany("Activitati")
                        .HasForeignKey("DepartamentID");

                    b.HasOne("ActivitatiVoluntariatWEB.Models.Responsabil", "Responsabil")
                        .WithMany("Activitati")
                        .HasForeignKey("ResponsabilID");

                    b.Navigation("Departament");

                    b.Navigation("Responsabil");
                });

            modelBuilder.Entity("ActivitatiVoluntariatWEB.Models.Inscriere", b =>
                {
                    b.HasOne("ActivitatiVoluntariatWEB.Models.Activitate", "Activitate")
                        .WithMany()
                        .HasForeignKey("ActivitateID");

                    b.HasOne("ActivitatiVoluntariatWEB.Models.Voluntar", "Voluntar")
                        .WithMany("Inscrieri")
                        .HasForeignKey("VoluntarID");

                    b.Navigation("Activitate");

                    b.Navigation("Voluntar");
                });

            modelBuilder.Entity("ActivitatiVoluntariatWEB.Models.Voluntar", b =>
                {
                    b.HasOne("ActivitatiVoluntariatWEB.Models.Departament", "Departament")
                        .WithMany()
                        .HasForeignKey("DepartamentID");

                    b.Navigation("Departament");
                });

            modelBuilder.Entity("ActivitatiVoluntariatWEB.Models.Departament", b =>
                {
                    b.Navigation("Activitati");
                });

            modelBuilder.Entity("ActivitatiVoluntariatWEB.Models.Responsabil", b =>
                {
                    b.Navigation("Activitati");
                });

            modelBuilder.Entity("ActivitatiVoluntariatWEB.Models.Voluntar", b =>
                {
                    b.Navigation("Inscrieri");
                });
#pragma warning restore 612, 618
        }
    }
}
