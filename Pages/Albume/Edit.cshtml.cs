using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zbranca_Iulian_ProiectMedii.Data;
using Zbranca_Iulian_ProiectMedii.Models;

namespace Zbranca_Iulian_ProiectMedii.Pages.Albume
{
    public class EditModel : AlbumCategoriesPageModel
    {
        private readonly Zbranca_Iulian_ProiectMedii.Data.Zbranca_Iulian_ProiectMediiContext _context;

        public EditModel(Zbranca_Iulian_ProiectMedii.Data.Zbranca_Iulian_ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Album = await _context.Album
                 .Include(b => b.Label)
                 .Include(b => b.CategorieAlbum).ThenInclude(b => b.Categorie)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);

            if (Album == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Album);


            ViewData["LabelID"] = new SelectList(_context.Set<Zbranca_Iulian_ProiectMedii.Models.Label>(), "ID", "NumeLabel");
            ViewData["ArtistID"] = new SelectList(_context.Set<Zbranca_Iulian_ProiectMedii.Models.Artist>(), "ID", "NumeArtist");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]
            selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var AlbumToUpdate = await _context.Album
            .Include(i => i.Label)
            .Include(i => i.CategorieAlbum)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (AlbumToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Album>(
            AlbumToUpdate,
            "Album",
            i => i.Titlu, i => i.Artist,
            i => i.Pret, i => i.DataAparitiei, i => i.Label))
            {
                UpdateCategorieAlbum(_context, selectedCategories, AlbumToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateCategorieAlbum(_context, selectedCategories, AlbumToUpdate);
            PopulateAssignedCategoryData(_context, AlbumToUpdate);
            return Page();
        }
    }


}