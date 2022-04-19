using Words;

//Palindromes.Palindrome("Anna");
//Console.WriteLine(Palindromes.Palindrome("Anna"));
//Console.WriteLine(Anagrams.Anagram("salesmen", "nameless"));
start:
Console.WriteLine("Welcome! Anagram or Palindrome? a/p");
string answer = Console.ReadLine();
string firstWord;
string secondWord;
string palindro;
if (answer == "a")
{
first:
    Console.Write("Please enter first word: ");
    firstWord = Console.ReadLine();
    for (int i = 0; i < firstWord.Length; i++)
    {
        if (!char.IsLetter(firstWord[i]))
        {
            Console.WriteLine("Wrong input.");
            goto first;
        }
    }
    Console.WriteLine(" ");
second:
    Console.Write("Please enter second word: ");
    secondWord = Console.ReadLine();
    for (int i = 0; i < secondWord.Length; i++)
    {
        if (!char.IsLetter(secondWord[i]))
        {
            Console.WriteLine("Wrong input.");
            goto second;
        }
    }
Anagrams.Anagram(firstWord,secondWord);
}
else if (answer == "p")
{
pali:
    Console.Write("Please enter a palindrome: ");
    palindro = Console.ReadLine();
    for (int i = 0; i < palindro.Length; i++)
    {
        if (!char.IsLetter(palindro[i]))
        {
            Console.WriteLine("Wrong input.");
            goto pali;
        }
    //Palindromes.Palindrome(palindro);
    Console.WriteLine(Palindromes.Palindrome(palindro));
    }
}
else
{
    Console.WriteLine("Wrong input. Please hit 'a' or 'p'");
    goto start;
}