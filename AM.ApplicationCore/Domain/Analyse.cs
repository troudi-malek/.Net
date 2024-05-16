using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Analyse
    {
        public int AnalyseId { get; set; }
        public int DureeResultat { get; set; }
        public double PrixAnalyse { get; set; }
        public string TypeAnalyse { get; set; }
        public float ValeurAnalyse { get; set; }
        public float ValeurMaxNormal { get; set; }
        public float ValeurMinNormal { get; set; }
        public virtual Bilan bilan { get; set; }
    }
}
