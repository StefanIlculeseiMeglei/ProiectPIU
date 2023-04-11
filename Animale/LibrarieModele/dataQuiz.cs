using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class dataQuiz
    {
        const int NU_EXISTA = -2;
        const int NR_OPTIUNI_QUIZ = 3;
        internal enum  POZITII
        {
            POZITIE1, POZITIE2, POZITIE3
        }
        const int OCUPAT = 1;
        const int LIBER = 0;
        public int RUNDAMAX { get; }
        public int valoareRaspuns { get; }
        int[] raspunsuri;
        string[] imag;
        string[,] snd;
        public dataQuiz(int _valoareRaspuns,int _RUNDAMAX) {
            RUNDAMAX = _RUNDAMAX;
            valoareRaspuns = _valoareRaspuns;
            raspunsuri = new int[RUNDAMAX]; 
            imag= new string[RUNDAMAX];
            snd = new string[RUNDAMAX, NR_OPTIUNI_QUIZ];
        }

        public int getRapunsRunda(int _runda) { return raspunsuri[_runda];}
        public string getImagineRunda(int _runda) { return imag[_runda];}
        public string[] getSuneteRunda(int _runda) {
            string[] tempStr = new string[NR_OPTIUNI_QUIZ]; // lista de stringuri care va fi returnata
            tempStr[(int)POZITII.POZITIE1] = string.Copy(snd[_runda,(int)POZITII.POZITIE1]);
            tempStr[(int)POZITII.POZITIE2] = string.Copy(snd[_runda, (int)POZITII.POZITIE2]);
            tempStr[(int)POZITII.POZITIE3] = string.Copy(snd[_runda, (int)POZITII.POZITIE3]);
            return tempStr;
        }
        public void incarcaData(imagini I, sunete S) { /// datele jocului sunt incarcate (numele optiunilor si varianta corecta)
            int idSunet1, idSunet2;
            int [] pozitii_ocupate=new int[NR_OPTIUNI_QUIZ];
            Random rnd = new Random();
            imagine tempImag = new imagine();
            sunet tempSnd = new sunet();
            for (int i=0;i < RUNDAMAX;i++)
            {
                pozitii_ocupate[(int)POZITII.POZITIE1] = LIBER; 
                pozitii_ocupate[(int)POZITII.POZITIE2] = LIBER;
                pozitii_ocupate[(int)POZITII.POZITIE3] = LIBER;
                
                raspunsuri[i] = rnd.Next(0, NR_OPTIUNI_QUIZ); // pozitia raspunsului corect pentru runda i
                pozitii_ocupate[raspunsuri[i]] = OCUPAT;
                tempImag = I.retRandImg();
                for (int j = 0;j < i;j++) // verificam daca nu am folosit deja imaginea in quiz
                {
                    if (tempImag.Name.Equals(imag[j]))
                    {
                        tempImag = I.retRandImg();
                        j = 0;

                    }
                }
                imag[i] = string.Copy(tempImag.Name); // adaug in lista cu numele imaginilor, numele imaginii rundei i

                tempSnd = S.retSnd(tempImag.Id); // gasim perechea corecta sunet-imagine pentru runda i
                snd[i,raspunsuri[i]] = string.Copy(tempSnd.Name); // adaug in lista cu numele sunetelor pe pozitia corecta numele sunetului
                idSunet1 = tempSnd.Id; // id-ul primului sunet adaugat in optiuni
                idSunet2 = NU_EXISTA; // id-ul urmatorului sunet adaugat in optiuni
                while (pozitii_ocupate[(int)POZITII.POZITIE1]==LIBER || pozitii_ocupate[(int)POZITII.POZITIE2]==LIBER || pozitii_ocupate[(int)POZITII.POZITIE3]==LIBER)
                {
                    tempSnd = S.retRandSnd();
                    if (tempSnd.Id != idSunet1 && tempSnd.Id!=idSunet2 )
                    {
                        if (pozitii_ocupate[(int)POZITII.POZITIE1]==LIBER)
                        {
                            snd[i, (int)POZITII.POZITIE1] = string.Copy(tempSnd.Name);
                            pozitii_ocupate[(int)POZITII.POZITIE1] = OCUPAT;
                            idSunet2 = tempSnd.Id;
                            continue;
                        }
                        if (pozitii_ocupate[(int)POZITII.POZITIE2] == LIBER)
                        {
                            snd[i, (int)POZITII.POZITIE2] = string.Copy(tempSnd.Name);
                         
                            pozitii_ocupate[(int)POZITII.POZITIE2] = OCUPAT;
                            idSunet2 = tempSnd.Id;
                            continue;
                        }
                        if (pozitii_ocupate[(int)POZITII.POZITIE3] == LIBER)
                        {
                            snd[i, (int)POZITII.POZITIE3] = string.Copy(tempSnd.Name);
                            pozitii_ocupate[(int)POZITII.POZITIE3] = OCUPAT;
                            idSunet2 = tempSnd.Id;
                            continue;
                        }
                    }
                }
            }
        } 

    }
}
