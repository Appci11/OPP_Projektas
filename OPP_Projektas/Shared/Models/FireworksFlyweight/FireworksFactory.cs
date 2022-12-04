using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.FireworksFlyweight
{
    public class FireworksFactory
    {
        private List<Tuple<FireworksType, string>> Flyweights { get; set; }
        public FireworksFactory(){
            Flyweights = new List<Tuple<FireworksType, string>>();
        }
        public FireworksType GetFlyweight(string source)
        {
            string key = source.GetHashCode().ToString();
            FireworksType requestedFlyweight = GetByKey(key);
            if (requestedFlyweight == null)
            {
                requestedFlyweight = new FireworksType(source);
                Flyweights.Add(new Tuple<FireworksType, string>(requestedFlyweight, key));
            }
            return requestedFlyweight;
        }
        private FireworksType GetByKey(string key)
        {
            foreach (Tuple<FireworksType, string> flyweight in Flyweights)
            {
                string currKey = flyweight.Item2;
                if (key.Equals(currKey))
                {
                    return flyweight.Item1;
                }
            }
            return null;
        }
    }
}
