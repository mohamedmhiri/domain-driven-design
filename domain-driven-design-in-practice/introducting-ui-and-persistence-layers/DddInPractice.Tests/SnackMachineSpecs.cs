using DddInPractice.Logic;
using FluentAssertions;
using System;
using Xunit;

namespace DddInPractice.Tests
{
    public class SnackMachineSpecs
    {
      [Fact]
      public void Return_money_empties_money_in_transaction()
      {
        var snackMachine = new SnackMachine();
        snackMachine.InsertMoney(Money.OneHundredMillimes);

        snackMachine.ReturnMoney();

        snackMachine.MoneyInTransaction.Amount.Should().Be(0.0m);
      }

      [Fact]
      public void Inserted_money_goes_to_amount_in_transaction()
      {
        var snackMachine = new SnackMachine();
        
        snackMachine.InsertMoney(Money.TenMillimes);
        snackMachine.InsertMoney(Money.OneHundredMillimes);

        snackMachine.MoneyInTransaction.Amount.Should().Be(0.11m);
      }

      [Fact]
      public void Cannot_insert_more_than_two_coins_at_a_time()
      {
        var snackMachine = new SnackMachine();
        Money oneDinar = Money.FiveHundredMillimes + Money.FiveHundredMillimes;

        Action action = () => snackMachine.InsertMoney(oneDinar);

        action.Should().Throw<InvalidOperationException>();
      }

      [Fact]
      public void Money_in_transaction_goes_inside_after_purchase()
      {
        var snackMachine = new SnackMachine();
        snackMachine.InsertMoney(Money.OneHundredMillimes);
        snackMachine.InsertMoney(Money.OneHundredMillimes);

        snackMachine.BuySnack();

        snackMachine.MoneyInTransaction.Should().Be(Money.None);
        snackMachine.MoneyInside.Amount.Should().Be(0.2m);
      }
    }
}