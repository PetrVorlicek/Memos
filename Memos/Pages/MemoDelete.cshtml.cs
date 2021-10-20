using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Memos.Data;
using Memos.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Memos.Pages
{
    public class MemoDeleteModel : PageModel
    {
        private readonly MemoContext _context;
        [BindProperty(SupportsGet = true)]
        public int MemoID { get; set; }

        public Memo Memo { get; set; }

        public MemoDeleteModel(MemoContext context)
        {
            _context = context;
        }

        public async Task OnGet()
        {
            var memo = await _context.Memos.FromSqlInterpolated<Memo>($"GetMemoByID {MemoID}").ToListAsync();
            Memo = memo[0];
        }

        public IActionResult OnPost()
        {
            _context.Database.ExecuteSqlInterpolated($"DeleteMemoByID {MemoID}");
            return RedirectToPage("./Memos");
        }
    }
}
