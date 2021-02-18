using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zbranca_Iulian_ProiectMedii.Data;
using Zbranca_Iulian_ProiectMedii.Models;

namespace Zbranca_Iulian_ProiectMedii.Pages.Albume
{
    public class CreateModel : AlbumCategoriesPageModel
    {
        private readonly Zbranca_Iulian_ProiectMedii.Data.Zbranca_Iulian_ProiectMediiContext _context;

        public CreateModel(Zbranca_Iulian_ProiectMedii.Data.Zbranca_Iulian_ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["LabelID"] = new SelectList(_context.Set<Zbranca_Iulian_ProiectMedii.Models.Label>(), "ID", "NumeLabel");
            ViewData["ArtistID"] = new SelectList(_context.Set<Zbranca_Iulian_ProiectMedii.Models.Artist>(), "ID", "NumeArtist");
            
            var Album = new Album();
            Album.CategorieAlbum = new List<CategorieAlbum>();
            PopulateAssignedCategoryData(_context, Album);

            return Page();
        }

        [BindProperty]
        public Album Album { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newAlbum = new Album();
            if (selectedCategories != null)
            {
                newAlbum.CategorieAlbum = new List<CategorieAlbum>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieAlbum
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newAlbum.CategorieAlbum.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Album>(
            newAlbum,
            "Album",
            i => i.Titlu, i => i.Artist,
            i => i.Pret, i => i.DataAparitiei, i => i.LabelID))
            {
                _context.Album.Add(newAlbum);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newAlbum);
            return Page();
        }
    }
}
