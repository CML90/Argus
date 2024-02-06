﻿// <auto-generated />
using System.Text.Json;
using Cardano.Sync.Example.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cardano.Sync.Example.Migrations
{
    [DbContext(typeof(CardanoTestDbContext))]
    [Migration("20240206201044_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("cardanoindexer")
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cardano.Sync.Data.Models.Block", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<decimal>("Number")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("Slot")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id", "Number", "Slot");

                    b.ToTable("Blocks", "cardanoindexer");
                });

            modelBuilder.Entity("Cardano.Sync.Data.Models.TransactionOutput", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<long>("Index")
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Slot")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id", "Index");

                    b.ToTable("TransactionOutputs", "cardanoindexer");
                });

            modelBuilder.Entity("Cardano.Sync.Data.Models.TransactionOutput", b =>
                {
                    b.OwnsOne("Cardano.Sync.Data.Models.Datum", "Datum", b1 =>
                        {
                            b1.Property<string>("TransactionOutputId")
                                .HasColumnType("text");

                            b1.Property<long>("TransactionOutputIndex")
                                .HasColumnType("bigint");

                            b1.Property<byte[]>("Data")
                                .IsRequired()
                                .HasColumnType("bytea");

                            b1.Property<int>("Type")
                                .HasColumnType("integer");

                            b1.HasKey("TransactionOutputId", "TransactionOutputIndex");

                            b1.ToTable("TransactionOutputs", "cardanoindexer");

                            b1.WithOwner()
                                .HasForeignKey("TransactionOutputId", "TransactionOutputIndex");
                        });

                    b.OwnsOne("Cardano.Sync.Data.Models.Value", "Amount", b1 =>
                        {
                            b1.Property<string>("TransactionOutputId")
                                .HasColumnType("text");

                            b1.Property<long>("TransactionOutputIndex")
                                .HasColumnType("bigint");

                            b1.Property<decimal>("Coin")
                                .HasColumnType("numeric(20,0)");

                            b1.Property<JsonElement>("MultiAssetJson")
                                .HasColumnType("jsonb");

                            b1.HasKey("TransactionOutputId", "TransactionOutputIndex");

                            b1.ToTable("TransactionOutputs", "cardanoindexer");

                            b1.WithOwner()
                                .HasForeignKey("TransactionOutputId", "TransactionOutputIndex");
                        });

                    b.Navigation("Amount")
                        .IsRequired();

                    b.Navigation("Datum");
                });
#pragma warning restore 612, 618
        }
    }
}
