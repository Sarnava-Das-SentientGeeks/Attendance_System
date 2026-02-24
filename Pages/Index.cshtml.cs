using Microsoft.AspNetCore.Mvc;
//It imports MVC related features like IActionResult, BindProperty and model binding support that Razor Pages use to handle HTTP requests and responses
using Microsoft.AspNetCore.Mvc.RazorPages;
//It imports the PageModel class which is the base class for Razor Pages backend logic
using Microsoft.EntityFrameworkCore;
//It allows us to use EF core features like ToListAsync(),EntityState.Modified etc
using WebApplication1.Data;
//It imports the ApplicationDbContext class i.e the database connection class
using WebApplication1.Models;
//It imports the Attendance model class i.e table structure

namespace WebApplication1.Pages
{
  
    public class IndexModel : PageModel
    {
        //This defines a Razor Page backend class named IndexModel that inherits from PageModel, which handles page requests like OnGet, OnPost, etc
        private readonly ApplicationDbContext _context;
        //This declares a private database context variable that will interact with our database
        //The EF core service registered in program.cs file helps to automatically inject the database context(object) via DI
        public IndexModel(ApplicationDbContext context)
        {//It is a constructor of the IndexModel class
            _context = context;
            //Here the ApplicationDbContext is injected automatically via DI(configured in Proagram.cs) and assigned to _context variable for database operations
        }

        [BindProperty]
        //This allows form data from the page to automatically bind to the "Attendance" object when submitting a form 

        public Attendance Attendance { get; set; }
        public IList<Attendance> AttendanceList { get; set; }

        public async Task OnGetAsync()
        {
            AttendanceList = await _context.Attendance.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Attendances.Add(Attendance);
            await _context.SaveChangesAsync();

            return RedirectToPage();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Attendances.Add(Attendance);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var record = await _context.Attendances.FindAsync(id);

            if(record != null)
            {
                _context.Attendances.Remove(record);
                await _context.SaveChangesAsync();

            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditAsync(int id)
        {
            var record = await _context.Attendances.FindAsync(id);

            if(record != null)
            {
                Attendance = record;
                AttendanceList = await _context.Attendances.ToListAsync();
                return Page();

                
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Attach(Attendance).State = EntityState.Modified;
             await _context.SaveChangesAsync();

            return RedirectToPage();

        }
        //public void OnGet()
        //{

        //}
    }
}
