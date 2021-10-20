using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Memos.Data;
using Memos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Memos.Pages
{
    public class MemoDetailModel : PageModel
    {
        private readonly MemoContext _context;
        [BindProperty(SupportsGet = true)]
        public int MemoID { get; set; }

        public Memo Memo { get; set; }

        public MemoDetailModel(MemoContext context)
        {
            _context = context;
        }
        

        public async Task OnGet()
        {
            //Nesnáším to, ale zde nelze použít FirstOrDefaultAsync nebo FirstAsync - chyba: non-composable SQL
            var memo =  await _context.Memos.FromSqlInterpolated<Memo>($"GetMemoByID {MemoID}").ToListAsync();
            Memo = memo[0];
        }

        public IActionResult OnPost()
        {
            _context.Database.ExecuteSqlInterpolated($"ExpireMemoByID {MemoID}");
            return RedirectToPage("./Memos");
        }
    }
}
