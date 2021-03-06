// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxiBackApi.Data;

namespace TaxiBackApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210326102027_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaxiBackApi.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConvertedJsonOrder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("JsonOrder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("OrderType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
