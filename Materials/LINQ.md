What is LINQ?

(K)Intro
Linq (Language Integrated Query) Is a uniform query syntax that we can utilize within C# to retrieve data from different sources and formats. 
In short, with simplified syntax, we can easily retrieve data from collections, databases and other forms also using a standardized way of 
querying data from multiple sources with less coding and easier to read/understand the code.

(R)
Method syntax (also known as fluent syntax) uses extension methods included in the Enumerable or Queryable static class, similar to how you 
would call the extension method of any class.
The compiler converts query syntax into method syntax at compile time.
The following is a sample LINQ method syntax query that returns a collection of strings which contains a word "Tutorials".

    IList<string> stringList = new List<string>() {
        "C# Tutorials",
        "VB.NET Tutorials",
        "Learn C++",
        "MVC Tutorials" ,
        "Java" 
    };
    var result = stringList.Where(s => s.Contains("Tutorials"));

The extension method Where() accepts a predicate delegate as Func<Student, bool>. This means you can pass any delegate function that accepts a Student object as an 
input parameter and returns a Boolean value

(V)
We can write LINQ queries for the classes that implement IEnumerable<T> or IQueryable<T> interface. LINQ queries uses extension methods for classes that implement 
IEnumerable or IQueryable interface. The Enumerable and Queryable are two static classes that contain extension methods to write LINQ queries. 

Some extension methods are: Any, All, Contains, Count, Empty, First, Sum, ToList, Where

    var queryGermanShepherds = from dog in dogs
                            where dog.Breed == DogBreed.GermanShepherd
                            select dog;

(L)
One way of writing LINQ queries to an IEnumerable collection or IQueryable data sources such as a SQL database is by using query syntax.
Query syntax is very similar to SQL and is defined within C#.

The structure of a LINQ query starts with the FROM keyword and ends with the SELECT keyword.
A query basically states that you want to find something FROM an item "in" a collection of items that contains some range of information 
you want to find. Finally, you want the query to SELECT that thing and give it to you.
The keyword "in", is the range variable similar to what you would use in a foreach loop.

Here's an example of a standard LINQ query:
var fireTruck = FROM Sound in Environment WHERE Sound.Contains("Weee-ooo") SELECT  Sound;

After the WHERE operator, I supplied a condition in the query that would return only the sound that contain the sound �Wee-oo� and return it to 
me by placing it inside of the variable fireTruck.

-But what if you want to make a query to an item in a collection, but also make it easier to interpret? Let�s make a query using the LET keyword:

    var lowercaseCalls = from Calls in BirdCalls
    let bird = Calls.BirdName.ToLower()
    where bird.StartsWith("c")
    select bird;

    foreach (var call in lowercaseCalls)
    Console.WriteLine(call);

-Now let's write an even more specific query with the INTO keyword:

    var bendyAthletes = from Athletes in AthleteList
    where Athlete.flexibility > 180
    select Athletes
    into EXTREMELYBendyAthletes
    where EXTREMELYBendyAthletes.AthleteCountry = "Timbuktu"
    select EXTREMELYBendyAthletes;

    foreach (var athlete in bendyAthletes)
    Console.WriteLine(bendyAthletes);

(K)
The Lambda Expression with the help of LINQ, can represent anonymous methods with special syntax, making it less code and easier to read the information.
Example: var results = restaurants.Where(r=>r.restaurantName.Contains(restauratName)).ToList();
LINQ introduced a new type called Expression (using the System.Linq.Expressions) to take lambda expressions, as Expression<TDelegate> to compile into an 
Expression Tree, used as a data structure to a remote LINQ provider in a different AppDomain, instead of compiling into an executable code in the same 
AppDomain used by Func<T>. The Expression Tree is an In-memory representation of a lambda expression that holds the actual elements of the query and not the results itself.
Example: Expression<Func<userName, bool>> isUserAnAdmin = user=> user.Access ==Admin;

Deferred Execution is an evaluation of an expression that gets delayed until the realized value is actually required. This method improves 
performance by avoiding executing the expression unnecessarily.

    var restaurantsWithReviews = from r in restaurantList
                        where r.Reviews > 0
                        select r; (Query does not execute here, but the next part)
    foreach (Review reviewList in restaurantsWithReviews)
	Console.WriteLine("Review: {0}", reviewList.Reviews);

Immediate Execution is the process of immediately executing the Query to get the results instead of deferring it like the previous example.

    List<Restaurant> restaurantReviews = restaurantList.Where(r=>r.Review > 0).ToList();

(K)Conclusion
LINQ is a very valuable asset for coding in C# that simplifies coding, easier to understand and help collect and use data from all over the Solution. 

Resources: https://www.tutorialsteacher.com/linq




