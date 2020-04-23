using DddInPractice.Logic;
using FluentAssertions;
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
      sum.OneCentCount.Should().Be(2);
      sum.TenCentCount.Should().Be(4);
      sum.QuarterCount.Should().Be(6);
      sum.OneDollarCount.Should().Be(8);
      sum.FiveDollarCount.Should().Be(10);
      sum.TwentyDollarCount.Should().Be(12);
    }

    [Fact]
    public void Two_of_two_moneys_produces_correct_result()
    {
      // Arrange
      Money money1 = new Money(1, 2, 3, 4, 5, 6);
      Money money2 = new Money(1, 2, 3, 4, 5, 6);
      // Act
      Money sum = money1 + money2;
      // Assert
      sum.OneCentCount.Should().Be(2);
      sum.TenCentCount.Should().Be(4);
      sum.QuarterCount.Should().Be(6);
      sum.OneDollarCount.Should().Be(8);
      sum.FiveDollarCount.Should().Be(10);
      sum.TwentyDollarCount.Should().Be(12);
    }
  }
}
