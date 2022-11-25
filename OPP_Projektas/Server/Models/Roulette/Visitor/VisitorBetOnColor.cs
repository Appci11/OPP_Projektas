using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Server.Models.Roulette.Visitor
{
    public class VisitorBetOnColor : IVisitor
    {
        public int VisitConcreteComponentA(ConcreteComponent element)
        {
            //Console.WriteLine(element.ReturnReturnMultiplayer() + " dauginciau is 2");
            return element.ReturnMultiplayer() * 2;
        }
    }
}
