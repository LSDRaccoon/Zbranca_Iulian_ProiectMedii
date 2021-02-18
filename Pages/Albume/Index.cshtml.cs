using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zbranca_Iulian_ProiectMedii.Data;
using Zbranca_Iulian_ProiectMedii.Models;

namespace Zbranca_Iulian_ProiectMedii.Pages.Albume
{
    public class IndexModel : PageModel
    {
        private readonly Zbranca_Iulian_ProiectMedii.Data.Zbranca_Iulian_ProiectMediiContext _context;

        public IndexModel(Zbranca_Iulian_ProiectMedii.Data.Zbranca_Iulian_ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<Album> Album { get;set; }

        public async Task OnGetAsync()
        {
            Album = await _context.Album.
                Include(b => b.Label).
                Include(b=>b.Artist).
                ToListAsync();
        }
    }
}
