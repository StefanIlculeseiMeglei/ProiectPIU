using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class sunet
    {
        private const int ID = 0;
        private const int INVALID = -1;
        private const int NAME = 1;
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        internal int id { get; set; }
        internal string name { get; set; }
        public sunet(int id, string name)
        {
            this.id = id;
            this.name = name;

        }
        public sunet() { id = INVALID; name = null; }
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = string.Copy(value); } }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectSunetPentruFisier = string.Format("{1}{0}{2}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                id.ToString(),
                (name ?? " NECUNOSCUT "));

            return obiectSunetPentruFisier;
        }
        public sunet(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            id = Convert.ToInt32(dateFisier[ID]);
            name = dateFisier[NAME];
            
        }
    }
}
