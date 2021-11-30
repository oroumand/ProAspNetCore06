// See https://aka.ms/new-console-template for more information
using Operators;

//Money money01 = new Money(10000);
//var money02 = new Money(10000);

//Console.WriteLine($"Objects are equal: {money01 == money02}");
//Console.WriteLine($"Objects reference are equal: {object.ReferenceEquals(money01,money02)}");

//Money money03 = money01 + money02;

//Console.WriteLine(money03.Value);


Wallet wallet = new Wallet();

wallet[0] = new Money(1000);
wallet[1] = new Money(2000);
wallet[2] = new Money(5000);
wallet[3] = new Money(10000);
//wallet[4] = 20000;

int value = wallet[0];

byte moneyValue = (byte)wallet[1];

long longValue = wallet[0];


Console.WriteLine(wallet[1].Value);
wallet[1] = new Money(50000);
Console.WriteLine(wallet[1].Value);
Console.ReadLine();


