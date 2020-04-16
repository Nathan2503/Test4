﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWpfProjet.Models
{
    public class ContactDal
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
