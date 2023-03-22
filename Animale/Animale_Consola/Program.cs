using System;
using System.Configuration;
using System.Reflection;

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
            imagini img1 = new imagini(numeFisierImg);
            imagini img2 = new imagini();
            sunete snd1 = new sunete(numeFisierSnd);  
            sunete snd2 = new sunete(); 
            joc joc1 = new joc();
            AdministrareAnimale_FisierText admin = new AdministrareAnimale_FisierText(img1, snd1);
            admin.afisareDate();
            Console.WriteLine("This is my project!");
            Console.ReadKey();
        }
    }
}