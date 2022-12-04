using OPP_Projektas.Shared.Models.FireworksFlyweight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP_Projektas.Shared.Models.State
{
    public class WinSmallState : SlotMachineState
    {
        public override void CreateFirworks()
        {
            Console.WriteLine("i is in win small create fireworks");
            for (int i = 0; i < 3; i++)
            {
                Random rand = new Random();
                int top = rand.Next(100);
                int bottom = rand.Next(100);
                int left = rand.Next(100);
                int right = rand.Next(100);

                Fireworks fireworks = new Fireworks(top, bottom, left, right);

                Flyweight flyweight = FlyweightFactory.GetFlyweight(fireworks);
                
                AllFireworks.Add(flyweight);
            }
        }

        public override void CreateFirworksNFW()
        {
            Console.WriteLine("i is in win small create fireworks nfw");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("i is in for");
                Random rand = new Random();
                int top = rand.Next(100);
                int bottom = rand.Next(100);
                int left = rand.Next(100);
                int right = rand.Next(100);

                Console.WriteLine("i is creating fireworks");
                Fireworks fireworks = new Fireworks(top, bottom, left, right);

                int choice = rand.Next(3);
                string url = "";
                Console.WriteLine("i is picking url");
                switch (choice)
                {
                    case 0:
                        url = "assets/fireworks1.gif";
                        break;
                    case 1:
                        url = "assets/fireworks2.gif";
                        break;
                    case 2:
                        url = "assets/fireworks3.gif";
                        break;
                    default:
                        url = "assets/fireworks4.gif";
                        break;
                }

                Console.WriteLine("i is creatubg notflyweight");
                NotFlyweight notFlyweight = new NotFlyweight(fireworks, url);
                Console.Write("notFlyweightm.GetImage(): ");
                Console.WriteLine(notFlyweight.GetImage());

                Console.WriteLine("i is adding notflyweight");
                AllFireworksNFW.Add(notFlyweight);
                Console.WriteLine("i is added notflyweight");
            }
            Console.WriteLine("i is out of for");
        }

        public override void DeleteFirworks()
        {
            AllFireworks.Clear();
        }

        public override void DeleteFirworksNFW()
        {
            AllFireworksNFW.Clear();
        }
    }
}
