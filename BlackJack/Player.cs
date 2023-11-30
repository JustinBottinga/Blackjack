    namespace BlackJack
{
    public class Player
    {
        public string Name { get; init; }
        public List<Card> Hand { get; init; }

        public string State;

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        public void Addcard(Card card)
        {
            Hand.Add(card);
        }

        public string ShowHand()
        {
            string cards = "";
            foreach (Card card in Hand)
            {
                cards += card.Show() + " ";
            }
            return $"{Name} has {cards}";
        }
    }
}
