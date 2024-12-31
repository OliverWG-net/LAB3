using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LAB3;

public partial class LAB2Context : DbContext
{
    public LAB2Context()
    {
    }

    public LAB2Context(DbContextOptions<LAB2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Betyg> Betygs { get; set; }

    public virtual DbSet<Klass> Klasses { get; set; }

    public virtual DbSet<Kur> Kurs { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<PersonalListum> PersonalLista { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LAB2;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Betyg>(entity =>
        {
            entity.HasKey(e => e.BetygId).HasName("PK__Betyg__E90ED04896A6D329");

            entity.ToTable("Betyg");

            entity.Property(e => e.BetygId).HasColumnName("BetygID");
            entity.Property(e => e.Betyg1).HasColumnName("Betyg");
            entity.Property(e => e.FkKursId).HasColumnName("FkKursID");
            entity.Property(e => e.LärareId).HasColumnName("LärareID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.FkKurs).WithMany(p => p.Betygs)
                .HasForeignKey(d => d.FkKursId)
                .HasConstraintName("FK__Betyg__KursID__3C69FB99");

            entity.HasOne(d => d.Lärare).WithMany(p => p.Betygs)
                .HasForeignKey(d => d.LärareId)
                .HasConstraintName("FK__Betyg__LärareID__3D5E1FD2");

            entity.HasOne(d => d.Student).WithMany(p => p.Betygs)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Betyg__StudentID__3B75D760");
        });

        modelBuilder.Entity<Klass>(entity =>
        {
            entity.HasKey(e => e.KlassId).HasName("PK__Klass__CF47A60D67C4207F");

            entity.ToTable("Klass");

            entity.Property(e => e.KlassId).HasColumnName("KlassID");
            entity.Property(e => e.KlassNamn).HasMaxLength(25);
        });

        modelBuilder.Entity<Kur>(entity =>
        {
            entity.HasKey(e => e.KursId).HasName("PK__Kurs__BCCFFF3B29239B38");

            entity.Property(e => e.KursId).HasColumnName("KursID");
            entity.Property(e => e.Aktiv).HasDefaultValue(true);
            entity.Property(e => e.FkLärareId).HasColumnName("FkLärareID");
            entity.Property(e => e.KursNamn).HasMaxLength(30);

            entity.HasOne(d => d.FkLärare).WithMany(p => p.Kurs)
                .HasForeignKey(d => d.FkLärareId)
                .HasConstraintName("FK__Kurs__LärareID__38996AB5");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.PersonalId).HasName("PK__Personal__283437138200A955");

            entity.ToTable("Personal");

            entity.Property(e => e.PersonalId).HasColumnName("PersonalID");
            entity.Property(e => e.Avdelning).HasMaxLength(30);
            entity.Property(e => e.Fnamn)
                .HasMaxLength(30)
                .HasColumnName("FNamn");
            entity.Property(e => e.Lnamn)
                .HasMaxLength(30)
                .HasColumnName("LNamn");
            entity.Property(e => e.Personnummer).HasMaxLength(20);
            entity.Property(e => e.Position).HasMaxLength(30);
        });

        modelBuilder.Entity<PersonalListum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PersonalLista");

            entity.Property(e => e.AntalÅr).HasColumnName("Antal år");
            entity.Property(e => e.Fnamn)
                .HasMaxLength(30)
                .HasColumnName("FNamn");
            entity.Property(e => e.Lnamn)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("LNamn");
            entity.Property(e => e.Position).HasMaxLength(30);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A79BB031664");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.FkKlassId).HasColumnName("FkKlassID");
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.Personnummer).HasMaxLength(15);

            entity.HasOne(d => d.FkKlass).WithMany(p => p.Students)
                .HasForeignKey(d => d.FkKlassId)
                .HasConstraintName("FK__Student__KlassID__35BCFE0A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
