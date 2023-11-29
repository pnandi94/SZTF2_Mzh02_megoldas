using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF2_Mzh02_megoldas
{
    public class BabonaException : Exception
    {
        public BabonaException() : base("Babonás okok miatt nem tehető be!")
        {

        }
    }
}
