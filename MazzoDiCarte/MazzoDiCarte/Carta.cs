using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzoDiCarte
{
    class Carta
    {
        public string Seme { get; set; }
        public string Numero { get; set; }
        List<string> _semi;
        List<string> _numeri;

        public Carta(string seme, string numero)
        {
            Seme = seme;
            Numero = numero;
        }

        public Carta(int nSeme, int nNumero)
        {
            _semi = new List<string>() { "♥ ", "♦ ", "♣ ", "♠ " };
            _numeri = new List<string>() { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            Seme = _semi[nSeme];
            Numero = _numeri[nNumero];
        }

    }

    class Mazzo
    {
        List<Carta> _mazzo;

        public Mazzo()
        {
            _mazzo = new List<Carta>();
            for (int seme = 0; seme < 4; seme++)
            {
                for (int numero = 0; numero < 13; numero++)
                {
                    _mazzo.Add(new Carta(seme, numero));
                }
            }
            Mescola();
        }

        public void Mescola()
        {
            Random rnd = new Random();
            for (int i = 0; i < _mazzo.Count; i++)
            {
                int rndPos = rnd.Next(_mazzo.Count);
                Carta tmp = _mazzo[rndPos];
                _mazzo[rndPos] = _mazzo[i];
                _mazzo[i] = tmp;
            }
        }

        public List<Carta> Pesca(int nCarte)
        {
            List<Carta> cartePescate = new List<Carta>();
            for (int i = 0; i < nCarte; i++)
            {
                cartePescate.Add(_mazzo[i]);
            }
            return cartePescate;
        }

        public string CalcolaPunti(List<Carta> mano)
        {
            Dictionary<string, int> contaSemi = new Dictionary<string, int>();
            Dictionary<string, int> contaNumero = new Dictionary<string, int>();

            foreach (Carta c in mano)
            {
                if (!contaSemi.ContainsKey(c.Seme)) contaSemi.Add(c.Seme, 0);
                if (!contaNumero.ContainsKey(c.Numero)) contaNumero.Add(c.Numero, 0);
                contaSemi[c.Seme]++;
                contaNumero[c.Numero]++;
            }

        }
    }
}

