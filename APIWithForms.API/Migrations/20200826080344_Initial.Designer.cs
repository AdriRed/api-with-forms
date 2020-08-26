﻿// <auto-generated />
using APIWithForms.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIWithForms.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200826080344_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.8.20407.4");

            modelBuilder.Entity("APIWithForms.Entities.UserColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Alpha")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Blue")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Green")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Red")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("UserColors");
                });
#pragma warning restore 612, 618
        }
    }
}