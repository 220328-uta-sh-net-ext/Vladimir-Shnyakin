int hero = 10;
int monster = 10;
Random attack = new Random();
int hit = 0;

while ((hero > 0) || (monster > 0))
{   
    if ((hero > 0) && (monster > 0))
    {
        hit = attack.Next(1, 11);
        monster -= hit;
        Console.WriteLine($"Monster was damaged and lost {hit} health and now has {monster} health.");
    }
    else 
    {
        Console.WriteLine("Monster wins!");
        break;
    }
    if ((hero > 0) && (monster > 0))
    {
        hit = attack.Next(1, 11);
        hero -= hit;
        Console.WriteLine($"Hero was damaged and lost {hit} health and now has {hero} health.");
    }
    else 
    {
        Console.WriteLine("Hero wins!");
        break;  
    }       
} 