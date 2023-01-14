﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropManagerModel;

#nullable disable

namespace PropManagerModel.Migrations
{
    [DbContext(typeof(PropManagerContext))]
    [Migration("20230114130343_rent-table")]
    partial class renttable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PropManagerModel.Model.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DueDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("ExpenseDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalDeductable")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Expenses", (string)null);
                });

            modelBuilder.Entity("PropManagerModel.Model.ExpenseRecurrence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("ExpenseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("RecurrenceDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId");

                    b.ToTable("ExpenseRecurrence", (string)null);
                });

            modelBuilder.Entity("PropManagerModel.Model.Loan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset?>("DateOfLoan")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Interest")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("LMI")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoanType")
                        .HasColumnType("int");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Years")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Loans", (string)null);
                });

            modelBuilder.Entity("PropManagerModel.Model.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Bathrooms")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Carpark")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("LandSize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyType")
                        .HasColumnType("int");

                    b.Property<decimal?>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("RegistrationTransferFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Rooms")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("StampDuty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Properties", (string)null);
                });

            modelBuilder.Entity("PropManagerModel.Model.Rent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Bond")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("EndDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("PaymentPeriod")
                        .HasColumnType("int");

                    b.Property<decimal>("RentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Rents", (string)null);
                });

            modelBuilder.Entity("PropManagerModel.Model.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCurrentTenant")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Tenants", (string)null);
                });

            modelBuilder.Entity("PropManagerModel.Model.Expense", b =>
                {
                    b.HasOne("PropManagerModel.Model.Property", "Property")
                        .WithMany("Expenses")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("PropManagerModel.Model.ExpenseRecurrence", b =>
                {
                    b.HasOne("PropManagerModel.Model.Expense", "Expense")
                        .WithMany("ExpenseRecurrence")
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expense");
                });

            modelBuilder.Entity("PropManagerModel.Model.Loan", b =>
                {
                    b.HasOne("PropManagerModel.Model.Property", "Property")
                        .WithMany("Loans")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("PropManagerModel.Model.Rent", b =>
                {
                    b.HasOne("PropManagerModel.Model.Tenant", "Tenant")
                        .WithMany("Rents")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("PropManagerModel.Model.Tenant", b =>
                {
                    b.HasOne("PropManagerModel.Model.Property", "Property")
                        .WithMany("Tenants")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("PropManagerModel.Model.Expense", b =>
                {
                    b.Navigation("ExpenseRecurrence");
                });

            modelBuilder.Entity("PropManagerModel.Model.Property", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Loans");

                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("PropManagerModel.Model.Tenant", b =>
                {
                    b.Navigation("Rents");
                });
#pragma warning restore 612, 618
        }
    }
}
