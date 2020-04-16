﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjet.Models
{
    class HorraireWPF
    {
        public int horraireId { get; set; }
        public DateTime horraireDateDebut { get; set; }
        public DateTime horraireDateFin { get; set; }
        public string heureOuverture { get; set; }
        public string heureFermeture { get; set; }
        public int? brasserieId { get; set; }
    }
}
