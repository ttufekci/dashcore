﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Web.App.Models;

namespace Web.App.Migrations
{
    [DbContext(typeof(CustomConnectionContext))]
    [Migration("20180319070438_sessionsqlhistory")]
    partial class sessionsqlhistory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Web.App.Models.CustomConnection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Host");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Port");

                    b.Property<string>("SID");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("CustomConnection");
                });

            modelBuilder.Entity("Web.App.Models.SessionSqlHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("SessionId");

                    b.Property<string>("SqlText");

                    b.HasKey("Id");

                    b.ToTable("SessionSqlHistory");
                });

            modelBuilder.Entity("Web.App.Models.TableMetadata", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SequenceName");

                    b.Property<string>("TableName");

                    b.HasKey("Id");

                    b.ToTable("TableMetadata");
                });
#pragma warning restore 612, 618
        }
    }
}
