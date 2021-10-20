﻿// <auto-generated />
using System;
using Memos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Memos.Migrations
{
    [DbContext(typeof(MemoContext))]
    [Migration("20211014120129_GetMemoByID")]
    partial class GetMemoByID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Memos.Models.Creator", b =>
                {
                    b.Property<int>("CreatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CreatorID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("CreatorId");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("Memos.Models.Memo", b =>
                {
                    b.Property<int>("MemoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MemoID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int")
                        .HasColumnName("CreatorID");

                    b.Property<DateTime?>("ExpiredDate")
                        .HasColumnType("datetime");

                    b.Property<string>("MemoBody")
                        .HasMaxLength(280)
                        .IsUnicode(false)
                        .HasColumnType("varchar(280)");

                    b.Property<string>("MemoHeader")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.HasKey("MemoId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Memos");
                });

            modelBuilder.Entity("Memos.Models.Memo", b =>
                {
                    b.HasOne("Memos.Models.Creator", "Creator")
                        .WithMany("Memos")
                        .HasForeignKey("CreatorId")
                        .HasConstraintName("FK__Memos__CreatorID__398D8EEE");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Memos.Models.Creator", b =>
                {
                    b.Navigation("Memos");
                });
#pragma warning restore 612, 618
        }
    }
}
