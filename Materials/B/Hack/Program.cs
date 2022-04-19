string s = "XLVIII";
int result = 0;
int number =0;
List<int> arabic = new List<int>(); 
for (int i=0; i<s.Length; i++)
{
    if (s[i] == 'M')
        number=1000;
    else if (s[i] == 'D')
        number=500;
    else if (s[i] == 'C')
        number=100;
    else if (s[i] == 'L')
        number=50;
    else if (s[i] == 'X')
        number=10;
    else if (s[i] == 'V')
        number=5;
    else if (s[i] == 'I')
        number=1;
    arabic.Add(number);
}
result+=arabic[arabic.Count-1];
for (int i = arabic.Count-1; i>0; i--)
{
    if (arabic[i] > arabic[i-1])
        result-=arabic[i-1];
    else if (arabic[i] <= arabic[i-1])
        result+=arabic[i-1];
}
for (int i = 0; i < arabic.Count; i++)
{
    Console.WriteLine(arabic[i]);
}

Console.WriteLine(result);