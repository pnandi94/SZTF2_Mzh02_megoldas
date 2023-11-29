using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF2_Mzh02_megoldas
{
    public class ListaBejaro<T> : IEnumerator<T>
    {
        public T Current => aktualis.Tartalom;

        object IEnumerator.Current => aktualis.Tartalom;

        private ListaElem<T> fej;
        private ListaElem<T> aktualis;

        public ListaBejaro(ListaElem<T> fej)
        {
            this.fej = fej;
            this.aktualis = new ListaElem<T>();
            this.aktualis.Kovetkezo = fej;
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (aktualis == null)
            {
                return false;
            }
            aktualis = aktualis.Kovetkezo;
            return aktualis != null;
        }

        public void Reset()
        {
            aktualis = new ListaElem<T>();
            aktualis.Kovetkezo = fej;
        }
    }
}
