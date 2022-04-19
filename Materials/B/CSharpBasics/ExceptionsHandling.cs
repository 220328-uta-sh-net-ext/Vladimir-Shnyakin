namespace CSharpBasics
{
    public class ExceptionsHandling
    {
        public static float Divide(int numerator, int denominator){
           float result=0;
           try{
               result = numerator/denominator;
           }
           catch(DivideByZeroException ex){
               Console.WriteLine(ex.Message);
           }
           catch(ArithmeticException ex){
               Console.WriteLine(ex.Message);
           }
           catch(Exception ex){
               Console.WriteLine(ex.Message);
           }
           finally{
               Console.WriteLine("Finally runs irrespective of exceptions");
           }
           return result;
        }
    }

    public class Temperature{
        float temperature = 0;
        public static void CheckTemperature(float temp){
            if(temp<30){
                throw new TemperatureException("Too cold for this device, please take it to warm place");
            }
            else 
                Console.WriteLine("Temperature is acceptable.");
        }
    }

    public class TemperatureException : ApplicationException
    {
        public TemperatureException(string message):base(message){

        }
    }
}