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
    [Migration("20180312200212_RackAndSlot")]
    partial class RackAndSlot
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

                    b.HasKey("ID");

                    b.ToTable("Wines");
                });
#pragma warning restore 612, 618
        }
    }
}
