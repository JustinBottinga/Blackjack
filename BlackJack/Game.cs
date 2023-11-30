namespace BlackJack
{
    public class Game
    {
        public const string BlackJack = "Blackjack";
        public const string Busted = "Busted";
        public const string TwentyOne = "Twenty-One";
        public const string FiveCardCharlie = "Five Card Charlie";
        public string ScoreHand(List<Card> hand)
        {
            Blackjack blackjack = new Blackjack();
            int score = 0;
            foreach (Card card in hand)
            {
                score += blackjack.Score(card);
            }

            if (score == 21)
            {
                blackjack.Gewonnen = true;
                
                if (hand.Count == 2)
                {
                    return BlackJack;
                }
                else if (hand.Count == 5)
                {
                    return FiveCardCharlie;
                } else
                {
                    return TwentyOne;
                }

            } else if (score > 21)
            {
                blackjack.Busted = true;
                return Busted;
            } else
            {
                return score.ToString();
            }
        }
    }
}
