﻿// <auto-generated />
using System;
using MedicalInformationService.DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedicalInformationService.DataAccess.Migrations
{
    [DbContext(typeof(MyDataContext))]
    [Migration("20210220203240_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedicalInformationService.Entities.ActiveSubstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ActiveSubstances");
                });

            modelBuilder.Entity("MedicalInformationService.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("MedicalInformationService.Entities.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("StorageId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("MedicalInformationService.Entities.MedicineActiveSubstance", b =>
                {
                    b.Property<int>("ActiveSubstanceId")
                        .HasColumnType("int");

                    b.Property<int>("MedicineId")
                        .HasColumnType("int");

                    b.HasKey("ActiveSubstanceId", "MedicineId");

                    b.HasIndex("MedicineId");

                    b.ToTable("MedicineActiveSubstances");
                });

            modelBuilder.Entity("MedicalInformationService.Entities.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("MedicalInformationService.Entities.Medicine", b =>
                {
                    b.HasOne("MedicalInformationService.Entities.Storage", "Storage")
                        .WithMany("Medicines")
                        .HasForeignKey("StorageId");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("MedicalInformationService.Entities.MedicineActiveSubstance", b =>
                {
                    b.HasOne("MedicalInformationService.Entities.Medicine", "Medicine")
                        .WithMany("MedicineActiveSubstances")
                        .HasForeignKey("ActiveSubstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalInformationService.Entities.ActiveSubstance", "ActiveSubstance")
                        .WithMany("MedicineActiveSubstances")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActiveSubstance");

                    b.Navigation("Medicine");
                });

            modelBuilder.Entity("MedicalInformationService.Entities.ActiveSubstance", b =>
                {
                    b.Navigation("MedicineActiveSubstances");
                });

            modelBuilder.Entity("MedicalInformationService.Entities.Medicine", b =>
                {
                    b.Navigation("MedicineActiveSubstances");
                });

            modelBuilder.Entity("MedicalInformationService.Entities.Storage", b =>
                {
                    b.Navigation("Medicines");
                });
#pragma warning restore 612, 618
        }
    }
}
