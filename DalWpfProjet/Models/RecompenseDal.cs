﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalWpfProjet.Models
{
    public class RecompenseDal
    {
        public int recompenseId { get; set; }
        public string recompenseNom { get; set; }
        public int? biereId { get; set; }  
    }
}
