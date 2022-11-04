using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.BorderDecorator
{
    public abstract class BorderDesignDecorator : BorderDesign
    {
        protected BorderDesign Wrappee;
        public BorderDesignDecorator(BorderDesign wrappee)
        {
            Wrappee = wrappee;
        }
        public void SetWrappee(BorderDesign wrappee)
        {
            Wrappee = wrappee;
        }
        public string Decorate(string str)
        {
            if (Wrappee == null)
            {
                return "";
            }
            else
            {
                return Wrappee.Decorate(str);
            }
        }
    }
}
