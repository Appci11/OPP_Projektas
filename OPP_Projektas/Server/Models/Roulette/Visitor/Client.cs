// grazina kokia suma reikes ismoketi laimetojui
// statymo dydi pasiima is to ka gauna is IComponent
// is kiek padauginti nusprendzia nusprendzia
// su dar nezinomos, ateinancio klases pagalba

namespace OPP_Projektas.Server.Models.Roulette.Visitor
{
    public class Client
    { 
        public static int ClientCode(IComponent component, IVisitor visitor)
        {
            return component.Accept(visitor);
        }
    }
}
