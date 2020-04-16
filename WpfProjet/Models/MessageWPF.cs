using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjet.Models
{
    class MessageWPF
    {
        public int messageAlertId { get; set; }
        public string messageContenu { get; set; }
        public DateTime messageDateDebut { get; set; }
        public DateTime messageDateFin { get; set; }
        public int? brasserieId { get; set; }
    }
}
