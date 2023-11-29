using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF2_Mzh02_megoldas
{
    public class ListaElem<T>
    {
        public T Tartalom { get; set; }

        public ListaElem<T> Kovetkezo { get; set; }
    }
    public class LancoltLista<T> : IEnumerable<T> where T : IListabaTeheto, IComparable
    {
        public delegate void BeszurasHandler(int hely);
        public event BeszurasHandler BeszurasTortent;
        public event EventHandler<BeszurasEventArgs> BeszurasTortent2;

        public LancoltLista(int korlat)
        {
            this.Korlat = korlat;
        }

        private ListaElem<T> fej;

        public ListaElem<T> ElsoElem
        {
            get
            {
                return fej;
            }
        }

        private int korlat;
        public int Korlat
        {
            get
            {
                return korlat;
            }
            set
            {
                korlat = value;
                Tisztit();
            }
        }

        private int kulcsosszeg;

        public void Tisztit()
        {
            while (kulcsosszeg > Korlat)
            {
                if (fej != null)
                {
                    kulcsosszeg -= fej.Tartalom.Kulcs;
                    fej = fej.Kovetkezo;
                }
            }
        }

        public void ElemTorles(int kulcs)
        {
            //több elemnek is lehet ugyanaz a kulcsa!
            ListaElem<T> p = fej;
            ListaElem<T> e = null;
            while (p != null)
            {
                if (p.Tartalom.Kulcs == kulcs)
                {
                    if (e == null)
                    {
                        fej = p.Kovetkezo;
                    }
                    else
                    {
                        e.Kovetkezo = p.Kovetkezo;
                    }
                    kulcsosszeg -= p.Tartalom.Kulcs;
                }
                else
                {
                    e = p;
                    p = p.Kovetkezo;
                }

            }
        }

        public void SpecialisBeszuras(T tartalom)
        {
            if (tartalom.Kulcs == 13)
            {
                throw new BabonaException();
            }

            int hely = 0;
            ListaElem<T> uj = new ListaElem<T>();
            uj.Tartalom = tartalom;
            ListaElem<T> p = fej;
            ListaElem<T> e = null;
            while (p != null && p.Tartalom.Kulcs < tartalom.Kulcs)
            {
                e = p;
                p = p.Kovetkezo;
                hely++;
            }
            if (e == null)
            {
                uj.Kovetkezo = fej;
                fej = uj;
            }
            else
            {
                uj.Kovetkezo = p;
                e.Kovetkezo = uj;
            }
            kulcsosszeg += uj.Tartalom.Kulcs;
            BeszurasTortent?.Invoke(hely);
            BeszurasTortent2?.Invoke(this, new BeszurasEventArgs(hely));
            Tisztit();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListaBejaro<T>(ElsoElem);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListaBejaro<T>(ElsoElem);
        }
    }
}
