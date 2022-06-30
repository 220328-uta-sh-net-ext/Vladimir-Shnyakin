Console.WriteLine("Walk on the Axis");
Console.WriteLine("\nPlease enter number of lights");
int lights = Convert.ToInt32(Console.ReadLine());
int result = lights;

for (int i = 0; i <= lights; i++)
{
    result += lights - i;
}
Console.WriteLine($"Distance walked: {result} units");

Console.WriteLine("Your Name is Mine");
Console.WriteLine("Please enter male name");
string M = Console.ReadLine();
Console.WriteLine("\nPlease enter female name");
string W = Console.ReadLine();
string X = "";
string longerName = "";
string shorterName = "";
if (M.Length < W.Length)
{
    longerName = W;
    shorterName = M;
}
else
{
    shorterName = W;
    longerName = M;
}

if (M.Equals(W))
    Console.WriteLine("YES");
else if (M.Length != W.Length)
{
    for (int i = 0; i < shorterName.Length; i++)
        if (shorterName[i] != longerName[i])
        {
            for (int j = i; j < longerName.Length; j++)
                if (shorterName[i] == longerName[j])
                { X += longerName[j]; break; }
        }
        else X += longerName[i];
    if (X.Equals(shorterName))
        Console.WriteLine("Yes");
    else
        Console.WriteLine("NO");
}
else Console.WriteLine("NO");