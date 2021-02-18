using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zbranca_Iulian_ProiectMedii.Models
{
    public class AlbumData
    {
        public IEnumerable<Album> Album { get; set; }
        public IEnumerable<Categorie> Categorie { get; set; }
        public IEnumerable<CategorieAlbum> CategorieAlbum { get; set; }

    }
}
