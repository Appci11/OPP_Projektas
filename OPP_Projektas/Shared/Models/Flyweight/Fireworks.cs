using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.Flyweight
{
    public class Fireworks
    {
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public Fireworks() { }
        public Fireworks(int top, int bottom, int left, int right)
        {
            this.Top = top;
            this.Bottom = bottom;
            this.Left = left;
            this.Right = right;
        }
        public Fireworks(Fireworks fireworks)
        {
            this.Top = fireworks.Top;
            this.Bottom = fireworks.Bottom;
            this.Left = fireworks.Left;
            this.Right = fireworks.Right;
        }
    }
}
