using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zbranca_Iulian_ProiectMedii.Models
{
    public class CategorieAlbum
    {
        public int ID { get; set; }
        public int AlbumID { get; set; }
        public Album Album { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
