using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Models;

public partial class SchoolSystemContext : DbContext
{
    public SchoolSystemContext()
    {
    }

    public SchoolSystemContext(DbContextOptions<SchoolSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Equipment> Equipments { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventSpeaker> EventSpeakers { get; set; }

    public virtual DbSet<NotesBoard> NotesBoards { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server =. ; Database = SchoolSystem ; Trusted_Connection = true ;MultipleActiveResultSets=true; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC074115DD84");

            entity.ToTable("Department");

            entity.HasIndex(e => e.Code, "UQ__Departme__A25C5AA731E725AA").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasMany(d => d.Events).WithMany(p => p.Depts)
                .UsingEntity<Dictionary<string, object>>(
                    "DepartmentEvent",
                    r => r.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Department_Event_Event"),
                    l => l.HasOne<Department>().WithMany()
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Department_Event_Department"),
                    j =>
                    {
                        j.HasKey("DeptId", "EventId").HasName("PK__Departme__16DCCD2F8F321DE6");
                        j.ToTable("Department_Event");
                    });

            entity.HasMany(d => d.Rooms).WithMany(p => p.Depts)
                .UsingEntity<Dictionary<string, object>>(
                    "DepartmentRoom",
                    r => r.HasOne<Room>().WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Department_Room_Room"),
                    l => l.HasOne<Department>().WithMany()
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Department_Room_Department"),
                    j =>
                    {
                        j.HasKey("DeptId", "RoomId").HasName("PK__Departme__8260E23D98FCDB77");
                        j.ToTable("Department_Room");
                    });
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Donation__3214EC07329D09E4");

            entity.HasIndex(e => e.Code, "UQ__Donation__A25C5AA78C8F56BC").IsUnique();

            entity.Property(e => e.BaymantWay).HasMaxLength(20);
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Donor).HasMaxLength(30);
            entity.Property(e => e.DonorAddress).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.TelNumper1).HasMaxLength(30);
            entity.Property(e => e.TelNumper2).HasMaxLength(30);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07BEF5F31D");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.Code, "Eployee_Code_Unique").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Employee__A9D105347E69E6D2").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.JoiningDate).HasColumnType("date");
            entity.Property(e => e.JopName).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.TelNumper1).HasMaxLength(30);
            entity.Property(e => e.TelNumper2).HasMaxLength(30);

            entity.HasOne(d => d.Transport).WithMany(p => p.Employees)
                .HasForeignKey(d => d.TransportId)
                .HasConstraintName("FK_Employee_Transport");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equipmen__3214EC07BB5F2918");

            entity.HasIndex(e => e.Barcode, "UQ__Equipmen__177800D371AF4F03").IsUnique();

            entity.HasIndex(e => e.Code, "UQ__Equipmen__A25C5AA73CDEEB79").IsUnique();

            entity.Property(e => e.Barcode).HasMaxLength(20);
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.Room).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_RoomId");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3214EC075AAC07EE");

            entity.ToTable("Event");

            entity.HasIndex(e => e.Name, "UQ__Event__737584F6071A87CD").IsUnique();

            entity.HasIndex(e => e.Code, "UQ__Event__A25C5AA70D6A1E38").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EventSpeaker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventSpe__3214EC07EE34AD85");

            entity.ToTable("EventSpeaker");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Pictural).HasMaxLength(100);
            entity.Property(e => e.TelNumper1).HasMaxLength(30);
            entity.Property(e => e.TelNumper2).HasMaxLength(30);

            entity.HasMany(d => d.Events).WithMany(p => p.EventSpeakers)
                .UsingEntity<Dictionary<string, object>>(
                    "EventSpeakerEvent",
                    r => r.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventSpea__Event__787EE5A0"),
                    l => l.HasOne<EventSpeaker>().WithMany()
                        .HasForeignKey("EventSpeakerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventSpea__Event__778AC167"),
                    j =>
                    {
                        j.HasKey("EventSpeakerId", "EventId").HasName("PK__EventSpe__4DD1EFA716305F2F");
                        j.ToTable("EventSpeaker_Event");
                    });
        });

        modelBuilder.Entity<NotesBoard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotesBoa__3214EC072FA81DDC");

            entity.ToTable("NotesBoard");

            entity.Property(e => e.Note).HasMaxLength(100);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Room__3214EC07187530D7");

            entity.ToTable("Room");

            entity.HasIndex(e => e.Code, "Room_Code_Unique").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(20);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC0735FB5AE4");

            entity.ToTable("Student");

            entity.HasIndex(e => e.Code, "UQ__Student__A25C5AA7AE3DEB8E").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Student__A9D10534A2DC7561").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.Code).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.JoiningDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Picture).HasMaxLength(100);
            entity.Property(e => e.TelNumper1).HasMaxLength(30);
            entity.Property(e => e.TelNumper2).HasMaxLength(30);

            entity.HasOne(d => d.Dept).WithMany(p => p.Students)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_Student_Department");

            entity.HasOne(d => d.Transport).WithMany(p => p.Students)
                .HasForeignKey(d => d.TransportId)
                .HasConstraintName("FK_Student_Transport");

            entity.HasMany(d => d.Events).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentEvent",
                    r => r.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_E__Event__6477ECF3"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_E__Stude__6383C8BA"),
                    j =>
                    {
                        j.HasKey("StudentId", "EventId").HasName("PK__Student___25516718A575ABD4");
                        j.ToTable("Student_Event");
                    });

            entity.HasMany(d => d.Rooms).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentRoom",
                    r => r.HasOne<Room>().WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_R__RoomI__5CD6CB2B"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_R__Stude__5BE2A6F2"),
                    j =>
                    {
                        j.HasKey("StudentId", "RoomId").HasName("PK__Student___B1ED480A35475261");
                        j.ToTable("Student_Room");
                    });

            entity.HasMany(d => d.Subjects).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_S__Subje__60A75C0F"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_S__Stude__5FB337D6"),
                    j =>
                    {
                        j.HasKey("StudentId", "SubjectId").HasName("PK__Student___A80491A30C3512AF");
                        j.ToTable("Student_Subject");
                    });

            entity.HasMany(d => d.Teachers).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentTeacher",
                    r => r.HasOne<Teacher>().WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_T__Teach__59063A47"),
                    l => l.HasOne<Student>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Student_T__Stude__5812160E"),
                    j =>
                    {
                        j.HasKey("StudentId", "TeacherId").HasName("PK__Student___6C1A0E0F00C3A4C2");
                        j.ToTable("Student_Teacher");
                    });
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subject__3214EC0787C9457F");

            entity.ToTable("Subject");

            entity.HasIndex(e => e.Code, "UQ__Subject__A25C5AA760963876").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.Dept).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_Subject_Department");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teacher__3214EC077B72534F");

            entity.ToTable("Teacher");

            entity.HasIndex(e => e.Code, "Teacher_Code_Unique").IsUnique();

            entity.HasIndex(e => e.Email, "Teacher_Email_Unique").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.JoiningDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Picture)
                .HasMaxLength(100)
                .HasColumnName("picture");
            entity.Property(e => e.TelNumper1).HasMaxLength(30);
            entity.Property(e => e.TelNumper2).HasMaxLength(30);

            entity.HasOne(d => d.Dept).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_Teacher_Department");

            entity.HasOne(d => d.Transport).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.TransportId)
                .HasConstraintName("FK_Teacher_Transport");

            entity.HasMany(d => d.Equipments).WithMany(p => p.Teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherEquipment",
                    r => r.HasOne<Equipment>().WithMany()
                        .HasForeignKey("EquipmentsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Teacher_E__Equip__6D0D32F4"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Teacher_E__Teach__6C190EBB"),
                    j =>
                    {
                        j.HasKey("TeacherId", "EquipmentsId").HasName("PK__Teacher___F020BC04CE871320");
                        j.ToTable("Teacher_Equipments");
                    });

            entity.HasMany(d => d.Events).WithMany(p => p.Teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherEvent",
                    r => r.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Teacher_E__Event__70DDC3D8"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Teacher_E__Teach__6FE99F9F"),
                    j =>
                    {
                        j.HasKey("TeacherId", "EventId").HasName("PK__Teacher___FA6615E5AEAD5E2E");
                        j.ToTable("Teacher_Event");
                    });

            entity.HasMany(d => d.Rooms).WithMany(p => p.Teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherRoom",
                    r => r.HasOne<Room>().WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Teacher_R__RoomI__693CA210"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Teacher_R__Teach__68487DD7"),
                    j =>
                    {
                        j.HasKey("TeacherId", "RoomId").HasName("PK__Teacher___6EDA3AF740AF248E");
                        j.ToTable("Teacher_Room");
                    });

            entity.HasMany(d => d.Subjects).WithMany(p => p.Teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherSubject",
                    r => r.HasOne<Subject>().WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Teacher_S__Subje__74AE54BC"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Teacher_S__Teach__73BA3083"),
                    j =>
                    {
                        j.HasKey("TeacherId", "SubjectId").HasName("PK__Teacher___7733E35ED662F999");
                        j.ToTable("Teacher_Subject");
                    });
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transpor__3214EC07F42C3185");

            entity.ToTable("Transport");

            entity.HasIndex(e => e.Code, "UQ__Transpor__A25C5AA723DA0DD0").IsUnique();

            entity.Property(e => e.ArriveTime).HasColumnType("datetime");
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.LeaveTime).HasColumnType("datetime");
            entity.Property(e => e.VicelName).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
