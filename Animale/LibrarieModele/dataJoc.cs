using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class dataJoc
    {   
        const int RUNDAMAX=7;
        int[] raspunsuri;
        string[] imag;
        string[,] snd;
        public dataJoc() {
            raspunsuri = new int[RUNDAMAX]; 
            imag= new string[RUNDAMAX];
            snd = new string[RUNDAMAX, 3];
        }
        public int retRundaMax() { return RUNDAMAX; }
        public int getRapunsRunda(int x) { return raspunsuri[x];}
        public string getImagineRunda(int x) { return imag[x];}
        public string[] getSuneteRunda(int x) {
            string[] tempStr = new string[3];
            tempStr[0] = string.Copy(snd[x,0]);
            tempStr[1] = string.Copy(snd[x, 1]);
            tempStr[2] = string.Copy(snd[x, 2]);
            return tempStr;
        }
        public void getDate(imagini i, sunete s) { /// datele jocului sunt incarcate (numele optiunilor si varianta corecta)
            int j,k,m ,n;
            int [] pozitii_ocupate=new int[3];
            Random rnd = new Random();
            imagine tempImag = new imagine();
            sunet tempSnd = new sunet();
            for (j=0;j < RUNDAMAX;j++)
            {
                pozitii_ocupate[0] = 0;
                pozitii_ocupate[1] = 0;
                pozitii_ocupate[2] = 0;
                
                raspunsuri[j] = rnd.Next(0, 3); // pozitia raspunsului corect
                pozitii_ocupate[raspunsuri[j]] = 1;
                tempImag = i.retRandImg();
                for (m = 0;m < j; m++)
                {
                    if (tempImag.Name.Equals(imag[m]))
                    {
                        tempImag = i.retRandImg();
                        m = 0;

                    }

                }
                imag[j] = string.Copy(tempImag.Name);

                tempSnd = s.retSnd(tempImag.Id);
                snd[j,raspunsuri[j]] = string.Copy(tempSnd.Name);
                m = tempSnd.Id;
                n = -2;
                k = 0;
                while (k < 2)
                {
                    tempSnd = s.retRandSnd();
                    if (tempSnd.Id != m && tempSnd.Id!=n )
                    {
                        if (pozitii_ocupate[0]==0)
                        {
                            snd[j, 0] = string.Copy(tempSnd.Name);
                            k++;
                            pozitii_ocupate[0] = 1;
                            n = tempSnd.Id;
                            continue;
                        }
                        if (pozitii_ocupate[1] == 0)
                        {
                            snd[j, 1] = string.Copy(tempSnd.Name);
                            k++;
                            pozitii_ocupate[1] = 1;
                            n = tempSnd.Id;
                            continue;
                        }
                        if (pozitii_ocupate[2] == 0)
                        {
                            snd[j, 2] = string.Copy(tempSnd.Name);
                            k++;
                            pozitii_ocupate[2] = 1;
                            n = tempSnd.Id;
                            continue;
                        }
                    }
                }
            }
        } /// metoda care porneste jocul, toate datele necesare sunt transmise prin parametrii

    }
}
