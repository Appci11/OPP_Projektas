using System.Linq.Expressions;
using OPP_Projektas.Shared.Models.Enums.Slots;
using OPP_Projektas.Shared.Models.Slots;

namespace OPP_Projektas.Server.Models.Slots;

public static class Slots
{

    private static readonly Dictionary<Symbols, int> payouts = new Dictionary<Symbols, int>
    {
        {Symbols.Blue, 5},
        {Symbols.Red, 10},
        {Symbols.Green, 40},
        {Symbols.Yellow, 160},
        {Symbols.Orange, 1000},
    };

    public static SlotsResult Play(int betAmount)
    {
        var rng = new Random(Guid.NewGuid().GetHashCode());

        var number = rng.Next(1000 + 25) - 24;

        if (number == 1000)
        {
            return new SlotsResult
            {
                Payout = betAmount * payouts[Symbols.Orange],
                Symbols = new List<Symbols> { Symbols.Orange, Symbols.Orange, Symbols.Orange}
            };
        } 
        if (number >= 995)
        {
            return new SlotsResult
            {
                Payout = betAmount * payouts[Symbols.Yellow],
                Symbols = new List<Symbols> { Symbols.Yellow, Symbols.Yellow, Symbols.Yellow }
            };
        }
        if (number >= 990)
        {
            return new SlotsResult
            {
                Payout = betAmount * payouts[Symbols.Green],
                Symbols = new List<Symbols> { Symbols.Green, Symbols.Green, Symbols.Green }
            };
        }
        if (number >= 950)
        {
            return new SlotsResult
            {
                Payout = betAmount * payouts[Symbols.Red],
                Symbols = new List<Symbols> { Symbols.Red, Symbols.Red, Symbols.Red }
            };
        }
        if (number >= 900)
        {
            return new SlotsResult
            {
                Payout = betAmount * payouts[Symbols.Blue],
                Symbols = new List<Symbols> { Symbols.Blue, Symbols.Blue, Symbols.Blue }
            };
        }

        var symbols = new List<Symbols>() {Symbols.Orange, Symbols.Orange, Symbols.Orange};
        while (!symbols.Distinct().Skip(1).Any())
        {
            symbols = new List<Symbols> { (Symbols)rng.Next(0, 5), (Symbols)rng.Next(0, 5), (Symbols)rng.Next(0, 5)};
        }
        return new SlotsResult()
        {
            Payout = 0,
            Symbols = symbols
        };
    }
}