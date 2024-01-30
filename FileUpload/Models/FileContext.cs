using Microsoft.EntityFrameworkCore;

namespace FileUpload.Models
{
    public class FileContext : DbContext
    {
        public readonly string connStr = "server=localhost;userid=root;password=;database=fileupload";

        public FileContext(DbContextOptions<FileContext>options):base(options)
        {
        }
        DbSet<FileModel> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
