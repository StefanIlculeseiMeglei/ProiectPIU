using LibrarieModele;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace Quiz_Consola
{
    public class QuizConsola
    {
        const string msg = "1)Runda urmatoare" +
            "\n2)Afisare puncte" +
            "\n3)Iesire joc";

        const int NEW_RUNDA = 1;
        const int NEW_PUNCTE = 0;
        const int NR_OPTIUNI_QUIZ = 3;
        internal int runda { get; set; }
        internal int puncte { get; set; }
        
        public QuizConsola() {
        }
        public void afisareScor()
        {
            Console.WriteLine($"{puncte}");
        }
        public void startQuiz(dataQuiz data)
        {
            Boolean stop = false;
            verificaQuiz verifica = new verificaQuiz(data.valoareRaspuns, data.RUNDAMAX);
            
            runda = NEW_RUNDA;
            puncte = NEW_PUNCTE;
            string[] tempSunete = new string[NR_OPTIUNI_QUIZ];
            int i,op;
            while (verifica.verificaRunda(runda) && stop==false) {
                tempSunete = data.getSuneteRunda(runda); /// optiuni sunete pentru runda x
                Console.Clear();
                Console.WriteLine("Runda " + runda + " :");
                Console.WriteLine("Imagine:" + data.getImagineRunda(runda));
                Console.WriteLine("Sunete:");
                for (i = 0; i < NR_OPTIUNI_QUIZ; i++)
                    Console.WriteLine($"{i+1})" + tempSunete[i]);

                Console.Write("Alegeti o optiune:");
                op = Convert.ToInt32(Console.ReadLine());

                if (verifica.raspunsQuiz(op, data.getRapunsRunda(runda) + 1))
                {
                    Console.Clear();
                    Console.WriteLine("Raspuns corect!");
                    puncte += data.valoareRaspuns;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Raspuns incorect!");
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
            if(verifica.verificaCastig(puncte))
            {
                Console.Clear ();
                Console.WriteLine("Ati castigat!");
                Console.WriteLine($"Punctaj final {puncte}");
                Console.WriteLine("\t...press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ati pierdut!");
                Console.WriteLine($"Punctaj final {puncte}");
                Console.WriteLine("\t...press any key to continue");
                Console.ReadKey();

            }
            
        }
       
    }
}
