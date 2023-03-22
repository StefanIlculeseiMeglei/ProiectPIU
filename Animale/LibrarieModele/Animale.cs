using System;
using static System.Net.Mime.MediaTypeNames;

namespace LibrarieModele
{
    public class imagini
    {
        private const int ID = 0;
        private const int NUME = 1;
        int nr;// numar de imagini
        char SEPARATOR_PRINCIPAL_FISIER = ';'; 
        string cale;
        string[] imag; // numele fisierelor cu imagini
        int[] id = new int[30];
        // indicatorul unic pentru fiecare combinatie de imagine/sunet
        public imagini()
        {
            this.nr = 0;
            this.cale = string.Empty;
        }
        public imagini(string numeFisierImg) // constructor in care precizam calea fisierul text cu numele imaginilor
        {
            this.cale = numeFisierImg;
            Stream streamFisierText = File.Open(numeFisierImg, FileMode.OpenOrCreate); // verifica daca exista fisierul
            if (streamFisierText.Length == 0)
            {
                Console.WriteLine($"Fisierul numeFisierImg este gol.");
                this.nr = 0;
            }
            else
            {
                streamFisierText.Close();
                using (StreamReader streamReader = new StreamReader(numeFisierImg)) /// citesc datele din fisier
                {
                    string linieFisier; 
                    linieFisier = streamReader.ReadLine(); // citesc prima linie, ea va fi nr de linii de citit
                    this.nr = Convert.ToInt32(linieFisier);
                    imag = new string[nr]; // alocare memorie pentru lista de nume
                    // citirea linilor in continuare
                    int i = 0;
                    while (i < this.nr && (linieFisier = streamReader.ReadLine()) != null)
                    {
                        var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
                        id[i] =Convert.ToInt32(dateFisier[ID]);
                        imag[i] = dateFisier[NUME];
                        i ++;
                    };
                };


            }
        }
        public int retNr()
        {
            return nr;
        }
        public string[] retLisaNume()
        {
            string[] lista;
            lista = new string[nr];
            imag.CopyTo(lista,0);
            return lista;
        }
        public int[] retId()
        {  
            return id;
        }
        public void addImg(char s, int n) { } // ca parametri numele fisierului si indicatorul unic;obiectul este deja incarcat cu o lista de imagini din constructor
        public string retRandImg() { return null; } // returneaza numele unei imagini random
        public string retImg(int id) { return null; } // returneaza numele unui imagini dupa id
    }
    public class sunete
    {
        private const int ID = 0;
        private const int NUME = 1;
        char SEPARATOR_PRINCIPAL_FISIER = ';';
        int nr; // numar de sunete
        string cale;
        string[] snd; // numele fisierelor cu sunete
        int[] id = new int[30]; // indicatorul unic pentru fiecare combinatie de imagine/sunet
        public sunete()
        {
            this.nr = 0;
            this.cale = string.Empty;
        }
        public sunete(string numeFisierSnd) // constructor in care precizam calea fisierul text cu numele imaginilor
        {
            this.cale = numeFisierSnd;
            Stream streamFisierText = File.Open(numeFisierSnd, FileMode.OpenOrCreate); // verifica daca exista fisierul
            if (streamFisierText.Length == 0) 
            {
                Console.WriteLine($"Fisierul numeFisierSnd este gol.");
                this.nr = 0;
            } 
            else
            {
                streamFisierText.Close();
                using (StreamReader streamReader = new StreamReader(numeFisierSnd)) /// citesc datele din fisier
                {
                    string linieFisier;
                    linieFisier = streamReader.ReadLine(); // citesc prima linie, ea va fi nr de linii de citit
                    this.nr = Convert.ToInt32(linieFisier);
                    snd = new string[nr]; // alocare memorie pentru lista de nume
                    // citirea linilor in continuare
                    int i = 0;
                    while (i < this.nr && (linieFisier = streamReader.ReadLine()) != null)
                    {
                        var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
                        id[i] = Convert.ToInt32(dateFisier[ID]);
                        snd[i] = dateFisier[NUME];
                        i++;
                    };
                };
            }
        }
        public int retNr()
        {
            return nr;
        }
        public string[] retLisaNume()
        {
            string[] lista;
            lista = new string[nr];
            snd.CopyTo(lista,0);
            return lista;
        }
        public int[] retId()
        {
            return id;
        }
        public void addSnd(char[] s, int id) { } // ca parametri numele fisierului si indicatorul unic; obiectul este deja incarcat cu o lista de sunete din constructor
        public string retRandSnd() { return null; } // returneaza numele unui sunet random
        public string retSnd(int id) { return null; } // returneaza numele unui sunet dupa id
    }
    public class joc
    {
        int puncte;
        int runda;
        int rundaMax;
        public joc() { }
        public void startJoc(sunete S, imagini I) { } /// metoda care porneste jocul, toate datele necesare sunt transmise prin parametrii

    }
}