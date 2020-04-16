using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWpfProjet.Models
{
    public class CommandeDal
    {
        public int commandeId { get; set; }
        public DateTime commandeDate { get; set; }
        public int commandeQuantite { get; set; }
        public int? biereId { get; set; }
        public int? clientId { get; set; }
    }
}
