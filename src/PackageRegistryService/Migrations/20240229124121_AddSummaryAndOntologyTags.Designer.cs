﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PackageRegistryService.Models;

#nullable disable

namespace PackageRegistryService.Migrations
{
    [DbContext(typeof(ValidationPackageDb))]
    [Migration("20240229124121_AddSummaryAndOntologyTags")]
    partial class AddSummaryAndOntologyTags
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PackageRegistryService.Models.PackageContentHash", b =>
                {
                    b.Property<string>("PackageName")
                        .HasColumnType("text");

                    b.Property<int>("PackageMajorVersion")
                        .HasColumnType("integer");

                    b.Property<int>("PackageMinorVersion")
                        .HasColumnType("integer");

                    b.Property<int>("PackagePatchVersion")
                        .HasColumnType("integer");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PackageName", "PackageMajorVersion", "PackageMinorVersion", "PackagePatchVersion");

                    b.ToTable("Hashes");
                });

            modelBuilder.Entity("PackageRegistryService.Models.ValidationPackage", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("MajorVersion")
                        .HasColumnType("integer");

                    b.Property<int>("MinorVersion")
                        .HasColumnType("integer");

                    b.Property<int>("PatchVersion")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PackageContent")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("ReleaseNotes")
                        .HasColumnType("text");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Name", "MajorVersion", "MinorVersion", "PatchVersion");

                    b.ToTable("ValidationPackages");
                });

            modelBuilder.Entity("PackageRegistryService.Models.ValidationPackage", b =>
                {
                    b.OwnsMany("AVPRIndex.Domain+Author", "Authors", b1 =>
                        {
                            b1.Property<string>("ValidationPackageName")
                                .HasColumnType("text");

                            b1.Property<int>("ValidationPackageMajorVersion")
                                .HasColumnType("integer");

                            b1.Property<int>("ValidationPackageMinorVersion")
                                .HasColumnType("integer");

                            b1.Property<int>("ValidationPackagePatchVersion")
                                .HasColumnType("integer");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            b1.Property<string>("Affiliation")
                                .HasColumnType("text");

                            b1.Property<string>("AffiliationLink")
                                .HasColumnType("text");

                            b1.Property<string>("Email")
                                .HasColumnType("text");

                            b1.Property<string>("FullName")
                                .HasColumnType("text");

                            b1.HasKey("ValidationPackageName", "ValidationPackageMajorVersion", "ValidationPackageMinorVersion", "ValidationPackagePatchVersion", "Id");

                            b1.ToTable("ValidationPackages");

                            b1.ToJson("Authors");

                            b1.WithOwner()
                                .HasForeignKey("ValidationPackageName", "ValidationPackageMajorVersion", "ValidationPackageMinorVersion", "ValidationPackagePatchVersion");
                        });

                    b.OwnsMany("AVPRIndex.Domain+OntologyAnnotation", "Tags", b1 =>
                        {
                            b1.Property<string>("ValidationPackageName")
                                .HasColumnType("text");

                            b1.Property<int>("ValidationPackageMajorVersion")
                                .HasColumnType("integer");

                            b1.Property<int>("ValidationPackageMinorVersion")
                                .HasColumnType("integer");

                            b1.Property<int>("ValidationPackagePatchVersion")
                                .HasColumnType("integer");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.Property<string>("TermAccessionNumber")
                                .HasColumnType("text");

                            b1.Property<string>("TermSourceREF")
                                .HasColumnType("text");

                            b1.HasKey("ValidationPackageName", "ValidationPackageMajorVersion", "ValidationPackageMinorVersion", "ValidationPackagePatchVersion", "Id");

                            b1.ToTable("ValidationPackages");

                            b1.ToJson("Tags");

                            b1.WithOwner()
                                .HasForeignKey("ValidationPackageName", "ValidationPackageMajorVersion", "ValidationPackageMinorVersion", "ValidationPackagePatchVersion");
                        });

                    b.Navigation("Authors");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
