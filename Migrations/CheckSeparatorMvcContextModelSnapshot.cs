﻿// <auto-generated />
using CheckSeparatorMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CheckSeparatorMVC.Migrations
{
    [DbContext(typeof(CheckSeparatorMvcContext))]
    partial class CheckSeparatorMvcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CheckSeparatorMVC.Models.Check", b =>
                {
                    b.Property<int>("CheckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CheckId");

                    b.ToTable("Checks");
                });

            modelBuilder.Entity("CheckSeparatorMVC.Models.CheckUser", b =>
                {
                    b.Property<int>("CheckId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CheckId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("checkUsers");
                });

            modelBuilder.Entity("CheckSeparatorMVC.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CheckId")
                        .HasColumnType("int");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.HasIndex("CheckId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CheckSeparatorMVC.Models.ProductUser", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("productUsers");
                });

            modelBuilder.Entity("CheckSeparatorMVC.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CheckSeparatorMVC.Models.CheckUser", b =>
                {
                    b.HasOne("CheckSeparatorMVC.Models.Check", "Check")
                        .WithMany("CheckUsers")
                        .HasForeignKey("CheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CheckSeparatorMVC.Models.User", "User")
                        .WithMany("CheckUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CheckSeparatorMVC.Models.Product", b =>
                {
                    b.HasOne("CheckSeparatorMVC.Models.Check", "Check")
                        .WithMany("Products")
                        .HasForeignKey("CheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CheckSeparatorMVC.Models.ProductUser", b =>
                {
                    b.HasOne("CheckSeparatorMVC.Models.Product", "Product")
                        .WithMany("ProductUsers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CheckSeparatorMVC.Models.User", "User")
                        .WithMany("ProductUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
