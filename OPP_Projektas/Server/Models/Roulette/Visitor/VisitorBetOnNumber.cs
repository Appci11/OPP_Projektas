using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Server.Models.Roulette.Visitor
{
    public class VisitorBetOnNumber : IVisitor
    {
        public int VisitConcreteComponentA(ConcreteComponent element)
        {
            return element.ReturnMultiplayer() * 32;
        }
    }
}
