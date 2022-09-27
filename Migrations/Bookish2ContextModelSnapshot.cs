﻿// <auto-generated />
using System;
using Bookish2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bookish2.Migrations
{
    [DbContext(typeof(Bookish2Context))]
    partial class Bookish2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("integer");

                    b.Property<int>("BooksId")
                        .HasColumnType("integer");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("Bookish2.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Bookish2.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Blurb")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Bookish2.Models.Copy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("integer");

                    b.Property<int?>("BookId1")
                        .HasColumnType("integer");

                    b.Property<bool>("CheckedOut")
                        .HasColumnType("boolean");

                    b.Property<int?>("MemberId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("BookId1");

                    b.HasIndex("MemberId");

                    b.ToTable("Copies");
                });

            modelBuilder.Entity("Bookish2.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Bookish2.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookish2.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookish2.Models.Copy", b =>
                {
                    b.HasOne("Bookish2.Models.Book", null)
                        .WithMany("CheckedOutCopies")
                        .HasForeignKey("BookId");

                    b.HasOne("Bookish2.Models.Book", null)
                        .WithMany("Copies")
                        .HasForeignKey("BookId1");

                    b.HasOne("Bookish2.Models.Member", "Member")
                        .WithMany("CopiesCheckedOut")
                        .HasForeignKey("MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Bookish2.Models.Book", b =>
                {
                    b.Navigation("CheckedOutCopies");

                    b.Navigation("Copies");
                });

            modelBuilder.Entity("Bookish2.Models.Member", b =>
                {
                    b.Navigation("CopiesCheckedOut");
                });
#pragma warning restore 612, 618
        }
    }
}
