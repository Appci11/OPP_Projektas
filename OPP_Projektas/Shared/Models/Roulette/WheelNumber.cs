using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.Roulette
{
    public class WheelNumber
    {
        public int Number { get; }
        public WheelNumberColourEnum Colour { get; }
        public WheelNumber(int number, WheelNumberColourEnum colour)
        {
            Number = number;
            Colour = colour;
        }
    }
}
