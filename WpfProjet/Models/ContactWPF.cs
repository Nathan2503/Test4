using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjet.Models
{
    class ContactWPF
    {
        public int contactId { get; set; }
        public string adRue { get; set; }
        public string adNumero { get; set; }
        public string adVille { get; set; }
        public string adCodePostal { get; set; }
        public string telephone { get; set; }
        public int? brasserieId { get; set; }
    }
}
