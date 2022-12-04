using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.FireworksFlyweight
{
    public class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> Flyweights { get; set; }
        public FlyweightFactory(){
            Flyweights = new List<Tuple<Flyweight, string>>();
        }
        public Flyweight GetFlyweight(Fireworks fw)
        {
            string key = (fw.Top.ToString() + fw.Bottom.ToString() + fw.Left.ToString() + fw.Right.ToString()).GetHashCode().ToString();
            Flyweight requestedFlyweight = GetByKey(key);
            if (requestedFlyweight == null)
            {
                requestedFlyweight = new Flyweight(fw);
                Flyweights.Add(new Tuple<Flyweight, string>(requestedFlyweight, key));
            }
            return requestedFlyweight;
        }
        private Flyweight GetByKey(string key)
        {
            foreach (Tuple<Flyweight, string> flyweight in Flyweights)
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
