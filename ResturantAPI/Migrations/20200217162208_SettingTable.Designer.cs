﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResturantAPI.Models;

namespace ResturantAPI.Migrations
{
    [DbContext(typeof(ResturantDbContext))]
    [Migration("20200217162208_SettingTable")]
    partial class SettingTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ResturantAPI.Models.BE.Articles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionSeo");

                    b.Property<string>("Image");

                    b.Property<bool>("IsPublic");

                    b.Property<string>("KeywordsSeo");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("Slug");

                    b.Property<string>("TitleSeo");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("ResturantAPI.Models.BE.Categorys", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionSeo");

                    b.Property<bool>("IsMenu");

                    b.Property<bool>("IsPublic");

                    b.Property<string>("KeywordsSeo");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("TitleSeo");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("ResturantAPI.Models.BE.Editors", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ArticlesId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Editors");
                });

            modelBuilder.Entity("ResturantAPI.Models.BE.Logos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsBlack");

                    b.Property<bool>("IsPublic");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Logos");
                });

            modelBuilder.Entity("ResturantAPI.Models.BE.Setting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("BodyTab");

                    b.Property<string>("CommanyName");

                    b.Property<string>("CopyRight");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DescriptionSeo");

                    b.Property<string>("Email");

                    b.Property<string>("Facebook");

                    b.Property<string>("Google");

                    b.Property<string>("GoogleAnalytic");

                    b.Property<string>("HeadTab");

                    b.Property<string>("HotLine");

                    b.Property<string>("KeywordsSeo");

                    b.Property<string>("Location");

                    b.Property<string>("Slogan");

                    b.Property<string>("TitleSeo");

                    b.Property<string>("Twitter");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Website");

                    b.Property<string>("Youtube");

                    b.HasKey("Id");

                    b.ToTable("Setting");
                });
#pragma warning restore 612, 618
        }
    }
}
