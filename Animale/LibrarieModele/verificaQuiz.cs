using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class verificaQuiz
    {
        internal const float FACTORCASTIG = 0.8f;
        private const int DVALOARE = 20;
        private const int DRUNDA = 10;
        internal int valoareRaspuns { get; set; }
        internal int MINWIN { get; set; }
        internal int RUNDAMAX { get; set; }
        public verificaQuiz(int _valoare=DVALOARE,int _RUNDAMAX=DRUNDA) {
            valoareRaspuns = _valoare;
            MINWIN = (int)(_valoare*_RUNDAMAX*FACTORCASTIG);
            RUNDAMAX = _RUNDAMAX;   
        }
        public bool raspunsQuiz(int opAleasa,int opCorecta)
        {
            if (opAleasa != opCorecta)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool verificaRunda(int runda)
        {
            if (runda >= RUNDAMAX)
                return false;
            else
                return true;

        }
        public bool verificaCastig(int puncte)
        {
            if (puncte < MINWIN)
                return false;
            else
                return true;
        }
    }
}
