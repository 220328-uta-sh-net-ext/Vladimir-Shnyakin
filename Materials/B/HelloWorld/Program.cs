// Comments - Single line. Comments are not processed by Compiler and CLR

/*
multi
line
Comments
*/
// This will print whatever is in the ()
Console.WriteLine("Welcome to Revature .Net training");
Console.Write("Please enter your name ");
var name = Console.ReadLine(); //This will allow user to take input in string format
var currentDate = DateTime.Now;
// Environment.NewLine or \n or vbCrLf in vb -> line break
// $ before "" its interpolated string
Console.WriteLine($"\nCurrent Date: {currentDate:d} and Current Time: {currentDate:t}\nHello {name}");