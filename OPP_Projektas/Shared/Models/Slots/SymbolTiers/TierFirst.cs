using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.Slots.SymbolTiers
{
    public class TierFirst : ISymbolTier
    {
        private int tier = 1;
        public bool Equals(ISymbolTier? other)
        {
            if(other == null)
            {
                return false;
            }
            else
            {
                return this.GetType().Equals(other.GetType());
            }
        }
        public override int GetHashCode()
        {
            return tier.GetHashCode();
        }
    }
}
