using Microsoft.EntityFrameworkCore;


namespace WeApiEntityFramework.Models
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<RentalOrders> RentalOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasKey(e => e.PlateNumber)
                    .HasName("PK__Cars__0369262514DFFCB6");

                entity.Property(e => e.PlateNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Available)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CarYear).HasColumnType("date");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Condition)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Cars__CategoryId__276EDEB3");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryName)
                    .HasName("PK__Categori__8517B2E1ABC7FD69");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DailyRate).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MonthlyRate).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WeekendRate).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WeeklyRate).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.DriverLicenceNumber)
                    .HasName("PK__Customer__9EB642A9D78C5B23");

                entity.Property(e => e.DriverLicenceNumber).ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RentalOrders>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CarId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RateApplied).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TaxRate).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.RentalOrders)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__RentalOrd__CarId__36B12243");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RentalOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__RentalOrd__Custo__32E0915F");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RentalOrders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__RentalOrd__Emplo__34C8D9D1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
