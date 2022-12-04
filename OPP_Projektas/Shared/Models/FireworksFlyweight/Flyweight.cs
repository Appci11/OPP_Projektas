using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.FireworksFlyweight
{
    public class Flyweight
    {
        private Fireworks Fireworks { get; set; }
        public Flyweight(Fireworks fireworks)
        {
            this.Fireworks = fireworks;
        }
        public string GetImage(string src)
        {
            return "<img style=\"width:500px;height:500px;position: absolute; top:" + Fireworks.Top + "%;bottom:" + Fireworks.Bottom + "%;left:" + Fireworks.Left + "%;right:" + Fireworks.Right + "%;z-index:-100\" src=" + src + " />";
        }
    }
}
