using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.BorderDecorator
{
    public class BorderWidth : BorderDesign
    {
        public string Size;
        public BorderWidth(string size)
        {
            this.Size = size;
        }
        public string Decorate(string str)
        {
            return str+ "border-width:"+Size+";";
        }
    }
}
