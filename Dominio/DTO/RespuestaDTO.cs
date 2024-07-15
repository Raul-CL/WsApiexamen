using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO
{
    public class RespuestaDTO
    {
        public bool EsExitoso { get; set; }
        public string Mensaje { get; set; }
        public object Resultado { get; set; }
    }
}
