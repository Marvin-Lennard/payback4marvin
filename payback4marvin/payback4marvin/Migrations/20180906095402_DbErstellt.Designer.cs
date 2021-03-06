﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using payback4marvin;

namespace payback4marvin.Migrations
{
    [DbContext(typeof(PayBackContext))]
    [Migration("20180906095402_DbErstellt")]
    partial class DbErstellt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("payback4marvin.Model.Verbecher", b =>
                {
                    b.Property<int>("VerbrecherId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Geburtstag");

                    b.Property<string>("Nachname");

                    b.Property<string>("Vorname");

                    b.HasKey("VerbrecherId");

                    b.ToTable("VerbrecherDb");
                });

            modelBuilder.Entity("payback4marvin.Model.Vergehen", b =>
                {
                    b.Property<int>("VergehenId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bezeichnung");

                    b.Property<int>("Stärke");

                    b.Property<DateTimeOffset>("TatZeitpunkt");

                    b.Property<int>("VerbrecherId");

                    b.HasKey("VergehenId");

                    b.ToTable("VergehenDb");
                });
#pragma warning restore 612, 618
        }
    }
}
