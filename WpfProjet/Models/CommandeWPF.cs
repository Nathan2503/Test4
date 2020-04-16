using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjet.Models
{
    class CommandeWPF
    {
        public int commandeId { get; set; }
        public DateTime commandeDate { get; set; }
        public int commandeQuantite { get; set; }
        public int? biereId { get; set; }
        public int? clientId { get; set; }
    }
}
