using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigorlatWPF
{
    class Algorithm
    {
        public string Title { private set; get; }
        public string Code { private set; get; }

        public string Pseudo { private set; get; }
        public delegate int Algo();
        public Algo algo;

        public Algorithm(string title, string code, string pseudo, Algo algorithm)
        {
            Title = title;
            Code = code;
            Pseudo = pseudo;
            this.algo = algorithm;
        }

        public void Load(Code c, Pseudo p, MainWindow mw, AlgorithmCodes ac)
        {
            c.Title = this.Title;
            p.Title = this.Title;

            c.AddText(Code);
            p.AddText(Pseudo);

            int output = algo();

            mw.WriteOutput(ac.GetArrayString());
            mw.WriteOutput(output.ToString());

        }
        public static Algo GetAlgo(string s)
        {
            AlgorithmCodes ac = new AlgorithmCodes();

            switch (s)
            {
                default:
                    return null;
                case "Összegzés tétele":
                    return ac.SumFunc;
                case "Lineáris keresés":
                    return ac.LinearSearch;
            }
        }
    }
}
