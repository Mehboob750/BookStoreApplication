﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommonLayer.Models.BookModel", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName");

                    b.Property<string>("BookName");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("IsDeleted");

                    b.Property<DateTime>("ModificationDate");

                    b.Property<string>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("BookId");

                    b.ToTable("BookDetails");
                });

            modelBuilder.Entity("CommonLayer.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("Role");

                    b.HasKey("Id");

                    b.ToTable("UserRegistrations");
                });
#pragma warning restore 612, 618
        }
    }
}
