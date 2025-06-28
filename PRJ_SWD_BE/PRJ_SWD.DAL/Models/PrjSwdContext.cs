using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PRJ_SWD.DAL.Models;

public partial class PrjSwdContext : DbContext
{
    public PrjSwdContext()
    {
    }

    public PrjSwdContext(DbContextOptions<PrjSwdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<MedicalExamination> MedicalExaminations { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<OrderBill> OrderBills { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Slider> Sliders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine(Directory.GetCurrentDirectory());
        IConfiguration config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .Build();
        var strConn = config["ConnectionStrings:MyDatabase"];
        optionsBuilder.UseSqlServer(strConn);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK_PersonAccount");

            entity.ToTable("Account");

            entity.Property(e => e.Address).HasMaxLength(1000);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(1000);
            entity.Property(e => e.Password).HasMaxLength(1000);
            entity.Property(e => e.PersonName).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Role");

            entity.HasMany(d => d.Services).WithMany(p => p.People)
                .UsingEntity<Dictionary<string, object>>(
                    "PersonsService",
                    r => r.HasOne<Service>().WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Persons_Services_Service"),
                    l => l.HasOne<Account>().WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Persons_Services_Account"),
                    j =>
                    {
                        j.HasKey("PersonId", "ServiceId");
                        j.ToTable("Persons_Services");
                    });
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("Blog");

            entity.Property(e => e.Content).HasMaxLength(1000);
            entity.Property(e => e.CreatedDate).HasColumnName("Created_Date");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Image).HasMaxLength(1000);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog_Category");

            entity.HasOne(d => d.Person).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog_Account");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback");

            entity.Property(e => e.Content).HasMaxLength(255);
            entity.Property(e => e.ResponseFeedback).HasMaxLength(255);

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_Account");

            entity.HasOne(d => d.Service).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_Service");
        });

        modelBuilder.Entity<MedicalExamination>(entity =>
        {
            entity.HasKey(e => e.Meid);

            entity.ToTable("MedicalExamination");

            entity.Property(e => e.Meid).HasColumnName("MEId");
            entity.Property(e => e.Diagnosis).HasMaxLength(255);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.Symptoms).HasMaxLength(255);

            entity.HasOne(d => d.Customer).WithMany(p => p.MedicalExaminationCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerId");

            entity.HasOne(d => d.Staff).WithMany(p => p.MedicalExaminationStaffs)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StaffId");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.ToTable("Medicine");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<OrderBill>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("Order_Bill");

            entity.HasOne(d => d.Reservation).WithMany(p => p.OrderBills)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Bill_Reservation");

            entity.HasOne(d => d.Schedule).WithMany(p => p.OrderBills)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Bill_Schedule");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.CreateAt).HasColumnName("Create_At");

            entity.HasOne(d => d.Person).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Account");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.ToTable("Prescription");

            entity.Property(e => e.Dosage).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(255);

            entity.HasOne(d => d.Examination).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.ExaminationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_MedicalExamination");

            entity.HasOne(d => d.Medicine).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_Medicine");

            entity.HasMany(d => d.Orders).WithMany(p => p.Prescriptions)
                .UsingEntity<Dictionary<string, object>>(
                    "PrescriptionOrder",
                    r => r.HasOne<OrderBill>().WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Prescription_Order_Order_Bill"),
                    l => l.HasOne<Prescription>().WithMany()
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Prescription_Order_Prescription"),
                    j =>
                    {
                        j.HasKey("PrescriptionId", "OrderId");
                        j.ToTable("Prescription_Order");
                    });
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.ToTable("Reservation");

            entity.Property(e => e.CreatedDate).HasColumnName("Created_Date");
            entity.Property(e => e.Note).HasMaxLength(255);

            entity.HasOne(d => d.Customer).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_Account_Customer");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.ToTable("Schedule");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Detail).HasMaxLength(1000);
            entity.Property(e => e.Duration).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(1000);
            entity.Property(e => e.ServiceName).HasMaxLength(50);

            entity.HasOne(d => d.Manager).WithMany(p => p.ServicesNavigation)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Service_Account");

            entity.HasMany(d => d.Orders).WithMany(p => p.Services)
                .UsingEntity<Dictionary<string, object>>(
                    "ServicesOrder",
                    r => r.HasOne<OrderBill>().WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Services_Orders_Order_Bill"),
                    l => l.HasOne<Service>().WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Services_Orders_Service"),
                    j =>
                    {
                        j.HasKey("ServiceId", "OrderId");
                        j.ToTable("Services_Orders");
                    });

            entity.HasMany(d => d.Prescriptions).WithMany(p => p.Services)
                .UsingEntity<Dictionary<string, object>>(
                    "ServicesPrescription",
                    r => r.HasOne<Prescription>().WithMany()
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Services_Prescriptions_Prescription"),
                    l => l.HasOne<Service>().WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Services_Prescriptions_Service"),
                    j =>
                    {
                        j.HasKey("ServiceId", "PrescriptionId");
                        j.ToTable("Services_Prescriptions");
                    });

            entity.HasMany(d => d.Reservations).WithMany(p => p.Services)
                .UsingEntity<Dictionary<string, object>>(
                    "ServicesReservation",
                    r => r.HasOne<Reservation>().WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Services_Reservations_Reservation"),
                    l => l.HasOne<Service>().WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Services_Reservations_Service"),
                    j =>
                    {
                        j.HasKey("ServiceId", "ReservationId");
                        j.ToTable("Services_Reservations");
                    });
        });

        modelBuilder.Entity<Slider>(entity =>
        {
            entity.ToTable("Slider");

            entity.Property(e => e.Backlink).HasMaxLength(1000);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Image).HasMaxLength(1000);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Person).WithMany(p => p.Sliders)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Slider_Account");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
