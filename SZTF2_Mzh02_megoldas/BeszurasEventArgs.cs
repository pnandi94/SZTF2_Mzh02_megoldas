using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF2_Mzh02_megoldas
{
    public class BeszurasEventArgs : EventArgs
    {
        public int Hely { get; }

        public BeszurasEventArgs(int hely)
        {
            this.Hely = hely;
        }
    }
}
