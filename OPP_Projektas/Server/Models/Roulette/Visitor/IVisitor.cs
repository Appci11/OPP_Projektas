using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Server.Models.Roulette.Visitor
{
    public interface IVisitor
    {
        public int VisitConcreteComponentA(ConcreteComponent element);
    }
}
