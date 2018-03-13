using System;

public class Card : IComparable<Card>
{
    private CardRank rank;
    private CardSuit suit;

    public Card(string rank, string suit)
    {
        this.rank = (CardRank) Enum.Parse(typeof(CardRank), rank);
        this.suit = (CardSuit) Enum.Parse(typeof(CardSuit), suit);
    }

    public string Name { get { return $"{this.rank} of {this.suit}"; } }

    public int GetPower()
    {
        return (int) this.rank + (int) this.suit;
    }

    public override string ToString()
    {
        return $"Card name: {this.rank} of {this.suit}; Card power: {this.GetPower()}";
    }

    public int CompareTo(Card other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var rankComparison = suit.CompareTo(other.suit);
        if (rankComparison != 0) return rankComparison;
        return rank.CompareTo(other.rank);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        var card = obj as Card;

        return this.GetPower().Equals(card.GetPower());
    }
}
