using System;
using System.Collections.Generic;
using DormitoryManagementSystem.Entity;
using Microsoft.EntityFrameworkCore;

namespace DormitoryManagementSystem.DAO.Context;

public partial class PostgreDbContext : DbContext
{
    public PostgreDbContext()
    {
    }

    public PostgreDbContext(DbContextOptions<PostgreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Violation> Violations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=QL_KTX_V10;Username=postgres;Password=Abc123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Adminid).HasName("admins_pkey");

            entity.ToTable("admins");

            entity.HasIndex(e => e.Idcard, "admins_idcard_key").IsUnique();

            entity.HasIndex(e => e.Userid, "admins_userid_key").IsUnique();

            entity.Property(e => e.Adminid)
                .HasMaxLength(10)
                .HasColumnName("adminid");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Idcard)
                .HasMaxLength(12)
                .HasColumnName("idcard");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(15)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Userid)
                .HasMaxLength(10)
                .HasColumnName("userid");

            entity.HasOne(d => d.User).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.Userid)
                .HasConstraintName("fk_admins_users");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.Buildingid).HasName("buildings_pkey");

            entity.ToTable("buildings");

            entity.Property(e => e.Buildingid)
                .HasMaxLength(10)
                .HasColumnName("buildingid");
            entity.Property(e => e.Buildingname)
                .HasMaxLength(50)
                .HasColumnName("buildingname");
            entity.Property(e => e.Currentoccupancy)
                .HasDefaultValue(0)
                .HasColumnName("currentoccupancy");
            entity.Property(e => e.Gendertype)
                .HasMaxLength(10)
                .HasColumnName("gendertype");
            entity.Property(e => e.Numberofroom).HasColumnName("numberofroom");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Contractid).HasName("contracts_pkey");

            entity.ToTable("contracts");

            entity.Property(e => e.Contractid)
                .HasMaxLength(10)
                .HasColumnName("contractid");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Endtime).HasColumnName("endtime");
            entity.Property(e => e.Roomid)
                .HasMaxLength(10)
                .HasColumnName("roomid");
            entity.Property(e => e.Staffuserid)
                .HasMaxLength(10)
                .HasColumnName("staffuserid");
            entity.Property(e => e.Starttime).HasColumnName("starttime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Active'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.Studentid)
                .HasMaxLength(10)
                .HasColumnName("studentid");

            entity.HasOne(d => d.Room).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Roomid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contracts_rooms");

            entity.HasOne(d => d.Staffuser).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Staffuserid)
                .HasConstraintName("fk_contracts_users");

            entity.HasOne(d => d.Student).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Studentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contracts_students");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Newsid).HasName("news_pkey");

            entity.ToTable("news");

            entity.Property(e => e.Newsid)
                .HasMaxLength(10)
                .HasColumnName("newsid");
            entity.Property(e => e.Authorid)
                .HasMaxLength(10)
                .HasColumnName("authorid");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Isvisible)
                .HasDefaultValue(true)
                .HasColumnName("isvisible");
            entity.Property(e => e.Priority)
                .HasDefaultValue(0)
                .HasColumnName("priority");
            entity.Property(e => e.Publisheddate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("publisheddate");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.News)
                .HasForeignKey(d => d.Authorid)
                .HasConstraintName("fk_news_users");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("payments_pkey");

            entity.ToTable("payments");

            entity.Property(e => e.Paymentid)
                .HasMaxLength(10)
                .HasColumnName("paymentid");
            entity.Property(e => e.Billmonth).HasColumnName("billmonth");
            entity.Property(e => e.Contractid)
                .HasMaxLength(10)
                .HasColumnName("contractid");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Paidamount)
                .HasPrecision(10, 2)
                .HasColumnName("paidamount");
            entity.Property(e => e.Paymentamount)
                .HasPrecision(10, 2)
                .HasColumnName("paymentamount");
            entity.Property(e => e.Paymentdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("paymentdate");
            entity.Property(e => e.Paymentmethod)
                .HasMaxLength(20)
                .HasColumnName("paymentmethod");
            entity.Property(e => e.Paymentstatus)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Unpaid'::character varying")
                .HasColumnName("paymentstatus");

            entity.HasOne(d => d.Contract).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Contractid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_payments_contracts");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Roomid).HasName("rooms_pkey");

            entity.ToTable("rooms");

            entity.Property(e => e.Roomid)
                .HasMaxLength(10)
                .HasColumnName("roomid");
            entity.Property(e => e.Airconditioner)
                .HasDefaultValue(false)
                .HasColumnName("airconditioner");
            entity.Property(e => e.Allowcooking)
                .HasDefaultValue(false)
                .HasColumnName("allowcooking");
            entity.Property(e => e.Buildingid)
                .HasMaxLength(10)
                .HasColumnName("buildingid");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Currentoccupancy)
                .HasDefaultValue(0)
                .HasColumnName("currentoccupancy");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Roomnumber).HasColumnName("roomnumber");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Active'::character varying")
                .HasColumnName("status");

            entity.HasOne(d => d.Building).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Buildingid)
                .HasConstraintName("fk_rooms_buildings");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("students_pkey");

            entity.ToTable("students");

            entity.HasIndex(e => e.Email, "students_email_key").IsUnique();

            entity.HasIndex(e => e.Idcard, "students_idcard_key").IsUnique();

            entity.HasIndex(e => e.Userid, "students_userid_key").IsUnique();

            entity.Property(e => e.Studentid)
                .HasMaxLength(10)
                .HasColumnName("studentid");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Dateofbirth).HasColumnName("dateofbirth");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Idcard)
                .HasMaxLength(12)
                .HasColumnName("idcard");
            entity.Property(e => e.Major)
                .HasMaxLength(100)
                .HasColumnName("major");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(15)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Userid)
                .HasMaxLength(10)
                .HasColumnName("userid");

            entity.HasOne(d => d.User).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.Userid)
                .HasConstraintName("fk_students_users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Userid)
                .HasMaxLength(10)
                .HasColumnName("userid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Violation>(entity =>
        {
            entity.HasKey(e => e.Violationid).HasName("violations_pkey");

            entity.ToTable("violations");

            entity.Property(e => e.Violationid)
                .HasMaxLength(10)
                .HasColumnName("violationid");
            entity.Property(e => e.Penaltyfee)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("penaltyfee");
            entity.Property(e => e.Reportedbyuserid)
                .HasMaxLength(10)
                .HasColumnName("reportedbyuserid");
            entity.Property(e => e.Roomid)
                .HasMaxLength(10)
                .HasColumnName("roomid");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Pending'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.Studentid)
                .HasMaxLength(10)
                .HasColumnName("studentid");
            entity.Property(e => e.Violationdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("violationdate");
            entity.Property(e => e.Violationtype)
                .HasMaxLength(100)
                .HasColumnName("violationtype");

            entity.HasOne(d => d.Reportedbyuser).WithMany(p => p.Violations)
                .HasForeignKey(d => d.Reportedbyuserid)
                .HasConstraintName("fk_violations_users");

            entity.HasOne(d => d.Room).WithMany(p => p.Violations)
                .HasForeignKey(d => d.Roomid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_violations_rooms");

            entity.HasOne(d => d.Student).WithMany(p => p.Violations)
                .HasForeignKey(d => d.Studentid)
                .HasConstraintName("fk_violations_students");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
