﻿// <auto-generated />
using System;
using ConversationService.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConversationService.Entity.Migrations
{
    [DbContext(typeof(ConversationContext))]
    [Migration("20221127133907_AddingMeetingIdColumn")]
    partial class AddingMeetingIdColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConversationService.Entity.Models.Conversation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("ClosedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConversationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndMeetingDate")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2");

                    b.Property<int>("MeetingId")
                        .HasColumnType("int");

                    b.Property<string>("MeetingTopic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Messages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartMeetingDate")
                        .HasMaxLength(20)
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ConversationDetails", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
