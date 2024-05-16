using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Patient
    {
        [Key]
        [MaxLength(5, ErrorMessage = "Longeur maximale 5")]
        public string CodePatient { get; set; }
        public string EmailPatient { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Informations supplementaires")]
        public string Informations { get; set; }
        public string NomComplet { get; set; }
        public string NumeroTel { get; set; }
        public virtual IList<Bilan> Bilans { get; set; }

    }
}
