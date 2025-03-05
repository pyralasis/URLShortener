﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShortenerAPI.Models;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(ShortenerContext))]
    [Migration("20250301003015_InitialCreate2")]
    partial class InitialCreate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("ShortenerAPI.Models.ShortenedURL", b =>
                {
                    b.Property<string>("ShortURLId")
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginalURL")
                        .HasColumnType("TEXT");

                    b.HasKey("ShortURLId", "OriginalURL");

                    b.ToTable("ShortenedURLs");
                });
#pragma warning restore 612, 618
        }
    }
}
