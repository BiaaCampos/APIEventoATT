﻿// <auto-generated />
using System;
using DDD.Infra.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDD.Infra.SQLServer.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DDD.Domain.GeralContext.Comprador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RA")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Compradores");
                });

            modelBuilder.Entity("DDD.Domain.GeralContext.Eventos", b =>
                {
                    b.Property<int>("EventosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventosId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IngressosDisponiveis")
                        .HasColumnType("int");

                    b.Property<string>("LocalEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ValorIngresso")
                        .HasColumnType("real");

                    b.HasKey("EventosId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("DDD.Domain.GeralContext.Venda", b =>
                {
                    b.Property<int>("VendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendaId"));

                    b.Property<int>("CompradoresId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventosId")
                        .HasColumnType("int");

                    b.Property<int>("QtdIngresso")
                        .HasColumnType("int");

                    b.HasKey("VendaId");

                    b.HasIndex("CompradoresId");

                    b.HasIndex("EventosId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("DDD.Domain.GeralContext.Venda", b =>
                {
                    b.HasOne("DDD.Domain.GeralContext.Comprador", "Compradores")
                        .WithMany()
                        .HasForeignKey("CompradoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDD.Domain.GeralContext.Eventos", "Eventos")
                        .WithMany()
                        .HasForeignKey("EventosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compradores");

                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
