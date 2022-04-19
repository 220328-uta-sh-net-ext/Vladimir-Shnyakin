Console.Write("Please enter first number ");
// user input is always in string format
//var num1 = Console.ReadLine();
double noAlphaNum1 = 0;
double noAlphaNum2 = 0;

bool canConvert = double.TryParse(Console.ReadLine(), out noAlphaNum1);
Console.Write("Please enter second number ");
//var num2 = Console.ReadLine();


bool canConvert2 = double.TryParse(Console.ReadLine(), out noAlphaNum2);
if ((canConvert == true) && (canConvert2 == true))
    Console.WriteLine($"{noAlphaNum1} + {noAlphaNum2} = {noAlphaNum1 + noAlphaNum2} ");
  //Console.WriteLine("number1 now = {0}", noAlphaNum1);
else
  Console.WriteLine("Your number is invalid");

// double num1 = Convert.ToDouble(Console.ReadLine());
// Console.Write("Please enter second number ");
// double num2 = Convert.ToDouble(Console.ReadLine());
// Console.WriteLine($"{num1} + {num2} = {num1 + num2} ");