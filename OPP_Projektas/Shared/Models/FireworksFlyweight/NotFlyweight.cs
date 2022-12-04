using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.FireworksFlyweight
{
    public class NotFlyweight
    {
        private Fireworks Fireworks { get; set; }
        private string Source { get; set; }
        public NotFlyweight(Fireworks fireworks, string source)
        {
            this.Fireworks = fireworks;
            this.Source = source;
        }
        public string GetImage()
        {
            return "<img style=\"width:500px;height:500px;position: absolute; top:" + Fireworks.Top + "%;bottom:" + Fireworks.Bottom + "%;left:" + Fireworks.Left + "%;right:" + Fireworks.Right + "%;z-index:-100\" src=" + Source + " />";
        }
    }
}
