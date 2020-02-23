using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBankOfSuncoast
{
  public class AccountManager
  {
    public List<Account> accounts { get; set; } = new List<Account>();

    public void SaveData()
    {
      var writer = new StreamWriter("accounts.csv");
      var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
      csvWriter.WriteRecords(accounts);
      writer.Flush();
    }

    public void LoadData()
    {
      var reader = new StreamReader("accounts.csv");
      var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      accounts = csvReader.GetRecords<Account>().ToList();
    }

    public void DisplayAccounts()
    {
      foreach (var account in accounts)
      {
        Console.WriteLine($"You have {account.Amount} in your {account.Name} account");
      }

    }

    public void Deposit(string name, int Amount)
    {
      var depositInput = accounts.First(accounts => accounts.Name == name).Amount;
      depositInput += Amount;
      accounts.First(accounts => accounts.Name == name).Amount = depositInput;
      SaveData();

      Console.WriteLine($"You have a total of ${depositInput} in your {name} account");

    }

    public void Withdrawal(string name, int Amount)
    {
      var withdrawalInput = accounts.First(accounts => accounts.Name == name).Amount;
      withdrawalInput -= Amount;
      accounts.First(accounts => accounts.Name == name).Amount = withdrawalInput;
      SaveData();


      Console.WriteLine($"You have a total of ${withdrawalInput} in your {name} account");

    }

    public void Transfer(string accountTypeA, string accountTypeB, int Amount)
    {
      accounts.First(accounts => accounts.Name == accountTypeA).Amount -= Amount;
      accounts.First(accounts => accounts.Name == accountTypeB).Amount += Amount;
      SaveData();
    }


  }
}