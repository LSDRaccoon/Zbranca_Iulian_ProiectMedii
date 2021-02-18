using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zbranca_Iulian_ProiectMedii.Models
{
    public class Artist
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 1)]
        public string NumeArtist { get; set; }

        public ICollection<Album> Albume { get; set; }
    }
}
