using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Zbranca_Iulian_ProiectMedii.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 1), RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Folositi doar litere")]
        public string NumeCategorie { get; set; }
        public ICollection<CategorieAlbum> CategorieAlbum { get; set; }
    }
}
