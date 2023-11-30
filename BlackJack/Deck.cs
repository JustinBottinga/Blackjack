
namespace BlackJack
{
    public class Deck
    {
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            foreach (string suit in Card.suits)
            {
                foreach (string value in Card.values)
                {
                    _cards.Add(new Card(suit, value));
                }
            }
        }

        public Card DrawCard()
        {
            Random rnd = new Random();
            int random = rnd.Next(1, _cards.Count() - 1);
            if (_cards.Count() > 0)
            {
                Card drawnCard = _cards[random];
                _cards.RemoveAt(random);
                return drawnCard;
            }
            else
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }
        }

    }
}
