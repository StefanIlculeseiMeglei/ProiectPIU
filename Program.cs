using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Animale
{
    
    class imagini
    {
        int nr;
        string cale = @"E:\Data\PIU\imgNames.txt"; 
        // numar de imagini
        char [,]imag=new char[30,20]; 
        // numele fisierelor cu imagini
        int []id=new int[30];
        // indicatorul unic pentru fiecare combinatie de imagine/sunet
        public imagini(){ }
        public imagini(string cale) {} // constructor in care precizam calea fisierul text cu numele imaginilor
        public void addImg(char s, int n) { } // ca parametri numele fisierului si indicatorul unic;obiectul este deja incarcat cu o lista de imagini din constructor
        public string retRandImg() { return null; } // returneaza numele unei imagini random
        public string retImg(int id) { return null; } // returneaza numele unui imagini dupa id
    }
    class sunete
    {
        int nr; // numar de sunete
        string cale = @"E:\Data\PIU\soundNames.txt"; 
        char[,] snd= new char[30,20] ; // numele fisierelor cu sunete
        int []id=new int[30]; // indicatorul unic pentru fiecare combinatie de imagine/sunet
        public sunete() { }
        public sunete(string cale) { } // constructor in care precizam calea fisierului text cu numele sunetelor
        public void addSnd(char[] s, int id) { } // ca parametri numele fisierului si indicatorul unic; obiectul este deja incarcat cu o lista de sunete din constructor
        public string retRandSnd() { return null; } // returneaza numele unui sunet random
        public string retSnd(int id) { return null; } // returneaza numele unui sunet dupa id
    }
    class joc 
    {
        int puncte;
        int runda;
        int rundaMax;
        public joc() { }
        public void startJoc(sunete S,imagini I) { } /// metoda care porneste jocul, toate datele necesare sunt transmise prin parametrii

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is my project!");
            Console.ReadKey();
        }
    }
}
