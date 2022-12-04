using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPP_Projektas.Shared.Models.FireworksFlyweight;

namespace OPP_Projektas.Shared.Models.State
{
    public abstract class SlotMachineState
    {
        protected FlyweightFactory FlyweightFactory;
        protected List<Flyweight> AllFireworks;
        protected List<NotFlyweight> AllFireworksNFW;

        /*public void SetFlyweightFactory(FlyweightFactory flyweightFactory)
        {
            this.FlyweightFactory = flyweightFactory;
            AllFireworks = new List<Flyweight>();
            AllFireworksNFW = new List<NotFlyweight>();
        }*/
        public SlotMachineState()
        {
            FlyweightFactory = new FlyweightFactory();
            AllFireworks = new List<Flyweight>();
            AllFireworksNFW = new List<NotFlyweight>();
        }
        public void SetContext(FlyweightFactory flyweightFactory, List<Flyweight> allFireworks, List<NotFlyweight> allFireworksNFW)
        {
            FlyweightFactory = flyweightFactory;
            AllFireworks = allFireworks;
            AllFireworksNFW = allFireworksNFW;
        }
        public FlyweightFactory GetFlyweightFactory()
        {
            return FlyweightFactory;
        }
        public List<Flyweight> GetAllFireworks()
        {
            return AllFireworks;
        }
        public List<NotFlyweight> GetAllFireworksNFW()
        {
            return AllFireworksNFW;
        }

        public abstract void CreateFirworks();
        public abstract void CreateFirworksNFW();
        public abstract void DeleteFirworks();
        public abstract void DeleteFirworksNFW();
    }
}
