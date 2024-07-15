﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Examen
    {
        [Key]
        public int IdExamen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
