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

        public AlbumData AlbumD { get; set; }
        public int AlbumID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? CategorieID)
        {
            AlbumD = new AlbumData();

            AlbumD.Album = await _context.Album
            .Include(b => b.Label)
            .Include(b => b.Artist)
            .Include(b => b.CategorieAlbum)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Titlu)
            .ToListAsync();
            if (id != null)
            {
                AlbumID = id.Value;
                Album Album = AlbumD.Album
                .Where(i => i.ID == id.Value).Single();
                AlbumD.Categorie = Album.CategorieAlbum.Select(s => s.Categorie);
            }
        }
        
    }
}
