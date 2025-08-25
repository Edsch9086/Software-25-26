Console.WriteLine("width");
int width = int.Parse(Console.ReadLine());
Console.WriteLine("length:");
int length = int.Parse(Console.ReadLine());
Console.WriteLine("char");
string rect = Console.ReadLine();

for (int i = 0; i < length; i++)
{
    for (int j = 0; j < width; j++)
    {
        Console.Write(rect);
    }
    Console.WriteLine();
}