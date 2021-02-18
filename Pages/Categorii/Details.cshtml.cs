using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zbranca_Iulian_ProiectMedii.Data;
using Zbranca_Iulian_ProiectMedii.Models;

namespace Zbranca_Iulian_ProiectMedii.Pages.Categorii
{
    public class DetailsModel : PageModel
    {
        private readonly Zbranca_Iulian_ProiectMedii.Data.Zbranca_Iulian_ProiectMediiContext _context;

        public DetailsModel(Zbranca_Iulian_ProiectMedii.Data.Zbranca_Iulian_ProiectMediiContext context)
        {
            _context = context;
        }

        public Categorie Categorie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categorie = await _context.Categorie.FirstOrDefaultAsync(m => m.ID == id);

            if (Categorie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
