namespace Cards
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Card> list = new List<Card>();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] currentPair = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string face = currentPair[0];
                    CardSuit suit = GetCardSuit(currentPair[1]);

                    Card newCard = new Card(face, suit);

                    list.Add(newCard);

                }
                catch (ArgumentException ex)
                {
                   Console.WriteLine(ex.Message);
                }                
            }

            Console.WriteLine(string.Join(" ",  list));
        }

        private static CardSuit GetCardSuit(string v)
        {
            switch (v)
            {
                case "S":
                    return CardSuit.Spade;

                case "H":
                    return CardSuit.Heart;

                case "D":
                    return CardSuit.Diamond;

                case "C":
                    return CardSuit.Club;
                default:
                    throw new ArgumentException("Invalid card!");
            }
        }

        public enum CardSuit
        {
            Club = 1,
            Diamond = 2,
            Heart = 3,
            Spade = 4
        }

        public class Card
        {
            private string face;
            private CardSuit suit;
            private List<string> faces;

            public Card(string face, CardSuit suit)
            {
                this.faces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
                this.Face = face;
                this.Suit = suit;


            }

            public string Face
            {
                get { return face; }
                set
                {
                    if (!faces.Any(x => x == value))
                    {
                        throw new ArgumentException("Invalid card!");
                    }

                    face = value;
                }
            }


            public CardSuit Suit
            {
                get { return suit; }
                set
                {
                    suit = value;
                }
            }

            public override string ToString()
            {
                char viewSuit = '\u2660';

                switch (this.Suit)
                {
                    case CardSuit.Club:
                        viewSuit = '\u2663';
                        break;

                    case CardSuit.Diamond:
                        viewSuit = '\u2666';
                        break;

                    case CardSuit.Heart:
                        viewSuit = '\u2665';
                        break;

                    case CardSuit.Spade:
                        viewSuit = '\u2660';
                        break;

                }

                return $"[{Face}{viewSuit}]";
            }



        }
    }
}