using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPP_Projektas.Shared.Models.Slots.SlotSymbols;
using OPP_Projektas.Shared.Models.Slots.SymbolTiers;
using Xunit.Sdk;

namespace UnitTests
{
    public class ISlotSymbolShould
    {
        ISlotSymbol slotSymbol;

        [Fact]
        public void MakeShallowCloneOfColorSymbolAndChangeValue()
        {
            slotSymbol = new ColorSymbol(new TierFirst());
            ISlotSymbol shallowClone = slotSymbol.ShallowClone();
            ISymbolTier tierSecond = new TierSecond();

            shallowClone.SymbolTier = tierSecond;

            Assert.Equal(shallowClone.SymbolTier,slotSymbol.SymbolTier);
        }
        [Fact]
        public void MakeShallowCloneOfColorSymbolAndCompareHashes()
        {
            slotSymbol = new ColorSymbol(new TierFirst());
            ISlotSymbol shallowClone = slotSymbol.ShallowClone();

            var originalHash = slotSymbol.GetHashCode();
            var cloneHash = shallowClone.GetHashCode();

            Assert.Equal(originalHash,cloneHash);
        }
        [Fact]
        public void MakeDeepCloneOfColorSymbolAndCompareHashes()
        {
            slotSymbol = new ColorSymbol(new TierFirst());
            ISlotSymbol deepClone = slotSymbol.DeepClone();

            var originalHash = slotSymbol.GetHashCode();
            var deepCloneHash = deepClone.GetHashCode();

            Assert.False(originalHash==deepCloneHash);
        }
        [Fact]
        public void GetColorSymbolTierFirstRender()
        {
            slotSymbol = new ColorSymbol(new TierFirst());

            var result = slotSymbol.Render();

            Assert.Equal("background-color: #0000FF; width: 100px; height: 100px; margin: 10px;", result);
        }

        [Fact]
        public void MakeShallowCloneOfPictureSymbolAndChangeValue()
        {
            slotSymbol = new PictureSymbol(new TierFirst());
            ISlotSymbol shallowClone = slotSymbol.ShallowClone();
            ISymbolTier tierSecond = new TierSecond();

            shallowClone.SymbolTier = tierSecond;

            Assert.Equal(shallowClone.SymbolTier, slotSymbol.SymbolTier);
        }
        [Fact]
        public void MakeShallowCloneOfPictureSymbolAndCompareHashes()
        {
            slotSymbol = new PictureSymbol(new TierFirst());
            ISlotSymbol shallowClone = slotSymbol.ShallowClone();

            var originalHash = slotSymbol.GetHashCode();
            var cloneHash = shallowClone.GetHashCode();

            Assert.Equal(originalHash,cloneHash);
        }
        [Fact]
        public void MakeDeepCloneOfPictureSymbolAndCompareHashes()
        {
            slotSymbol = new PictureSymbol(new TierFirst());
            ISlotSymbol deepClone = slotSymbol.DeepClone();

            var originalHash = slotSymbol.GetHashCode();
            var deepCloneHash = deepClone.GetHashCode();

            Assert.False(originalHash==deepCloneHash);
        }
        [Fact]
        public void GetPictureSymbolTierFirstRender()
        {
            slotSymbol = new PictureSymbol(new TierFirst());

            var result = slotSymbol.Render();

            Assert.Equal("background-color: #fff; background-image: url('assets/1-first.svg'); width: 100px; height: 100px; margin: 10px;", result);
        }
    }
}
