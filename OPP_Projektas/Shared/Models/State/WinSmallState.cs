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
            for (int i = 0; i < 3; i++)
            {
                Random rand = new Random(); ;
                int choice = rand.Next(3);
                string url;
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

                FireworksType flyweight = FlyweightFactory.GetFlyweight(url);

                AllFireworks.Add(flyweight);
            }
        }

        public override void CreateFirworksNFW()
        {
            for (int i = 0; i < 3; i++)
            {
                Random rand = new Random();
                int top = rand.Next(100);
                int bottom = rand.Next(100);
                int left = rand.Next(100);
                int right = rand.Next(100);

                Fireworks fireworks = new Fireworks(top, bottom, left, right);

                int choice = rand.Next(3);
                string url = "";
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

                NotFlyweight notFlyweight = new NotFlyweight(fireworks, url);
                Console.WriteLine(notFlyweight.GetImage());

                AllFireworksNFW.Add(notFlyweight);
            }
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
