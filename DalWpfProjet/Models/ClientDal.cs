using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWpfProjet.Models
{
    public class ClientDal
    {
        public int clientId { get; set; }
        public string clientNom { get; set; }
        public string  clientPrenom { get; set; }
        public string clientLogin { get; set; }
        public string clientPwd { get; set; }
        public DateTime clientDateNaissance { get; set; }
    }
}
