using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.FireworksFlyweight
{
    public class FireworksType
    {
        //private Fireworks Fireworks { get; set; }
        private string ImageSource;
        public FireworksType(string fileName)
        {
            this.ImageSource = fileName;
        }
        public string GetImage(int top, int bottom, int left, int right)
        {
            return "<img style=\"width:500px;height:500px;position: absolute; top:" + top + "%;bottom:" + bottom + "%;left:" + left + "%;right:" + right + "%;z-index:-100\" src=" + ImageSource + " />";
        }
    }
}
