﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WineFridge.Data;

namespace WineFridge.Migrations
{
    [DbContext(typeof(WineDbContext))]
    [Migration("20180313152501_WineFridge0_3")]
    partial class WineFridge0_3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WineFridge.Models.Wine", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<string>("Description");

                    b.Property<bool>("InStock");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Rack");

                    b.Property<int>("Rating");

                    b.Property<string>("Slot");

                    b.Property<int>("TypeID");

                    b.Property<int>("WineryID");

                    b.HasKey("ID");

                    b.ToTable("Wines");
                });

            modelBuilder.Entity("WineFridge.Models.Winery", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("Wineries");
                });

            modelBuilder.Entity("WineFridge.Models.WineType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("WineTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
