﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DWX2024.AppLogic.EntityFramework;

public partial class dncUserDatabaseContext : DbContext
{
    public dncUserDatabaseContext(DbContextOptions<dncUserDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPlantCode> UserPlantCodes { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.ObjectId).IsClustered(false);

            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.ObjectId).IsClustered(false);

            entity.ToTable(tb => tb.HasTrigger("Usersdelete"));

            entity.HasIndex(e => e.Email, "IX_Users").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(40);
            entity.Property(e => e.ResourceId)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.Salt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("salt");
        });

        modelBuilder.Entity<UserPlantCode>(entity =>
        {
            entity.HasKey(e => e.ObjectId);

            entity.Property(e => e.PlantCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.UserObject).WithMany(p => p.UserPlantCodes)
                .HasForeignKey(d => d.UserObjectId)
                .HasConstraintName("FK_UserPlantCodes_Users");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.ObjectId);

            entity.HasOne(d => d.RoleObject).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleObjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Roles");

            entity.HasOne(d => d.UserObject).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserObjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}