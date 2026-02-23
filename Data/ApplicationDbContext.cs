namespace WebApplication1.Data;
using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext:DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Attendance> Attendances { get; set; }

    }

