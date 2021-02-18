using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zbranca_Iulian_ProiectMedii.Models
{
    public class Album
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 1)]
        [Display(Name = "Titlul Albumului")]
        public string Titlu { get; set; }

        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataAparitiei { get; set; }
        public int LabelID { get; set; }
        public Label Label { get; set; }

    }
}
