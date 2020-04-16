using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWpfProjet.Models
{
    public class EmploiDal
    {
        public int offreEmploiId { get; set; }
        public string fonction { get; set; }
        public string jobDescription { get; set; }
        public string diplomeMin { get; set; }
        public int experienceMin { get; set; }
        public int? brasserieId { get; set; }  
    }
}
