namespace WebApplication1.Data;
using Microsoft.EntityFrameworkCore;


public class ApplicationDbContext:DbContext
//ApplicationDbContext inherits all EF Core database features
//DbContext is the main EF core class that opens DB connections,executes queries, tracks entity changes, saves data
//We have to inherit DbConctext class for using EF core
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Attendance> Attendances { get; set; }
    //Here the database name is "Attendance"
    //"Attendances" is the table name which is automatically created by the EF core
  

    }

