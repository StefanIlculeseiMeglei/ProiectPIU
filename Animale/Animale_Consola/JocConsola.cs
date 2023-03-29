using LibrarieModele;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Animale
{
    public class JocConsola
    {
        int runda;
        int puncte;
        int rundaMax;
        const int MINWIN = 100;
        const int valoare = 20;
        const string msg = "1)Runda urmatoare" +
            "\n2)Afisare puncte" +
            "\n3)Iesire joc";
        public JocConsola() {
        }
        public void afisareScor()
        {
            Console.WriteLine($"{puncte}");
        }
        internal bool verificaCastig()
        {
            if (puncte < MINWIN)
                return false; 
            else
                return true;
        }
        public void startJoc(dataJoc data)
        {
            Boolean stop = false;
            rundaMax = data.retRundaMax();
            runda = 1;
            puncte = 0;
            string[] tempSunete = new string[3];
            int i,op;
            while (runda < rundaMax && stop==false) {
                tempSunete = data.getSuneteRunda(runda);
                Console.Clear();
                Console.WriteLine("Runda " + runda + " :");
                Console.WriteLine("Imagine:" + data.getImagineRunda(runda));
                Console.WriteLine("Sunete:");
                for (i = 0; i < 3; i++)
                    Console.WriteLine($"{i+1})" + tempSunete[i]);

                Console.Write("Alegeti o optiune:");
                op = Convert.ToInt32(Console.ReadLine());
                if (op != (data.getRapunsRunda(runda) + 1))
                {
                    Console.Clear();
                    Console.WriteLine("Raspuns incorect!");
                }
                else
                {
                    Console.Clear();
                    puncte += valoare;
                    Console.WriteLine("Raspuns corect!");
                }

                do
                {
                    Console.WriteLine(msg);
                    Console.Write("Alegeti o optiune:");
                    op = Convert.ToInt32(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            break;
                        case 2:
                            this.afisareScor();
                            Console.WriteLine("\t...press any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            stop = true;
                            Console.WriteLine("\t...press any key to continue");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Optiune gresita!");
                            Console.WriteLine("\t...press any key to continue");
                            Console.ReadKey();
                            break;

                    }

                } while (op != 1 && op !=3);
                runda++;
            }
            if(verificaCastig())
            {
                Console.WriteLine("Ati castigat!");
                Console.WriteLine($"Punctaj final {puncte}");
                Console.WriteLine("\t...press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ati pierdut!");
                Console.WriteLine($"Punctaj final {puncte}");
                Console.WriteLine("\t...press any key to continue");
                Console.ReadKey();

            }
            
        }
       
    }
}
