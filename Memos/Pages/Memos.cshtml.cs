using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Memos.Data;
using Memos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Memos.Pages
{
    public class MemosModel : PageModel
    {
        private readonly MemoContext _context;
        public List<Memo> Memos { get; set; }
        public List<SelectListItem> Creators {  get; set; }
        [BindProperty]
        public string  CreatorID { get; set; }
        [BindProperty]
        public string  MemoHeader { get; set; }
        [BindProperty]
        public string  MemoBody { get; set; }

        public MemosModel(MemoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? creatorID)
        {
            //Load page data
            return await LoadMemosData(creatorID);
        }

        public async Task<IActionResult> OnPostAsync(int? creatorID)
        {
            //Save Model
            //TODO - pøidat validaci pro ID Creator, zdali opravdu existuje
            //TODO - pøepsat jméno property CreatorID a parametru creatorID; nyní pøi POST vrací stránku pro creatorID, ne pro všechny memos
            try
            {
                int intCreatorID = int.Parse(CreatorID);
               _context.Database.ExecuteSqlInterpolated($"CreateMemo {intCreatorID}, {MemoHeader}, {MemoBody}");
                Console.WriteLine("New Memo Created");
            }
            catch
            {
                Console.WriteLine("Error - Invalid memo creation");
            }

            //Load page data
            return await LoadMemosData(creatorID);
        }

        public async Task<IActionResult> LoadMemosData (int? iD)
        {
            //Get creators for select element
            var allCreators = await _context.Creators.FromSqlRaw<Creator>("GetAllCreators").ToListAsync();
            //Add creators into select list item
            Creators = new List<SelectListItem>();
            foreach (var creator in allCreators)
            {
                Creators.Add(new SelectListItem($"{creator.FirstName} {creator.LastName}", creator.CreatorId.ToString()));
            }

            //Get memos for specified creator
            //TODO - Refaktor - pro daného tvùrce nezobrazit <select> ale automaticky ho považovat za tvùrce nové poznámky
            if (iD.HasValue)
            {
                int creator = iD.Value;
                //if input is valid
                try
                {
                    Memos = await _context.Memos.FromSqlInterpolated<Memo>($"GetMemoByCreator {creator}").ToListAsync();
                }
                //else get all memos
                catch
                {
                    Console.WriteLine("Error - Invalid ID");
                    Memos = await _context.Memos.FromSqlRaw<Memo>("GetAllMemos").ToListAsync();
                }
                return Page();
            }
            //Get all memos
            else
            {
                Memos = await _context.Memos.FromSqlRaw<Memo>("GetAllMemos").ToListAsync();
                return Page();
            }
        }
    }
}
