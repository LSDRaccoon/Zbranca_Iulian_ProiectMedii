using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zbranca_Iulian_ProiectMedii.Data;


namespace Zbranca_Iulian_ProiectMedii.Models
{
    public class AlbumCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Zbranca_Iulian_ProiectMediiContext context,
        Album Album)
        {
            var allCategories = context.Categorie;
            var CategorieAlbum = new HashSet<int>(
            Album.CategorieAlbum.Select(c => c.AlbumID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.NumeCategorie,
                    Assigned = CategorieAlbum.Contains(cat.ID)
                });
            }
        }
        public void UpdateCategorieAlbum(Zbranca_Iulian_ProiectMediiContext context,
        string[] selectedCategories, Album AlbumToUpdate)
        {
            if (selectedCategories == null)
            {
                AlbumToUpdate.CategorieAlbum = new List<CategorieAlbum>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var CategorieAlbum = new HashSet<int>
            (AlbumToUpdate.CategorieAlbum.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!CategorieAlbum.Contains(cat.ID))
                    {
                        AlbumToUpdate.CategorieAlbum.Add(
                        new CategorieAlbum
                        {
                            AlbumID = AlbumToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (CategorieAlbum.Contains(cat.ID))
                    {
                        CategorieAlbum courseToRemove
                        = AlbumToUpdate
                        .CategorieAlbum
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
