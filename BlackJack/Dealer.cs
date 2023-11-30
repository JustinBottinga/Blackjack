namespace BlackJack
{
    public class Dealer
    {
        private Deck _deck = new Deck();
        private Game _game;
        private List<Player> _players = new List<Player>();

        private static string[] FinishGame = new string[]
        {
            Game.TwentyOne, Game.BlackJack, Game.Busted, Game.FiveCardCharlie
        };

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public Dealer(Game game, Deck deck)
        {
            _deck = deck;
            _game = game;
        }

        public void PlayGame()
        {
            Player House = new Player("Dealer");
            AddPlayer(House);

            Console.WriteLine("Welkom bij BlackJack!\n Hoe heet je?");
            string PlayerName = Console.ReadLine();
            Player player = new Player(PlayerName);
            AddPlayer(player);

            for (int i = 1; i < 7; i++)
            {
                string input = "";
                while (input != "y" && input != "n")
                {
                    Console.WriteLine("Wil je een speler toevoegen? y/n");
                    input = Console.ReadLine();
                }

                if (input == "y")
                {
                    Console.WriteLine("Hoe heet je?");
                    PlayerName = Console.ReadLine();
                    player = new Player(PlayerName);
                    AddPlayer(player);
                }
                else if (input == "n")
                {
                    break;
                }
            }

            foreach (Player p in _players)
            {
                for (int i = 0; i < 2; i++)
                {
                    p.Addcard(_deck.DrawCard());
                }
                Console.WriteLine(p.ShowHand());
            }

            bool running = true;
            while (running)
            {
                Console.WriteLine("===============================");
                foreach (Player p in _players)
                {
                    if (!FinishGame.Contains(_game.ScoreHand(p.Hand)) && int.Parse(_game.ScoreHand(p.Hand)) < 21)
                    {
                        //logic for the dealer
                        if (p.Name == "Dealer")
                        {
                            if (int.Parse(_game.ScoreHand(p.Hand)) < 18 && !FinishGame.Contains(_game.ScoreHand(p.Hand)))
                            {
                                p.Addcard(_deck.DrawCard());
                            } else
                            {
                                p.State = "Stopped";
                            }
                            Console.WriteLine(p.ShowHand());

                        }
                        else if (p.State != "Stopped")
                        {
                            Console.WriteLine(p.ShowHand());
                            Console.WriteLine($"{p.Name}: Typ 'n' voor een nieuwe kaart, 's' om te stoppen:");
                            string input = Console.ReadLine();

                            if (input == "n")
                            {
                                p.Addcard(_deck.DrawCard());
                                Console.WriteLine(p.ShowHand());
                            }
                            else if (input == "s")
                            {
                                p.State = "Stopped";
                            }
                        }
                    }
                    else 
                    {
                        p.State = "Stopped";
                        running = false;
                    }
                }
            }

            foreach (Player p in _players)
            {
                Console.WriteLine(_game.ScoreHand(p.Hand) + "! " + p.ShowHand());
            }
        }
    }
}
