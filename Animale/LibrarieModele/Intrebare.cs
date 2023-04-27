using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Intrebare
    {
        internal const int NRSUNETE = 3;
        public Intrebare() {
            numeSunete = new string[NRSUNETE];
            numeImagine = string.Empty;
        }
        public string numeImagine { get; set; }
        public string[] numeSunete { get; set; }
        public int pozitieRaspunsCorect { get; set; }
        public string getSunetCorect() { return this.numeSunete[pozitieRaspunsCorect]; }
    }
}
