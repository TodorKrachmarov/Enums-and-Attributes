using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        //CardGame();
        CustomEnumAttribute();
        //CardCompareTo();
        //CardRankPrint();
    }

    private static void CardGame()
    {
        List<Card> deck = GenerateDec();
        string firstPlayer = Console.ReadLine();
        string secondPlayer = Console.ReadLine();
        string winner = "";
        Card biggest = new Card("Two", "Clubs");
        int count = 0;

        while (count < 10)
        {
            try
            {
                string[] cartArgs = Console.ReadLine().Split();
                Card card = new Card(cartArgs[0], cartArgs[2]);

                if (deck.Contains(card))
                {
                    deck.Remove(card);
                    if (card.CompareTo(biggest) > 0 && count < 5)
                    {
                        winner = firstPlayer;
                        biggest = card;
                    }
                    else if (card.CompareTo(biggest) > 0 && count > 4)
                    {
                        winner = secondPlayer;
                        biggest = card;
                    }
                    count++;
                }
                else
                {
                    Console.WriteLine("Card is not in the deck.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No such card exists.");
            }
        }

        Console.WriteLine($"{winner} wins with {biggest.Name}.");
    }

    private static List<Card> GenerateDec()
    {
        List<Card> deck = new List<Card>();
        foreach (var suit in Enum.GetNames(typeof(CardSuit)))
        {
            foreach (var rank in Enum.GetNames(typeof(CardRank)))
            {
                deck.Add(new Card(rank, suit));
            }
        }

        return deck;
    }

    private static void CardCompareTo()
    {
        string rank = Console.ReadLine();
        string suit = Console.ReadLine();
        Card card1 = new Card(rank, suit);

        rank = Console.ReadLine();
        suit = Console.ReadLine();
        Card card2 = new Card(rank, suit);

        if (card1.CompareTo(card2) > 0)
        {
            Console.WriteLine(card1);
        }
        else
        {
            Console.WriteLine(card2);
        }
    }

    private static void CustomEnumAttribute()
    {
        string input = Console.ReadLine();

        if (input == "Rank")
        {
            PrintAttributes(typeof(CardRank));
        }
        else
        {
            PrintAttributes(typeof(CardSuit));
        }
    }

    private static void CardRankPrint()
    {
        Array cardValues = Enum.GetValues(typeof(CardRank));

        Console.WriteLine("Card Ranks:");
        foreach (var card in cardValues)
        {
            Console.WriteLine($"Ordinal value: {(int)card}; Name value: {card}");
        }
    }

    private static void PrintAttributes(Type type)
    {
        var attributes = type.GetCustomAttributes(false);
        Console.WriteLine(attributes);
    }
}
