namespace BlackJack
{
    public class Blackjack
    {
        public bool Gewonnen { get; set; }
        public bool Busted { get; set; }

        public int Score(Card card)
        {
            if (card.Value.Length > 1)
            {
                switch (card.Value)
                {
                    case "aas":
                        return 10;
                    case "boer":
                        return 10;
                    case "vrouw":
                        return 10;
                    case "heer":
                        return 10;

                    default: return 0;
                }
            }
            else
            {
                return int.Parse(card.Value);
            }
        }
    }
}
