namespace BME.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogEngine : DbContext
    {
        public BlogEngine()
            : base("name=BlogEngine")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(e => e.BlogTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.Synced)
                .IsUnicode(false);
        }
    }
}
