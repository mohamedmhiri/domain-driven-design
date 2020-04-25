using System;
using System.Linq;

namespace DddInPractice.Logic
{
  public sealed class SnackMachine : Entity
  {
    public Money MoneyInside { get; private set; } = Money.None;
    public Money MoneyInTransaction { get; private set; } = Money.None;

    public void InsertMoney(
        Money money
    )
    {
      Money[] possibleCoins = { 
        Money.TenMillimes,
        Money.TwentyMillimes,
        Money.FiftyMillimes,
        Money.OneHundredMillimes,
        Money.TwoHundredMillimes,
        Money.FiveHundredMillimes
      };
      if (!possibleCoins.Contains(money))
        throw new InvalidOperationException();

      MoneyInTransaction += money;
    }

    public void ReturnMoney()
    {
      MoneyInTransaction = Money.None;
    }

    public void BuySnack()
    {
      MoneyInside += MoneyInTransaction;
      MoneyInTransaction = Money.None;
    }

  }
}
