using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Attendance Attendance { get; set; }
        public IList<Attendance> AttendanceList { get; set; }

        public async Task OnGetAsync()
        {
            AttendanceList=await _context.Attendance.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Attendances.Add(Attendance);
            await _context.SaveChangesAsync();

            return RedirectToPage();

        }

        //public void OnGet()
        //{

        //}
    }
}
