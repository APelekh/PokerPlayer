using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck();
            PokerPlayer newPlayer = new PokerPlayer();
            //newDeck.Shuffle();
            //newPlayer.ReceiveCards = newDeck.Deal(5);
            bool test = newPlayer.HasPair();
            bool test1 = newPlayer.HasTwoPair();
            bool test2 = newPlayer.HasThreeOfAKind();
            bool test3 = newPlayer.HasStraight();
            bool test4 = newPlayer.HasFlush();
            bool test5 = newPlayer.HasFullHouse();
            bool test6 = newPlayer.HasFourOfAKind();
            bool test7 = newPlayer.HasStraightFlush();
            bool test8 = newPlayer.HasRoyalFlush();
            
            Console.ReadKey();
        }
    }
    /// <summary>
    /// Class for poker player
    /// </summary>
    class PokerPlayer
    {
        //declaring a list to store the player's hand
        private List<Card> Hand = new List<Card>();
        
        //FOR TESTING
        //static Card card1 = new Card(8, 1);
        //static Card card2 = new Card(8, 2);
        //static Card card3 = new Card(8, 3);
        //static Card card4 = new Card(8, 3);
        //static Card card5 = new Card(10, 0);
        //private List<Card> Hand = new List<Card>() { card1, card2, card3, card4, card5 };
        //public List<Card> ReceiveCards
        //{
        //    set { Hand = value; }
        //}

        /// <summary>
        /// Method for drawing cards
        /// </summary>
        /// <param name="list">List of cards</param>
        public void DrawHand (List<Card> list)
        {
            Hand = list;
        }
        
        // Enum of different hand types
        public enum HandType
        {
            HighCard,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }

        /// <summary>
        /// Returning hand rank by calling methods for checking each type of combinations
        /// </summary>
        public HandType HandRank
        {
            get { 
                if (this.HasPair() == true)
                {
                    return HandType.OnePair; 
                }
                else if (this.HasTwoPair() == true )
                {
                    return HandType.TwoPair;
                }
                else if (this.HasThreeOfAKind() == true)
                {
                    return HandType.ThreeOfAKind;
                }
                else if (this.HasStraight() == true)
                {
                    return HandType.Straight;
                }
                else if (this.HasFlush() == true)
                {
                    return HandType.Flush;
                }
                else if (this.HasFullHouse() == true)
                {
                    return HandType.FullHouse;
                }
                else if (this.HasFourOfAKind() == true)
                {
                    return HandType.FourOfAKind;
                }
                else if (this.HasStraightFlush() == true)
                {
                    return HandType.StraightFlush;
                }
                else if (this.HasRoyalFlush() == true)
                {
                    return HandType.RoyalFlush;
                }
                else
                {
                    return HandType.HighCard;
                }
            }
        }

        // Constructor that isn't used
        public PokerPlayer() { }

        /// <summary>
        /// Checking for Pair combination
        /// </summary>
        /// <returns>True if combination is valid and false if not</returns>
        public bool HasPair()
        {
            //List<IGrouping<Rank, Card>> handToCheck = Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 2).ToList();
            //if (handToCheck.Any(x => x.Count() == 2 && x.Count() <= 2))
            if (Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 1 && HasFullHouse() == false)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checking for Two Pairs combination
        /// </summary>
        /// <returns>True if combination is valid and false if not<</returns>
        public bool HasTwoPair()
        {
            //List<IGrouping<Rank, Card>> handToCheck = Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 2).ToList();
            if (Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 2)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checking for Three of a Kind combination
        /// </summary>
        /// <returns>True if combination is valid and false if not<</returns>
        public bool HasThreeOfAKind()
        {
            //List<IGrouping<Rank, Card>> handToCheck = Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 3).ToList();
            if (Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 3).Count() == 1 && HasFullHouse() == false)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checking for Straight combination
        /// </summary>
        /// <returns>True if combination is valid and false if not<</returns>
        public bool HasStraight()
        {
            List<Card> handToCheck = Hand.OrderBy(x => x.Rank).ToList();
            Rank rankOfFirstCard = handToCheck[0].Rank;
            if ((rankOfFirstCard == handToCheck[1].Rank - 1 && rankOfFirstCard == handToCheck[2].Rank - 2 && rankOfFirstCard == handToCheck[3].Rank - 3 && rankOfFirstCard == handToCheck[4].Rank - 4) && HasStraightFlush() == false && HasRoyalFlush() == false)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checking for Flush combination
        /// </summary>
        /// <returns>True if combination is valid and false if not<</returns>
        public bool HasFlush()
        {
            List<Card> handToCheck = Hand.OrderBy(x => x.Rank).ToList();
            Suit suitOfFirstCard = handToCheck[0].Suit;
            if ((suitOfFirstCard == handToCheck[1].Suit && suitOfFirstCard == handToCheck[2].Suit && suitOfFirstCard == handToCheck[3].Suit && suitOfFirstCard == handToCheck[4].Suit) && HasStraightFlush() == false && HasRoyalFlush() == false)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checking for Full House combination
        /// </summary>
        /// <returns>True if combination is valid and false if not<</returns>
        public bool HasFullHouse()
        {
            //if (HasThreeOfAKind() == true && HasPair() == true)
            //{
            //    return true;
            //}
            //List<IGrouping<Rank, Card>> handToCheckOne = Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 2).ToList();
            //List<IGrouping<Rank, Card>> handToCheckTwo = Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 3).ToList();
            if (Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 1 && Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 3).ToList().Count() == 1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checking for Four of a Kind combination
        /// </summary>
        /// <returns>True if combination is valid and false if not<</returns>
        public bool HasFourOfAKind()
        {
            //List<IGrouping<Rank, Card>> handToCheck = Hand.GroupBy(x => x.Rank).Where(x => x.Count() >= 4).ToList();
            //List<Suit> testList = handToCheck.Select(x => x.Select(y => y.Rank).Distinct());
            //if (Hand.GroupBy(x => x.Rank).Where(x => x.Count() >= 4).Count() == 1)
            //{
            //    return true;
            //}
            List<IGrouping<Rank,Card>> handToCheck = Hand.GroupBy(x => x.Rank).Where(x => x.Select(y => y.Suit).Distinct().Count() > 3).ToList();
            if (Hand.GroupBy(x => x.Rank).Where(x => x.Select(y => y.Suit).Distinct().Count() >= 4).Count() == 1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checking for Straight Flush combination
        /// </summary>
        /// <returns>True if combination is valid and false if not<</returns>
        public bool HasStraightFlush()
        {
            List<Card> handToCheck = Hand.OrderBy(x => x.Rank).ToList();
            Suit suitOfFirstCard = handToCheck[0].Suit;
            Rank rankOfFirstCard = handToCheck[0].Rank;
            //if (HasRoyalFlush() == true)
            //{
            //    return false;
            //}
            if (handToCheck[0].Rank == Rank.Two && handToCheck[4].Rank == Rank.Ace && HasRoyalFlush() == false)
            {
                if ((suitOfFirstCard == handToCheck[1].Suit && suitOfFirstCard == handToCheck[2].Suit && suitOfFirstCard == handToCheck[3].Suit && suitOfFirstCard == handToCheck[4].Suit) && (rankOfFirstCard == handToCheck[1].Rank - 1 && rankOfFirstCard == handToCheck[2].Rank - 2 && rankOfFirstCard == handToCheck[3].Rank - 3))
                {
                    return true;
                }
            }
            else if ((suitOfFirstCard == handToCheck[1].Suit && suitOfFirstCard == handToCheck[2].Suit && suitOfFirstCard == handToCheck[3].Suit && suitOfFirstCard == handToCheck[4].Suit) && (rankOfFirstCard == handToCheck[1].Rank - 1 && rankOfFirstCard == handToCheck[2].Rank - 2 && rankOfFirstCard == handToCheck[3].Rank - 3 && rankOfFirstCard == handToCheck[4].Rank - 4) && HasRoyalFlush() == false)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checking for Royal Flush combination
        /// </summary>
        /// <returns>True if combination is valid and false if not<</returns>
        public bool HasRoyalFlush()
        {
            List<Card> handToCheck = Hand.OrderBy(x => x.Rank).ToList();
            Suit suitOfFirstCard = handToCheck[0].Suit;
            Rank rankOfFirstCard = handToCheck[0].Rank;
            if (rankOfFirstCard == Rank.Ten)
            {
                if ((suitOfFirstCard == handToCheck[1].Suit && suitOfFirstCard == handToCheck[2].Suit && suitOfFirstCard == handToCheck[3].Suit && suitOfFirstCard == handToCheck[4].Suit) && (rankOfFirstCard == handToCheck[1].Rank - 1 && rankOfFirstCard == handToCheck[2].Rank - 2 && rankOfFirstCard == handToCheck[3].Rank - 3 && rankOfFirstCard == handToCheck[4].Rank - 4))
                {
                    return true;
                }
            }
            return false;
        }
    }
    //Guides to pasting your Deck and Card class

    //  *****Deck Class Start*****
    /// <summary>
    /// Class for deck of cards
    /// </summary>
    class Deck
    {
        //declaring randon number and list for holding the cards
        private Random rng = new Random();
        private List<Card> _deckOfCards = new List<Card>();
        //property for list of cards
        public List<Card> DeckOfCards
        {
            get { return _deckOfCards; }
            set { _deckOfCards = value; }
        }
        //read only property for count of remaining cards
        public int CardsRemaining
        {
            get { return _deckOfCards.Count; }
        }
        //list and property for holding discarded cards
        private List<Card> _discardedCards = new List<Card>();
        public List<Card> DiscardedCards
        {
            get { return _discardedCards; }
            set { _discardedCards = value; }
        }
        //constructor that generates 52 cards and stores them in list of cards
        public Deck()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.DeckOfCards.Add(new Card(i, j));
                }
            }
            
            //int j = 0;
            //int k = 0;
            //for (int i = 0; i < 52; i++)
            //{
            //    if (j > 12)
            //    {
            //        j = 0;
            //        k++;
            //    }
            //    if (k > 3)
            //    {
            //        k = 0;
            //    }
            //    this.DeckOfCards.Add(new Card(j,k));
            //    j++;
            //}
        }
        /// <summary>
        /// Method that deals certain amounts of cards
        /// </summary>
        /// <param name="numberOfCards">Number of cards to be dealt</param>
        /// <returns>List of cards</returns>
        public List<Card> Deal(int numberOfCards)
        {
            List<Card> listToReturn = this.DeckOfCards.Take(numberOfCards).ToList();
            this.DeckOfCards = this.DeckOfCards.Skip(numberOfCards).ToList();
            return listToReturn;
        }
        /// <summary>
        /// Method that moves all cards from discarded deck into main deck of cards and shuffles all cards
        /// </summary>
        public void Shuffle()
        {
            List<Card> shuffledList = new List<Card>();
            while (this.DiscardedCards.Count != 0)
            {
                this.DeckOfCards.Add(this.DiscardedCards[0]);
            }
            while (this.DeckOfCards.Count != 0)
            {
                Card cardToBeMoved = this.DeckOfCards[rng.Next(0, this.DeckOfCards.Count)];
                shuffledList.Add(cardToBeMoved);
                this.DeckOfCards.Remove(cardToBeMoved);
            }
            this.DeckOfCards = shuffledList;
        }
        /// <summary>
        /// Method which discards one card
        /// </summary>
        /// <param name="card">Card to be discarded</param>
        public void Discard(Card card)
        {
            this.DiscardedCards.Add(card);
        }
        /// <summary>
        /// Method which discards list of card
        /// </summary>
        /// <param name="cards">List of cards to be discarded</param>
        public void Discard(List<Card> cards)
        {
            while (cards.Count != 0)
            {
                this.DiscardedCards.Add(cards[0]);
                cards.RemoveAt(0);
            }
        }
    }

    //  *****Deck Class End*******

    //  *****Card Class Start*****
    /// <summary>
    /// Class for card with rank and suit properties
    /// </summary>
    class Card
    {
        private Suit _suit;
        public Suit Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        private Rank _rank;
        public Rank Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }
        public Card(int rank, int suit)
        {
            this.Rank = (Rank)rank;
            this.Suit = (Suit)suit;
        }
    }
    //Enums for suits
    public enum Suit
    {
        Heart, Diamond, Club, Spade
    }

    //Enums for ranks
    public enum Rank
    {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    }

    //  *****Card Class End*******
}
