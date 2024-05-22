﻿// <auto-generated />
using System;
using InnovationAdmin.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InnovationAdmin.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InnovationAdmin.Domain.Entities.Admin_User", b =>
                {
                    b.Property<Guid>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("User_ID");

                    b.ToTable("Admin_Users");
                });

            modelBuilder.Entity("InnovationAdmin.Domain.Entities.Admin_Role", b =>
                {
                    b.Property<Guid>("Role_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Role_ID");

                    b.ToTable("AdminRoles");
                });

            modelBuilder.Entity("InnovationAdmin.Domain.Entities.Message", b =>
                {
                    b.Property<Guid>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = new Guid("253c75d5-32af-4dbf-ab63-1af449bde7bd"),
                            Code = "1",
                            Language = "en",
                            MessageContent = "{PropertyName} is required.",
                            Type = "Error"
                        },
                        new
                        {
                            MessageId = new Guid("ed0cc6b6-11f4-4512-a441-625941917502"),
                            Code = "2",
                            Language = "en",
                            MessageContent = "{PropertyName} must not exceed {MaxLength} characters.",
                            Type = "Error"
                        },
                        new
                        {
                            MessageId = new Guid("fafe649a-3e2a-4153-8fd8-9dcd0b87e6d8"),
                            Code = "3",
                            Language = "en",
                            MessageContent = "An event with the same name and date already exists.",
                            Type = "Error"
                        });
                });

            modelBuilder.Entity("InnovationAdmin.Domain.Entities.SysPrefCompany", b =>
                {
                    b.Property<Guid>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TermForPharmacy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyID");

                    b.ToTable("SysPrefCompanies");
                });

            modelBuilder.Entity("InnovationAdmin.Domain.Entities.SysPref_GeneralBehaviours", b =>
                {
                    b.Property<Guid>("Preference_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Auto_Change_Claim_Status")
                        .HasColumnType("bit");

                    b.Property<bool>("Claim_Status_Payment")
                        .HasColumnType("bit");

                    b.Property<bool>("Claim_Status_Procare_Claim_Load")
                        .HasColumnType("bit");

                    b.Property<bool>("Claim_Status_Receipting")
                        .HasColumnType("bit");

                    b.Property<bool>("Claim_Status_Zero_Paid")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Logout_Redirect")
                        .HasColumnType("bit");

                    b.Property<int>("Records_Locked_Seconds")
                        .HasColumnType("int");

                    b.Property<int>("User_Timeout")
                        .HasColumnType("int");

                    b.HasKey("Preference_ID");

                    b.ToTable("SysPref_GeneralBehaviour");
                });
#pragma warning restore 612, 618
        }
    }
}
