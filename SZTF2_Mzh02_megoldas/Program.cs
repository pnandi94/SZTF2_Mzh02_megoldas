using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF2_Mzh02_megoldas
{
    class Program
    {
        static void Main(string[] args)
        {
            LancoltLista<Szemely> juzerek = new LancoltLista<Szemely>(1000);
            juzerek.SpecialisBeszuras(new Szemely("Marika", 70)); //420
            juzerek.SpecialisBeszuras(new Szemely("Gyuszi", 60)); //360
            juzerek.SpecialisBeszuras(new Szemely("Eva", 50)); //150
            juzerek.SpecialisBeszuras(new Szemely("Aurél", 70)); //350

            foreach (Szemely item in juzerek)
            {
                Console.WriteLine(item.Nev + " " + item.Eletkor);
            }

            ;

        }
    }
}
