namespace LoginService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LoginDetails : DbContext
    {
        public LoginDetails()
            : base("name=LoginDetails")
        {
        }

        public virtual DbSet<LoginTable> LoginTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginTable>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<LoginTable>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
