﻿using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;

using Animale;

using LibrarieModele;

using NivelStocareData;

namespace Animale_Consola
{

    internal class Program
    {

        static void Main(string[] args)
        {
            string numeFisierImg = ConfigurationManager.AppSettings["NumeFisierImg"];
            string numeFisierSnd = ConfigurationManager.AppSettings["NumeFisierSnd"];
            // initializare obiecte din clasele definite mai sus
            imagine img = new imagine();
            sunet snd = new sunet();
            imagini vimg = new imagini();
            sunete vsnd = new sunete();
            dataJoc data = new dataJoc();
            JocConsola joc = new JocConsola();
            AdministrareAnimale_FisierText admin = new AdministrareAnimale_FisierText(vimg, vsnd,numeFisierImg,numeFisierSnd);
            admin.afisareDate();
            int op,id;
            string name;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1)Afisare date");
                Console.WriteLine("2)Adaugare imagine");
                Console.WriteLine("3)Adaugare sunet");
                Console.WriteLine("4)Citire imagini din fisier");
                Console.WriteLine("5)Citire sunete din fisier");
                Console.WriteLine("6)Salvare imagine");
                Console.WriteLine("7)Salvare sunet");
                Console.WriteLine("8)Start joc");
                Console.WriteLine("9)Iesire aplicatie");
                Console.Write("Alegeti o optiune:");
                
                op =Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    
                    case 1:
                        admin.afisareDate();
                        Console.WriteLine("\t...press any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Dati id-ul:");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Dati numele fisierului:");
                        name = Console.ReadLine();
                        img = new imagine(id, name);
                        vimg.addImg(id, name);
                        admin.updateImagini(vimg);
                        Console.WriteLine("\t...press any key to continue");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Dati id-ul:");
                        id = Convert.ToInt32(Console.ReadLine()); 
                        Console.WriteLine("Dati numele fisierului:");
                        name = Console.ReadLine();
                        snd = new sunet(id, name);
                        vsnd.addSnd(id, name);
                        admin.updateSunete(vsnd);
                        Console.WriteLine("\t...press any key to continue");
                        Console.ReadKey();
                        break;
                    case 4:
                        admin.imaginiCitire(vimg, numeFisierImg);
                        Console.WriteLine("\t...press any key to continue");
                        Console.ReadKey();
                        break;
                    case 5:
                        admin.suneteCitire(vsnd, numeFisierImg);
                        Console.WriteLine("\t...press any key to continue");
                        Console.ReadKey();
                        break;
                    case 6:
                        admin.AddImagine(img);
                        Console.WriteLine("\t...press any key to continue");
                        Console.ReadKey();
                        break;
                    case 7:
                        admin.AddSunet(snd);
                        Console.WriteLine("\t...press any key to continue");
                        Console.ReadKey();
                        break;
                    case 8:
                        data.getDate(vimg, vsnd);
                        joc.startJoc(data);
                        break;
                    case 9:
                        Environment.Exit(0);
                        Console.WriteLine("\t...press any key to continue");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Optiune gresita!");
                        Console.WriteLine("\t...press any key to continue");
                        Console.ReadKey();
                        break;
                }

            }
        }
    }
}