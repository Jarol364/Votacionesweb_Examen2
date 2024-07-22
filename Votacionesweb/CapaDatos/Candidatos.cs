using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Votacionesweb.CapaDatos
{
    public class Candidatos
    {
        public int IDCandidato { get; set; }
        public string NombreCandidato { get; set; }
        public string ApellidoCandidato { get; set; }
        public string NumeroTelefono { get; set; }
        public string Plataforma { get; set; }
        public int IDPartido { get; set; }
    }
}