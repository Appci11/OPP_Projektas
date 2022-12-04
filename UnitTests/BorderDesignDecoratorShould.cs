using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPP_Projektas.Shared.Models.BorderDecorator;
using Xunit.Sdk;

namespace UnitTests
{
    public class BorderDesignDecoratorShould
    {
        BorderDesign borderDesign;

        [Fact]
        public void DecorateBordersWithHalloweenThemeAnd20pxWidth()
        {
            borderDesign = new BorderWidth("20px");
            var borderDecorator = new HalloweenDesignDecorator(borderDesign);

            string result = borderDecorator.Decorate("");

            Assert.Equal("border:dotted;border-color:darkorange;border-width:20px;", result);
        }
        [Fact]
        public void DecorateBordersWithChristmasThemeAnd20pxWidth()
        {
            borderDesign = new BorderWidth("20px");
            var borderDecorator = new ChristmasDesignDecorator(borderDesign);

            string result = borderDecorator.Decorate("");

            Assert.Equal("border:double;border-color:red;border-width:20px;", result);
        }
        [Fact]
        public void DecorateBordersWithEasterThemeAnd20pxWidth()
        {
            borderDesign = new BorderWidth("20px");
            var borderDecorator = new EasterDesignDecorator(borderDesign);

            string result = borderDecorator.Decorate("");

            Assert.Equal("border:dotted;border-color:aqua;border-width:20px;", result);
        }
        [Fact]
        public void DecorateBordersWithEasterThemeAndDecimalWidth()
        {
            borderDesign = new BorderWidth("20.5px");
            var borderDecorator = new EasterDesignDecorator(borderDesign);

            string result = borderDecorator.Decorate("");

            Assert.Equal("border:dotted;border-color:aqua;border-width:20.5px;", result);
        }
    }
}
