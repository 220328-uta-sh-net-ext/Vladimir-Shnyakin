// for non-Generic
using System.Collections;
//using System.Collections.Generic; for Generic
namespace CSharpBasics
{
    public class CSharpCollections
    {
        public static void NonGenerics(){
            /*ArrayList employees = new ArrayList();
            employees.Add("Marcelle"); // will be stored as object
            employees.Add("Fred");
            employees.Add(123);
            employees.Add(100.79);*/

            var employees = new ArrayList(){787,980,654,456,008};//{"Marcelle","Fred", "Abacus"}; // 123, 100.79}; //anonimous object notation
            //Console.WriteLine(employees[1]);
            Console.WriteLine($"Count - {employees.Count}");
            employees.Sort();
            foreach (var e in employees)
            {
                Console.WriteLine(e);
            }
            //employees.Remove("Fred");
            Console.WriteLine($"Count - {employees.Count}");
        }
    
        public static void GenericList(){
            List<int> scores = new List<int>(){54,56,87,67,89};
            List<object> something = new List<object>(){"54",56,87,67,89};//exactly like array
            List<string> employees = new List<string>();
            employees.Add("Marcelle");
            employees.Add("Sonny");
            employees.Add("Steve");
            employees.Insert(2, "Ola");
            
            Console.WriteLine($"Count - {employees.Count}");
            employees.Sort();
            employees.Reverse();
            //employees.Remove("Steve");
            employees[2]="Greg";
            //employees.RemoveAt(2);
            //Console.WriteLine(employees[1]);
            foreach (var e in employees)
            {
                Console.WriteLine(e);
            }
        }
    
        public static void GenericStack(){
            Stack<string> calls = new Stack<string>();
            calls.Push("9876543211");
            calls.Push("8765467898");
            calls.Push("6876543211");
            calls.Push("7890");

            calls.Pop();

            Console.WriteLine($" TOP of the stack {calls.Peek()}");
            foreach (var call in calls)
            {
                Console.WriteLine(call);
            }
        }  
   
        public static void GenericDictionary(){
            Dictionary<int,string> employees = new Dictionary<int, string>();
            employees.Add(101, "Joe");
            employees.Add(102, "Kurt");
            employees.Add(103, "Conner");
            employees.Add(104, "John");

            employees[102]= "Bob";
            foreach (var e in employees.Keys)
            {
                Console.WriteLine($"{e} - {employees[e]}");
            }
        }
    
        public static void GenericQueue(){

            Queue<string> numbers = new Queue<string>();
            numbers.Enqueue("one");
            numbers.Enqueue("two");
            numbers.Enqueue("three");
            numbers.Enqueue("four");
            numbers.Enqueue("five");
            numbers.Enqueue("");
            numbers.Enqueue("five");
            Console.WriteLine($"\nTotal number of positions in queue: {numbers.Count()}");
            Console.WriteLine("Removing positions...");
            numbers.Dequeue();
            numbers.Dequeue();
            numbers.Dequeue();
            Console.WriteLine($"\nNext position in queue is: {numbers.Peek()}");
            
            Console.WriteLine("\nCounting positions...");
            foreach( string number in numbers )
            {
            Console.WriteLine(number);
            }
            Console.WriteLine($"Total number of positions in queue: {numbers.Count()}");
        }
    
        public static void GenericLinkedList(){

          //  string[] words =
         //   { "the", "fox", "jumps", "over", "the", "dog" };
        //LinkedList<string> sentence = new LinkedList<string>(words);

        //sentence.AddFirst("today");

        //Console.WriteLine(sentence);

        LinkedList<int> list = new LinkedList<int>();

        list.AddLast(24);
        list.AddLast(76);
        list.AddLast(100);
        list.AddLast(89);
        Console.WriteLine($"First - {list.First.Value}");
        Console.WriteLine($"Last - {list.Last.Value}");
        //list.Remove(list.First);
        list.AddAfter(list.First,66);
        foreach (var l in list)
        {
            Console.WriteLine(l);
        }
        }
    }
}