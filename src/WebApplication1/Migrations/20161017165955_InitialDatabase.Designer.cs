﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TheWorld.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(WorldContext))]
    [Migration("20161017165955_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TheWorld.Models.Stop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("TripId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("TheWorld.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("UserName");

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TheWorld.Models.Stop", b =>
                {
                    b.HasOne("TheWorld.Models.Trip")
                        .WithMany("Stops")
                        .HasForeignKey("TripId");
                });
        }
    }
}
