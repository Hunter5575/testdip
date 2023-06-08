using System;
using System.Collections.Generic;
using DEADSADBD.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DEADSADBD.Database
{
    public partial class EfModel : DbContext
    {
        private static EfModel Inst;
        public static EfModel Init()
        {
            if (Inst == null)
                Inst = new EfModel();
            return Inst;
        }
        public EfModel()
        {
        }

        public EfModel(DbContextOptions<EfModel> options)
            : base(options)
        {
        }

        public virtual DbSet<Datum> Data { get; set; } = null!;
        public virtual DbSet<Deti> Detis { get; set; } = null!;
        public virtual DbSet<Grup> Grups { get; set; } = null!;
        public virtual DbSet<Polzov> Polzovs { get; set; } = null!;
        public virtual DbSet<Roll> Rolls { get; set; } = null!;
        public virtual DbSet<Vospit> Vospits { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=ISPr22-43_BiyanovDA;password=ISPr22-43_BiyanovDA;database=ISPr22-43_BiyanovDA_DS_BY_v2;character set=utf8", ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Datum>(entity =>
            {
                entity.HasKey(e => e.IdData)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdData).HasColumnName("idData");
            });

            modelBuilder.Entity<Deti>(entity =>
            {
                entity.HasKey(e => e.IdDeti)
                    .HasName("PRIMARY");

                entity.ToTable("Deti");

                entity.HasIndex(e => e.Data, "Data_idx");

                entity.HasIndex(e => e.Grup, "Grup_idx");

                entity.Property(e => e.IdDeti).HasColumnName("idDeti");

                entity.Property(e => e.Fio)
                    .HasMaxLength(80)
                    .HasColumnName("FIO");

                entity.Property(e => e.Status).HasMaxLength(45);

                entity.HasOne(d => d.DataNavigation)
                    .WithMany(p => p.Detis)
                    .HasForeignKey(d => d.Data)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Data");

                entity.HasOne(d => d.GrupNavigation)
                    .WithMany(p => p.Detis)
                    .HasForeignKey(d => d.Grup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Grup");
            });

            modelBuilder.Entity<Grup>(entity =>
            {
                entity.HasKey(e => e.IdGrup)
                    .HasName("PRIMARY");

                entity.ToTable("Grup");

                entity.HasIndex(e => e.Vospit, "Vosp_idx");

                entity.Property(e => e.IdGrup).HasColumnName("idGrup");

                entity.HasOne(d => d.VospitNavigation)
                    .WithMany(p => p.Grups)
                    .HasForeignKey(d => d.Vospit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vosp");
            });

            modelBuilder.Entity<Polzov>(entity =>
            {
                entity.HasKey(e => e.IdPolzov)
                    .HasName("PRIMARY");

                entity.ToTable("Polzov");

                entity.HasIndex(e => e.IdRoll, "idRol_idx");

                entity.Property(e => e.IdPolzov).HasColumnName("idPolzov");

                entity.Property(e => e.Fio)
                    .HasMaxLength(80)
                    .HasColumnName("FIO");

                entity.Property(e => e.Login).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(45);

                entity.Property(e => e.Pochta).HasMaxLength(45);

                entity.HasOne(d => d.IdRollNavigation)
                    .WithMany(p => p.Polzovs)
                    .HasForeignKey(d => d.IdRoll)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idRol");
            });

            modelBuilder.Entity<Roll>(entity =>
            {
                entity.HasKey(e => e.IdRoll)
                    .HasName("PRIMARY");

                entity.ToTable("Roll");

                entity.Property(e => e.IdRoll).HasColumnName("idRoll");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<Vospit>(entity =>
            {
                entity.HasKey(e => e.IdVospit)
                    .HasName("PRIMARY");

                entity.ToTable("Vospit");

                entity.HasIndex(e => e.IdRols, "Idrolls_idx");

                entity.Property(e => e.IdVospit).HasColumnName("idVospit");

                entity.Property(e => e.Fio)
                    .HasMaxLength(80)
                    .HasColumnName("FIO");

                entity.Property(e => e.Grup).HasMaxLength(45);

                entity.Property(e => e.Login).HasMaxLength(45);

                entity.Property(e => e.Passvord).HasMaxLength(45);

                entity.HasOne(d => d.IdRolsNavigation)
                    .WithMany(p => p.Vospits)
                    .HasForeignKey(d => d.IdRols)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Idrolls");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
