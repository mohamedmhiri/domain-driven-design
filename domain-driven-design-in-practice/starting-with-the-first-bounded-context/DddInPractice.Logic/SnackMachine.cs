using System;

namespace DddInPractice.Logic
{
  public sealed class SnackMachine : Entity
  {
    public Money MoneyInside { get; private set; }
    public Money MoneyInTransaction { get; private set; }

    public void InsertMoney(
        Money money
    )
    {
      MoneyInTransaction = money;
    }

    public void ReturnMoney()
    {
      // MoneyInTransaction = new Money();
    }

    public void BuySnack()
    {
      MoneyInside += MoneyInTransaction;
      // MoneyInTransaction = new Money();
    }

  }
}
