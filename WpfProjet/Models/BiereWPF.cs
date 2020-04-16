using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjet.Models
{
     class BiereWPF
    {
        public int biereId { get; set; }
        public string biereNom { get; set; }
        public decimal pourcentageAlcool { get; set; }
        public string biereImage { get; set; }
        public string biereDescription { get; set; }
        public string biereRobe { get; set; }
        public bool biereIsDispo { get; set; }
        public decimal bierePrix { get; set; }
        public int? brasserieId { get; set; }
        public int? typeBiereId { get; set; }
    }
}
