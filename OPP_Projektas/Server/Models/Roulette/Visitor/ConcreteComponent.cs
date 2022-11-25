using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Server.Models.Roulette.Visitor
{
    public class ConcreteComponent : IComponent
    {
        int _mult = 0;
        public ConcreteComponent(int mult)
        {
            _mult = mult;
        }
        public int Accept(IVisitor visitor)
        {
            int sk = visitor.VisitConcreteComponentA(this);
            return sk * _mult;
        }

        // planas sitoj dalyje grazint statymo suma
        // kol db nera, apeinam per aplinkui ir sito nenaudojam
        public int ReturnMultiplayer()
        {
            return 1;
        }
    }
}
