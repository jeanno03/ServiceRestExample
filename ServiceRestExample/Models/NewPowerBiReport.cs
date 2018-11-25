using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceRestExample.Models
{
    public class NewPowerBiReport
    {

        public string ContentId { get; set; }
        public string Control_Name { get; set; }
        public string Antivirus_Installes { get; set; }
        public string Nb_Postes_Travail { get; set; }
        public string Exploitation_Vuln { get; set; }
        public string FormuleToApply { get; set; }
        public string Pourcentage_Conformite { get; set; }
        public List<Ville> Villes{ get; set; }
        public string Prenom { get; set; }
        public List<Couleure> Couleures { get; set; }

    }

    public class Ville
    {
        public string Nom { get; set; }
    }

    public class Couleure
    {
        public string Nom { get; set; }
    }
}