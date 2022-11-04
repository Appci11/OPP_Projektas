using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.BorderDecorator
{
    public class EasterDesignDecorator : BorderDesignDecorator
    {
        public EasterDesignDecorator(BorderDesign wrappee) : base(wrappee)
        {
        }

        public new string Decorate(string str)
        {
            return base.Decorate("border:dotted;border-color:aqua;");
        }
    }
}
