using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Bilan
    {
        public DateTime DatePrelevement { get; set; }
        public string EmailMedecin { get; set; }
        public bool Paye { get; set; }
        public virtual IList<Analyse> Analyses { get; set; }
        public virtual Patient MyPatient { get; set; }
        public virtual Infirmier MyInfirmier { get; set; }
        public string CodePatient { get; set; }
        public int CodeInfirmier { get; set; }
    }
}
