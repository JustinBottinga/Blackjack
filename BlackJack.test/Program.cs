using BlackJack;

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        Deck deck = new Deck();
        Dealer dealer = new Dealer(game, deck);

        dealer.PlayGame();
    }
}