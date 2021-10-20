using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Memos.Data;
using Memos.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Memos.Pages
{
    public class CreatorsModel : PageModel
    {
        private readonly MemoContext _context;
        public List<Creator> Creators {  get; set; }

        public CreatorsModel(MemoContext context)
        {
            _context = context;
        }

        public async Task OnGet()
        {
            Creators = await _context.Creators.FromSqlRaw<Creator>("GetAllCreators").ToListAsync();

        }
    }
}
