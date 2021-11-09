// See https://aka.ms/new-console-template for more information

for (int i = 0; i < 10; i++)
{
    if (i % 2 != 0)
        continue;
    Console.WriteLine("*".PadLeft(i, '*'));
}

int j = 0;
do
{
    Console.WriteLine("*".PadLeft(j, '*'));
    if(j == 4)
    {
        break;
    }
    j++;
} while (j < 10);

j = 0;
while (j < 10)
{
    Console.WriteLine("*".PadLeft(j, '*'));
    j++;
}

foreach (var item in args)
{

}


Console.ReadLine();