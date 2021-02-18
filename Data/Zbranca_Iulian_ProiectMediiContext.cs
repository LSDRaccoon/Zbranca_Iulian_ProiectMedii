using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zbranca_Iulian_ProiectMedii.Models;

namespace Zbranca_Iulian_ProiectMedii.Data
{
    public class Zbranca_Iulian_ProiectMediiContext : DbContext
    {
        public Zbranca_Iulian_ProiectMediiContext (DbContextOptions<Zbranca_Iulian_ProiectMediiContext> options)
            : base(options)
        {
        }

        public DbSet<Zbranca_Iulian_ProiectMedii.Models.Album> Album { get; set; }

        public DbSet<Zbranca_Iulian_ProiectMedii.Models.Label> Label { get; set; }

        public DbSet<Zbranca_Iulian_ProiectMedii.Models.Artist> Artist { get; set; }
    }
}
