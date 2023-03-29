using LibrarieModele;

using System;
using System.Data;
using System.IO;

using static System.Net.Mime.MediaTypeNames;

namespace NivelStocareData
{
    public class AdministrareAnimale_FisierText
    {
        private const int ID = 0;
        private const int NUME = 1;
        char SEPARATOR_PRINCIPAL_FISIER = ';';
        const int MAXX = 20;
        private string numeFisierImagini;
        private string numeFisierSunete;
        int nr1;
        int nr2;
        int[] id1;
        int[] id2;
        string[] s1;
        string[] s2;

        public AdministrareAnimale_FisierText(imagini img,sunete snd,string numeFisierImagini,string numeFisierSunete)
        {
            nr1 = img.retNr();
            nr2 = snd.retNr();
            id1 = new int[nr1];
            id2 = new int[nr2];
            s1 = new string[nr1];
            s2 = new string[nr2];
            id1 = img.retId();
            id2 = snd.retId();
            s1 = img.retLisaNume();
            s2 = snd.retLisaNume();
            this.numeFisierImagini = numeFisierImagini;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisierImagini, FileMode.OpenOrCreate);
            streamFisierText.Close();
            this.numeFisierSunete = numeFisierSunete;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            streamFisierText = File.Open(numeFisierSunete, FileMode.OpenOrCreate);
            streamFisierText.Close();

        }
        public void updateSunete(sunete _snd)
        {
            nr2 = _snd.retNr();
            id2 = new int[nr2];;
            s2 = new string[nr2];
            id2 = _snd.retId();
            s2 = _snd.retLisaNume();
        }
        public void updateImagini(imagini _img)
        {
            nr1 = _img.retNr();
            id1 = new int[nr2]; ;
            s1 = new string[nr2];
            id1 = _img.retId();
            s1 = _img.retLisaNume();
        }

        public void imaginiCitire( imagini img, string numeFisierImg) // constructor in care precizam calea fisierul text cu numele imaginilor
        {

                Stream streamFisierText = File.Open(numeFisierImg, FileMode.OpenOrCreate); // verifica daca exista fisierul
                if (streamFisierText.Length == 0)
                {
                    Console.WriteLine($"Fisierul " + numeFisierImg + " este gol.");
                    streamFisierText.Close();
                    using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierImagini, true))
                    {
                    streamWriterFisierText.WriteLine("Fisier cu imagini");
                    streamWriterFisierText.Close();
                    }
                    

            }
                else
                {
                    streamFisierText.Close();
                    using (StreamReader streamReader = new StreamReader(numeFisierImg)) /// citesc datele din fisier
                    {
                        string linieFisier;
                        linieFisier = streamReader.ReadLine(); // citesc prima linie, ea va fi nr de linii de citit
                        // citirea linilor in continuare
                        while ((linieFisier = streamReader.ReadLine()) != null)
                        {
                            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
                            int x;
                            x = Convert.ToInt32(dateFisier[ID]);
                            img.addImg(x, dateFisier[NUME]);
                        };
                    streamReader.Close();
                };


                }
            this.updateImagini(img);            
        }

        public void suneteCitire(sunete snd, string numeFisierImg) // constructor in care precizam calea fisierul text cu numele imaginilor
        {

            Stream streamFisierText = File.Open(numeFisierSunete, FileMode.OpenOrCreate); // verifica daca exista fisierul
            if (streamFisierText.Length == 0)
            {
                Console.WriteLine($"Fisierul " + numeFisierSunete + " este gol.");
                streamFisierText.Close();
                using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierSunete, true))
                {
                    streamWriterFisierText.WriteLine("Fisier cu sunete");
                    streamWriterFisierText.Close();
                }
            }
            else
            {
                streamFisierText.Close();
                using (StreamReader streamReader = new StreamReader(numeFisierSunete)) /// citesc datele din fisier
                {
                    string linieFisier;
                    // citirea linilor in continuare
                    linieFisier = streamReader.ReadLine();
                    while ((linieFisier = streamReader.ReadLine()) != null)
                    {
                        var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
                        int x;
                        x = Convert.ToInt32(dateFisier[ID]);
                        snd.addSnd(x, dateFisier[NUME]);
                    };
                    streamReader.Close();
                };

                streamFisierText.Close();

                this.updateSunete(snd);
            }
        }

        public void AddImagine(imagine img)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            Stream streamFisierText = File.Open(numeFisierImagini, FileMode.OpenOrCreate); // verifica daca exista fisierul
            if (streamFisierText.Length == 0)
            {
                streamFisierText.Close();
                using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierImagini, true))
                {
                    streamWriterFisierText.WriteLine("Fisier cu imagini");
                    streamWriterFisierText.Close();
                }
            }
            streamFisierText.Close();
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierImagini, true))
            {
                streamWriterFisierText.WriteLine(img.ConversieLaSir_PentruFisier());
                streamWriterFisierText.Close();
            }
        }
        public void AddSunet(sunet snd)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            Stream streamFisierText = File.Open(numeFisierSunete, FileMode.OpenOrCreate); // verifica daca exista fisierul
            if (streamFisierText.Length == 0)
            {
                streamFisierText.Close();
                using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierSunete, true))
                {
                    streamWriterFisierText.WriteLine("Fisier cu sunete");
                    streamWriterFisierText.Close();
                }
            }
            streamFisierText.Close();
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierSunete, true))
            {

                streamWriterFisierText.WriteLine(snd.ConversieLaSir_PentruFisier());
                streamWriterFisierText.Close();
            }
        }

        public void afisareDate()
        {

            Console.WriteLine("Fisierul cu imagini are {0} elemente.", nr1);
            for (int i = 0; i < nr1; i++)
            {
                Console.WriteLine("Element {0} are valoarea {1} si indentificatorul unic {2}",
                    i, s1[i], id1[i]);
            }
            Console.WriteLine("Fisierul cu sunete are {0} elemente.", nr2);
            for (int i = 0; i < nr2; i++)
            {
                Console.WriteLine("Element {0} are valoarea {1} si indentificatorul unic {2}",
                    i, s2[i], id2[i]);
            }
        }
    }
}