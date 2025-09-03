Console.WriteLine("square size");
int size = int.Parse(Console.ReadLine());

for (int i = 0; i < size; i++)
{
    for (int j = 0; j < size; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}

Console.WriteLine("right tri size");
int rtri = int.Parse(Console.ReadLine());
for (int i = 1; i <= rtri; i++)
{
    for (int j = 0; j < i; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}

Console.WriteLine("inverted right tri size");
int irtri = int.Parse(Console.ReadLine());
for (int i = irtri; i >= 1; i--)
{
    for (int j = 0; j < i; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}

Console.WriteLine("rhombus size");
int rhom = int.Parse(Console.ReadLine());
for (int i = 1; i <= rhom; i++)
{
    for (int j = 0; j < rhom - i; j++)
    {
        Console.Write(" ");
    }
    for (int j = 0; j < 2 * i - 1; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}
for (int i = rhom - 1; i >= 1; i--)
{
    for (int j = 0; j < rhom - i; j++)
    {
        Console.Write(" ");
    }
    for (int j = 0; j < 2 * i - 1; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}

Console.WriteLine("box size");
int box = int.Parse(Console.ReadLine());
for (int i = 0; i < box; i++)
{
    for (int j = 0; j < box; j++)
    {
        if (i == 0 || i == box - 1 || j == 0 || j == box - 1)
        {
            Console.Write("*");
        }
        else
        {
            Console.Write(" ");
        }
    }
    Console.WriteLine();
}