using System.Runtime.CompilerServices;

public class cardHolder {
  string cardNum;
  int pin;
  string firstName;
  string lastName;
  double balance;

  public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance) {
    this.cardNum = cardNum;
    this.pin = pin;
    this.firstName = firstName;
    this.lastName = lastName;
    this.balance = balance;

  }

  public string getNum() {
    return cardNum;
  }
  public int getPin() {
    return pin;
  }
  public string getFirstName() {
    return firstName;
  }
  public string getLastName() {
    return lastName;
  }
  public double getBalance() {
    return balance;
  }

  public void setNum(string newCardNum) {
    cardNum = newCardNum;
  }
  public void setPin(int newPin) {
    pin = newPin;
  }
  public void setFirstName(string newFirstName) {
    firstName = newFirstName;
  }
  public void setLastName(string newLastName) {
    lastName = newLastName;
  }
  public void setBalance(double newBalance) {
    balance = newBalance;
  }

  public static void Main(string[] args) {
    void printOptions() {
      Console.WriteLine("Please choose from one of the following options:");
      Console.WriteLine("1. Deposit");
      Console.WriteLine("2. Withdraw");
      Console.WriteLine("3. Show Balance");
      Console.WriteLine("4. Exit");
    }

    void deposit(cardHolder currentUser) {
      Console.WriteLine("How much money would you like to deposit: ");
      double deposit = double.Parse(Console.ReadLine());
      currentUser.setBalance(currentUser.getBalance() + deposit);
      Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance());
    }
    void withdraw(cardHolder currentUser) {
      Console.WriteLine("How much money would you like to withdraw: ");
      double withdraw = double.Parse(Console.ReadLine());
      if (currentUser.getBalance() < withdraw) {
        Console.WriteLine("Not enough funds to complete this transaction");
      } else {
        currentUser.setBalance(currentUser.getBalance() - withdraw);
        Console.WriteLine("Thank you for your withdrawal. Your new balance is: " + currentUser.getBalance());
      }
    }
    void balance(cardHolder currentUser) {
      Console.WriteLine("Your current balance is: " + currentUser.getBalance());
    }
    List<cardHolder> cardHolders = new List<cardHolder>();
    cardHolders.Add(new cardHolder("8675309", 1234, "Anakin", "Skywalker", 65432.10));
    cardHolders.Add(new cardHolder("8675310", 1235, "Luke", "Skywalker", 19957365.25));
    cardHolders.Add(new cardHolder("8675311", 1236, "Leia", "Skywalker", 2374867.37));
    cardHolders.Add(new cardHolder("8675312", 1237, "Ben", "Solo", 2131543.10));
    cardHolders.Add(new cardHolder("86753013", 1238, "Han", "Solo", 5.34));

    Console.WriteLine("Welcome to Star Wars ATM!");
    Console.WriteLine("Please insert your debit card: ");
    string debitCardNum = "";
    cardHolder currentUser;

    while (true) {
      try {
        debitCardNum = Console.ReadLine();
        currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
        if (currentUser != null) {
          break;
        } else Console.WriteLine("Card number not recognized. Please try again");
      }
      catch {
        Console.WriteLine("Card number not recognized. Please try again");
      }
    }

    Console.WriteLine("Please enter your pin: ");
    int userPin = 0;

    while (true) {
      try {
        userPin = int.Parse(Console.ReadLine());
        if (currentUser.getPin() == userPin) {
          break;
        } else Console.WriteLine("Pin number not recognized. Please try again");
      }
      catch {
        Console.WriteLine("Pin number not recognized. Please try again");
      }
    }

    Console.WriteLine("Welcome " + currentUser.getFirstName());
    int option = 0;
    do {
      printOptions();
      try {
        option = int.Parse(Console.ReadLine());
      }
      catch {

      };
      if (option == 1) {
        deposit(currentUser);
      } else if (option == 2) {
        withdraw(currentUser);
      } else if (option == 3) {
        balance(currentUser);
      } else if (option == 4) {
        break;
      } else {
        option = 0;
      }
    }
    while (option != 4);
    Console.WriteLine("Thank you! Have a nice day!");
  }
}
