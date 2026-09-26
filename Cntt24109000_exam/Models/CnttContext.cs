using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cntt24109000_exam.Models;

public partial class CnttContext : DbContext
{
    public CnttContext()
    {
    }

    public CnttContext(DbContextOptions<CnttContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CnttEmployee> CnttEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-V8L8F0M\\SQLEXPRESS;Database=Cntt;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CnttEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CnttEmpl__3213E83FB4FD11D0");

            entity.ToTable("CnttEmployee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CnttEmail).HasMaxLength(100);
            entity.Property(e => e.CnttGender).HasMaxLength(50);
            entity.Property(e => e.CnttName).HasMaxLength(100);
            entity.Property(e => e.CnttPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
