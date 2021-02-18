using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zbranca_Iulian_ProiectMedii.Models
{
    public class Label
    {
        public int ID { get; set; }
        public string NumeLabel { get; set; }
        public ICollection<Album> Albume { get; set; }
    }
}
