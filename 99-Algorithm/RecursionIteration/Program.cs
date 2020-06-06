using System;

namespace RecursionIteration
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=5;            
            Console.WriteLine($"Recursion Method: {RecursionMethod(a)}");
            Console.WriteLine($"Iteration Methos: {IterationMethod(a)}");
            // Recursion method include iteration method, but iteration just iteration no recursion involved.
        }

        // Recursion Method
        static int RecursionMethod(int n)
        {
            if(n>=1)
            {
                return n+RecursionMethod(n-1);
            }
            else{return 0;}
        }

        // Iteration Method
        static int IterationMethod(int n)
        {
            int s=0;
            for(int i=0;i<=n;i++)
            {
                s+=i;
            }
            return s;
        }
    }
}
