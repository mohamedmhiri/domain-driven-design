using DddInPractice.Logic;
using FluentAssertions;
using System;
using Xunit;

namespace DddInPractice.Tests
{
  public class MoneySpecs
  {
    [Fact]
    public void Sum_of_two_moneys_produces_correct_result()
    {
      // Arrange
      Money money1 = new Money(1, 2, 3, 4, 5, 6);
      Money money2 = new Money(1, 2, 3, 4, 5, 6);
      // Act
      Money sum = money1 + money2;
      // Assert
      sum.TenMillimesCount.Should().Be(2);
      sum.TwentyMillimesCount.Should().Be(4);
      sum.FiftyMillimesCount.Should().Be(6);
      sum.OneHundredMillimesCount.Should().Be(8);
      sum.TwoHundredMillimesCount.Should().Be(10);
      sum.FiveHundredMillimesCount.Should().Be(12);
    }

    [Fact]
    public void Two_money_instances_equal_if_contain_the_same_amount()
    {
      // Arrange
      Money money1 = new Money(1, 2, 3, 4, 5, 6);
      Money money2 = new Money(1, 2, 3, 4, 5, 6);
      // Assert
      money1.Should().Be(money2);
      money1.GetHashCode().Should().Be(money2.GetHashCode());
    }

    [Fact]
    public void Two_money_instances_not_equal_if_contain_different_amounts()
    {
      // Arrange
      Money dollar = new Money(0, 0, 0, 1, 0, 0);
      Money hundredCents = new Money(100, 0, 0, 0, 0, 0);
      // Assert
      dollar.Should().NotBe(hundredCents);
      dollar.GetHashCode().Should().NotBe(hundredCents.GetHashCode());
    }

    [Theory]
    [InlineData(-1, 0, 0, 0, 0, 0)]
    [InlineData(0, -2, 0, 0, 0, 0)]
    [InlineData(0, 0, -3, 0, 0, 0)]
    [InlineData(0, 0, 0, -4, 0, 0)]
    [InlineData(0, 0, 0, 0, -5, 0)]
    [InlineData(0, 0, 0, 0, 0, -6)]
    public void Cannot_create_money_with_negative_value(
      int tenMillimesCount,
      int twentyMillimesCount,
      int fiftyMillimesCount,
      int oneHundredMillimesCount,
      int twoHundredMillimesCount,
      int fiveHundredMillimesCount
    )
    {
      Action action = () => new Money(
        tenMillimesCount,
        twentyMillimesCount,
        fiftyMillimesCount,
        oneHundredMillimesCount,
        twoHundredMillimesCount,
        fiveHundredMillimesCount
      );

      action.Should().Throw<InvalidOperationException>();
    }


    [Theory]
    [InlineData(0, 0, 0, 0, 0, 0, 0)]
    [InlineData(1, 0, 0, 0, 0, 0, 0.01)]
    [InlineData(1, 2, 0, 0, 0, 0, 0.05)]
    [InlineData(1, 2, 3, 0, 0, 0, 0.20)]
    [InlineData(1, 2, 3, 4, 0, 0, 0.6)]
    [InlineData(1, 2, 3, 4, 5, 0, 1.6)]
    [InlineData(1, 2, 3, 4, 5, 6, 4.6)]
    [InlineData(11, 0, 0, 0, 0, 0, 0.11)]
    [InlineData(110, 0, 0, 0, 100, 0, 21.1)]
    public void Amount_is_calculated_Correctly(
      int tenMillimesCount,
      int twentyMillimesCount,
      int fiftyMillimesCount,
      int oneHundredMillimesCount,
      int twoHundredMillimesCount,
      int fiveHundredMillimesCount,
      double expectedAmount
    )
    {
      Money money = new Money(
        tenMillimesCount,
        twentyMillimesCount,
        fiftyMillimesCount,
        oneHundredMillimesCount,
        twoHundredMillimesCount,
        fiveHundredMillimesCount
      );
      money.Amount.Should().Be(Convert.ToDecimal(expectedAmount));
    }

    [Fact]
    public void Substraction_of_two_money_produces_correct_result()
    {
      Money money1 = new Money(10, 10, 10, 10, 10, 10);
      Money money2 = new Money(1, 2, 3, 4, 5, 6);

      Money result = money1 - money2;

      result.TenMillimesCount.Should().Be(9);
      result.TwentyMillimesCount.Should().Be(8);
      result.FiftyMillimesCount.Should().Be(7);
      result.OneHundredMillimesCount.Should().Be(6);
      result.TwoHundredMillimesCount.Should().Be(5);
      result.FiveHundredMillimesCount.Should().Be(4);
    }

    [Fact]
    public void cannot_substract_more_than_exists()
    {
      Money money1 = new Money(1, 0, 0, 0, 0, 0);
      Money money2 = new Money(0, 1, 0, 0, 0, 0);

      Action action = () =>
      {
        Money money = money1 - money2;
      };

      action.Should().Throw<InvalidOperationException>();
    }
  }
}