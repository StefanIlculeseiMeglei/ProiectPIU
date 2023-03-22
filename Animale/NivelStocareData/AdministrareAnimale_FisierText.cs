using LibrarieModele;
using System;

namespace NivelStocareData
{
    public class AdministrareAnimale_FisierText
    {
        imagini I;
        sunete S;
        int nr1;
        int nr2;
        string[] lista1;
        string[] lista2;
        int[] id1;
        int[] id2;
        public AdministrareAnimale_FisierText(imagini _I,sunete _S)
        {
            this.S = _S;
            this.I = _I;
            nr1 = I.retNr();
            nr2 = S.retNr();
            lista1=I.retLisaNume();
            lista2=S.retLisaNume();
            id1=I.retId();
            id2=S.retId();
        }
        public void afisareDate()
        {
            Console.WriteLine("Fisierul cu imagini are {0} elemente.",nr1);
            for(int i=0;i<nr1;i++)
            {
                Console.WriteLine("Element {0} are valoarea {1} si indentificatorul unic {2}",
                    i, lista1[i], id1[i]);
            }
            Console.WriteLine("Fisierul cu sunete are {0} elemente.", nr2);
            for (int i = 0; i < nr2; i++)
            {
                Console.WriteLine("Element {0} are valoarea {1} si indentificatorul unic {2}",
                    i, lista2[i], id2[i]);
            }
        }
    }
}