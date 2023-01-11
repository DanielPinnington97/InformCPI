using Microsoft.EntityFrameworkCore;

namespace InformCPISolution.Data
{
    public partial class InformCPIDBContext : DbContext
    {
        public InformCPIDBContext(DbContextOptions<InformCPIDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactModel> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactModel>().ToTable("Contacts");

            modelBuilder.Entity<ContactModel>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Email);

                entity.HasIndex(e => e.PhoneNumber);
            });

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}