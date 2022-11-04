using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.BorderDecorator
{
    public class ChristmasDesignDecorator : BorderDesignDecorator
    {
        public ChristmasDesignDecorator(BorderDesign wrappee) : base(wrappee)
        {
        }

        public new string Decorate(string str)
        {
            return base.Decorate("border:double;border-color:red;");
        }
    }
}
