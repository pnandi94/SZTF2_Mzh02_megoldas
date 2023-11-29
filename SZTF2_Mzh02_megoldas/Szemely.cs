using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF2_Mzh02_megoldas
{
    public class Szemely : IListabaTeheto, IComparable
    {
        public string Nev { get; set; }

        public int Eletkor { get; set; }

        public Szemely(string nev, int eletkor)
        {
            Nev = nev;
            Eletkor = eletkor;
        }

        public int Kulcs => Nev.Length * Eletkor;

        public int CompareTo(object obj)
        {
            Szemely masik = obj as Szemely;
            return (Nev.Length * Eletkor).CompareTo(masik.Nev.Length * masik.Eletkor);
        }
    }
}
