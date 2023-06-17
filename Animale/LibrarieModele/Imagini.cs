using System;
using System.CodeDom;
using System.ComponentModel;
using System.IO;
using System.Xml.Schema;

using static System.Net.Mime.MediaTypeNames;

namespace LibrarieModele
{
    public class imagini
    {
        imagine[] imag;
        private const int ZERO = 0;
        private const int maxNume = 20;
        int nr;// numar de imagini
        string cale;
        // indicatorul unic pentru fiecare combinatie de imagine/sunet
        public imagini()
        {
            imag=new imagine[maxNume];
            this.nr = 0;
            for (int i = 0; i < maxNume; i++)
                imag[i] = new imagine();

            this.cale = string.Empty;
        }
        public int retNr()
        {
            return nr;
        }
        public string[] retLisaNume()
        {
            if (nr == ZERO )
                return null;
            string[] lista;
            lista = new string[nr];
            for (int i = 0; i < nr; i++)
                lista[i] += imag[i].Name;
            return lista;
        }
        public int[] retId()
        {
            if (nr == ZERO)
                return null;
            int[] _id;
            _id = new int[nr];
            for (int i = 0; i < nr; i++)
                _id[i] += imag[i].Id;
            return _id;
        }

        public string Cale { get => cale; set => cale = string.Copy(value); }
        public void addImg(int n, string s) {
            imag[nr++] = new imagine(n, s);

        } // ca parametri numele fisierului si indicatorul unic
        public imagine retRandImg()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, nr);
            return imag[num];
        } //returneaza un sunet random
        public imagine retImg(int id)
        {
            return imag[id];
        } // returneaza numele unui sunet dupa id
    }
    
}