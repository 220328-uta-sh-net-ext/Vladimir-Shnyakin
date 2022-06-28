Console.WriteLine("Please enter male name");
string M = Console.ReadLine();
Console.WriteLine("Please enter female name");
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
    shorterName = W;
    longerName = M;

if (M == W)
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
    if (X == shorterName)
        Console.WriteLine("Yes");
}
else Console.WriteLine("NO");
