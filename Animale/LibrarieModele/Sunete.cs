using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Net.Mime.MediaTypeNames;

namespace LibrarieModele
{
    public class sunete
    {
        private const int MAXNUME = 50;
        private const int ZERO = 0;
        internal int nr { get; set; } // numar de sunete
        internal string cale { get; set; }
        sunet[] snd; 
        public sunete()
        {
            snd = new sunet[MAXNUME];
            this.nr = ZERO;
            this.cale = string.Empty;
        }
        public int retNr()
        {
            return nr;
        }
        public string[] retLisaNume()
        {
            if (nr == ZERO)
                return null;
            string[] lista;
            lista = new string[nr];
            for (int i = 0; i < nr; i++)
                lista[i] += snd[i].Name;
            return lista;
        }
        public string Cale { get => cale;set => cale = string.Copy(value); }
        public int[] retId()
        {
            if (nr == ZERO)
                return null;
            int[] _id;
            _id = new int[nr];
            for (int i = 0; i < nr; i++)
                _id[i] += snd[i].Id;
            return _id;
        }
        public void addSnd(int n, string s)
        {
            snd[nr++] = new sunet(n, s);
        } // ca parametri numele fisierului si indicatorul unic
        public sunet retRandSnd() {
            Random rnd = new Random();
            int num = rnd.Next(0, nr);
            return snd[num];
        } //returneaza un sunet random
        public sunet retSnd(int id) {
            for (int i = 0; i < nr; i++)
                if (snd[i].Id == id)
                    return snd[i];
            return null;
        } // returneaza numele unui sunet dupa id
    }
}
