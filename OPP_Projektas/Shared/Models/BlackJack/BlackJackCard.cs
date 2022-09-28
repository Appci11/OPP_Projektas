using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPP_Projektas.Shared.Models.Enums.Cards;

namespace OPP_Projektas.Shared.Models.BlackJack
{
    public class BlackJackCard
    {
        public Suit Suit { get; set; }
        public Value FaceValue { get; set; }
        public int ScoreValue { get; set; }
        public bool IsReduced { get; set; }

        public BlackJackCard(Suit suit, Value faceValue)
        {
            Suit = suit;
            FaceValue = faceValue;
            ScoreValue = GetScoreValue(FaceValue);
            IsReduced = false;
        }

        private int GetScoreValue(Value faceValue)
        {
            switch (faceValue)
            {
                case Value.Two:
                case Value.Three:
                case Value.Four:
                case Value.Five:
                case Value.Six:
                case Value.Seven:
                case Value.Eight:
                case Value.Nine:
                    return (int) faceValue + 2;
                case Value.Ten:
                case Value.Jack:
                case Value.Queen:
                case Value.King:
                    return 10;
                case Value.Ace:
                    return 11;
                default:
                    throw new ArgumentOutOfRangeException("Card face value does not exist");
            }
        }

        public void ReduceValue()
        {
            if (FaceValue != Value.Ace)
            {
                throw new Exception("Can only reduce Aces");
            }

            if (!IsReduced)
            {
                IsReduced = true;
                ScoreValue = 1;
            }
        }
    }
}
