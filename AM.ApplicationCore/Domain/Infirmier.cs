using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum Specialite
    {
        Hematologie,
        Biochimie,
        Autre
    }
    public class Infirmier
    {
        public int InfirmierId { get; set; }
        public string NomComplet { get; set; }
        public Specialite specialite { get; set; }
        public virtual Laboratoire Laboratoire { get; set; }
        public virtual IList<Bilan> Bilans { get; set; }

    }
}
