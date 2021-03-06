// <auto-generated />
using System;
using BirlesikOdemeN6EFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BirlesikOdemeN6EFCore.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20220628011346_BirlesikOdemeDB")]
    partial class BirlesikOdemeDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BirlesikOdemeN6EFCore.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BIRTHDATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("EKLKLN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EKLZMN")
                        .HasColumnType("datetime2");

                    b.Property<string>("GNCKLN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("GNCZMN")
                        .HasColumnType("datetime2");

                    b.Property<string>("IDENTITYNO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDENTITYNOVERIFIED")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MAIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SURNAME")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
