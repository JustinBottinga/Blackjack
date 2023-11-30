namespace BlackJack
{
    public class Card
    {
        private string _Suit;
        private string _Value;
        public string Value => _Value;

        public static string[] suits = { "klaveren", "ruiten", "harten", "schoppen" };
        public static string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "aas", "boer", "vrouw", "heer" };

        public Card(string suit, string value)
        {
            ValidateSuit(suit);
            ValidateValue(value);
        }

        private void ValidateSuit(string suit)
        {
            if (suits.Contains(suit))
            {
                _Suit = suit;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private void ValidateValue(string value)
        {
            if (values.Contains(value))
            {
                _Value = value;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public string Show()
        {
            string returnValue = "";
            string[] ToSuits = { "\u2660", "\u2665", "\u2666", "\u2663" };

            switch (_Suit)
            {
                case "klaveren":
                    returnValue += ToSuits[3];
                    break;
                case "ruiten":
                    returnValue += ToSuits[2];
                    break;
                case "harten":
                    returnValue += ToSuits[1];
                    break;
                case "schoppen":
                    returnValue += ToSuits[0];
                    break;
                default:
                    Console.WriteLine("Not a valid Suit");
                    break;
            }

            if (_Value.ToCharArray().Count() > 0)
                switch (_Value)
                {
                    case "aas":
                        returnValue += "A";
                        break;
                    case "boer":
                        returnValue += "B";
                        break;
                    case "heer":
                        returnValue += "H";
                        break;
                    case "vrouw":
                        returnValue += "V";
                        break;
                    default:
                        returnValue += _Value;
                        break;
                }

            return returnValue;
        }

    }
}

