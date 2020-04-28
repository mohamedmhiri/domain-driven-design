using System;

namespace DddInPractice.Logic
{
  public sealed class Money : ValueObject<Money>
  {

    public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);
    public static readonly Money TenMillimes = new Money(1, 0, 0, 0, 0, 0);
    public static readonly Money TwentyMillimes = new Money(0, 1, 0, 0, 0, 0);
    public static readonly Money FiftyMillimes = new Money(0, 0, 1, 0, 0, 0);
    public static readonly Money OneHundredMillimes = new Money(0, 0, 0, 1, 0, 0);
    public static readonly Money TwoHundredMillimes = new Money(0, 0, 0, 0, 1, 0);
    public static readonly Money FiveHundredMillimes = new Money(0, 0, 0, 0, 0, 1);
    public int TenMillimesCount { get; private set; }
    public int TwentyMillimesCount { get; private set; }
    public int FiftyMillimesCount { get; private set; }
    public int OneHundredMillimesCount { get; private set; }
    public int TwoHundredMillimesCount { get; private set; }
    public int FiveHundredMillimesCount { get; private set; }

    public decimal Amount => 
        TenMillimesCount * 0.01m +
        TwentyMillimesCount * 0.02m +
        FiftyMillimesCount * 0.05m +
        OneHundredMillimesCount * 0.1m +
        TwoHundredMillimesCount * 0.2m +
        FiveHundredMillimesCount * 0.5m;

    public Money(
      int tenMillimesCount,
      int twentyMillimesCount,
      int fiftyMillimesCount,
      int oneHundredMillimesCount,
      int twoHundredMillimesCount,
      int fiveHundredMillimesCount
    )
    {
      if (tenMillimesCount < 0)
        throw new InvalidOperationException();
      if (twentyMillimesCount < 0)
        throw new InvalidOperationException();
      if (fiftyMillimesCount < 0)
        throw new InvalidOperationException();
      if (oneHundredMillimesCount < 0)
        throw new InvalidOperationException();
      if (twoHundredMillimesCount < 0)
        throw new InvalidOperationException();
      if (fiveHundredMillimesCount < 0)
        throw new InvalidOperationException();
      TenMillimesCount = tenMillimesCount;
      TwentyMillimesCount = twentyMillimesCount;
      FiftyMillimesCount = fiftyMillimesCount;
      OneHundredMillimesCount = oneHundredMillimesCount;
      TwoHundredMillimesCount = twoHundredMillimesCount;
      FiveHundredMillimesCount = fiveHundredMillimesCount;
    }

    public static Money operator +(Money money1, Money money2)
    {
      Money sum = new Money(
        money1.TenMillimesCount + money2.TenMillimesCount,
        money1.TwentyMillimesCount + money2.TwentyMillimesCount,
        money1.FiftyMillimesCount + money2.FiftyMillimesCount,
        money1.OneHundredMillimesCount + money2.OneHundredMillimesCount,
        money1.TwoHundredMillimesCount + money2.TwoHundredMillimesCount,
        money1.FiveHundredMillimesCount + money2.FiveHundredMillimesCount
      );
      return sum;
    }
    public static Money operator -(Money money1, Money money2)
    {
      Money sum = new Money(
        money1.TenMillimesCount - money2.TenMillimesCount,
        money1.TwentyMillimesCount - money2.TwentyMillimesCount,
        money1.FiftyMillimesCount - money2.FiftyMillimesCount,
        money1.OneHundredMillimesCount - money2.OneHundredMillimesCount,
        money1.TwoHundredMillimesCount - money2.TwoHundredMillimesCount,
        money1.FiveHundredMillimesCount - money2.FiveHundredMillimesCount
      );
      return sum;
    }

    protected override bool EqualsCore(Money other)
    {
      return TenMillimesCount == other.TenMillimesCount
          && TwentyMillimesCount == other.TwentyMillimesCount
          && FiftyMillimesCount == other.FiftyMillimesCount
          && OneHundredMillimesCount == other.OneHundredMillimesCount
          && TwoHundredMillimesCount == other.TwoHundredMillimesCount
          && FiveHundredMillimesCount == other.FiveHundredMillimesCount;
    }

    protected override int GetHashCodeCore()
    {
      unchecked
      {
        int hashCode = TenMillimesCount;
        hashCode = (hashCode * 397) ^ TwentyMillimesCount;
        hashCode = (hashCode * 397) ^ FiftyMillimesCount;
        hashCode = (hashCode * 397) ^ OneHundredMillimesCount;
        hashCode = (hashCode * 397) ^ TwoHundredMillimesCount;
        hashCode = (hashCode * 397) ^ FiveHundredMillimesCount;
        return hashCode;
      }
    }
  }

}