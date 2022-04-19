using CSharpBasics; 


/*Console.WriteLine("Please enter a number ");
var x=Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Please enter another a number ");
var y=Convert.ToDouble(Console.ReadLine());
var result=Mathematics.Add(x,y);
Console.WriteLine($"{x} + {y} = {result}");*/

//arrays 

//Collection.Arrays_1D();
//Collection.Arrays_MultiDimensional();

/*int[] a = {45, 56, 76, 43,49}; // shorthand for declaring
var result = Collection.Reverse(a);
foreach (var item in a)
{
    Console.Write(item+ " ");
}
Console.WriteLine();
foreach (var item in result)
{
    Console.Write(item+ " ");
}*/
//Collection.JaggedArrays();
//int[] a = {45, 0, 76, 0,49};
//Collection.MoveZeroes(a);
//CSharpCollections.NonGenerics();
//CSharpCollections.GenericList();
//CSharpCollections.GenericStack();
//CSharpCollections.GenericDictionary();
//CSharpCollections.GenericQueue();
//CSharpCollections.GenericLinkedList();
// int numerator=0, denominator=0;
// n1:
// Console.WriteLine("Please enter the numerator ");
// try{
// numerator = Convert.ToInt32(Console.ReadLine());
// }
// catch(OverflowException ex){
//     Console.WriteLine("Too big number " + ex.Message);
//     goto n1;
// }
// catch(FormatException ex){
//     Console.WriteLine("Please use correct integer as input " + ex.Message);
// }
// catch(Exception ex)
// {
//     Console.WriteLine(ex.Message);
//     goto n1;
// }
// Console.WriteLine("Please enter the denominator ");
// denominator = Convert.ToInt32(Console.ReadLine());
// var result=ExceptionsHandling.Divide(numerator,denominator);
// Console.WriteLine(result);
try{
Temperature.CheckTemperature(25);
}
catch(TemperatureException ex){
    Console.WriteLine(ex.Message);
}