﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBNomes.Model
{
    public class NomesContextDB :DbContext
    {
        public DbSet<Nome> Nomes { get; set; }
    }
}
