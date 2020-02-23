using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBankOfSuncoast
{
  class Program
  {


    // static void SaveAccounts(List<Account> accounts)
    // {
    //   var writer = new StreamWriter("accounts.csv");
    //   var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
    //   csvWriter.WriteRecords(accounts);
    //   writer.Flush();
    // }
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to First Bank of Suncoast!");

      var manager = new AccountManager();
      manager.LoadData();


      var isRunning = true;
      while (isRunning)
      {
        Console.WriteLine("Do you want to see your (TOTAL), (DEPOSIT), (WITHDRAW), (TRANSFER), or (QUIT)?");
        var input = Console.ReadLine().ToLower();
        if (input == "total")
        {
          manager.DisplayAccounts();
        }
        else if (input == "deposit")
        {

          Console.WriteLine("Do you want to deposit into your (CHECKING) or (SAVINGS) account?");
          var whichAccount = Console.ReadLine();
          Console.WriteLine("How much do you want to deposit?");
          var depositAmount = int.Parse(Console.ReadLine());


          if (whichAccount == "checking")
          {
            manager.Deposit(whichAccount, depositAmount);

          }
          else if (whichAccount == "savings")
          {
            manager.Deposit(whichAccount, depositAmount);
          }
        }
        else if (input == "withdraw")
        {
          Console.WriteLine("Do you want to withdraw from your (CHECKING) or (SAVINGS) account?");
          var withdrawInput = Console.ReadLine().ToLower();
          Console.WriteLine("How much do you want to withdraw?");
          var withdrawTotal = int.Parse(Console.ReadLine());

          if (withdrawInput == "checking")
          {
            manager.Withdrawal(withdrawInput, withdrawTotal);
          }
          else if (withdrawInput == "savings")
          {
            manager.Withdrawal(withdrawInput, withdrawTotal);
          }
        }
        else if (input == "transfer")
        {
          Console.WriteLine("Do you want to transfer from your (CHECKING) or (SAVINGS) account?");
          var accountTypeA = Console.ReadLine().ToLower();
          Console.WriteLine("Where do you want to transfer to?");
          var accountTypeB = Console.ReadLine().ToLower();
          Console.WriteLine("How much do you want to transfer?");
          var transferInput = int.Parse(Console.ReadLine());

          manager.Transfer(accountTypeA, accountTypeB, transferInput);
        }

        else if (input == "quit")

          isRunning = false;
      }

    }
  }
}
