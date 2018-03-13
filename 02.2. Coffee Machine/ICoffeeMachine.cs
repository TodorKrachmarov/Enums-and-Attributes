using System.Collections.Generic;

public interface ICoffeeMachine
{
    IEnumerable<CoffeeType> CoffeesSold { get; }
    void BuyCoffee(string size, string type);
    void InsertCoin(string coin);
}
