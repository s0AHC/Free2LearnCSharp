using System;
using System.Collections.Generic;

namespace CourseDelegate
{
    class Program
    {
        // Define some customized delegates
        // 自定义一些代理
        public delegate int CustomizedIntDelegate(int OperandA,int OperandB);  
        public delegate double CustomizedDblDelegate(Double OperandA,double OperandB); 

        // Define a customized generic delegate, no return
        // 自定义一个无返回值的泛型代理
        public delegate void CustomizedGenericDelegate<T>(T OperandA,T OperandB);
        
        /*
         Define a customized generic delegate with a return
         自定义一个有返回值的泛型代理
         1. All argumets and return type should be put into the generic arguments list inclusived by <>, 
         2. and conduct by arguments, the return type as ending. Same as Func delegate In example: T1 and T2 are argumets T is return type!
         1. 所有泛型的形参和返回类型都应该被放置在泛型参数列表<>中, 并由参数开始，放完参数才能放返回类型。 
         2. 本例中T1和T2是参数，T是返回类型,其实系统定义Func delegate也是这样的        
        */

        public delegate T CustomizedGenericDelegateWithReturn<T1,T2,T>(T1 OperandA,T2 OperandB);
        static void Main(string[] args)
        {
            /*
            Use system defined delegate class: Action and Func      
            使用公司定义的delegate类型: Action and Func 
            */

            //Example: Action, for subroutine. 
            //本例: Action，用于无法返回的函数
            Action<int, int> multiplication = new Action<int, int>(MyMath.Multiplication); //Attention: just put method's name in Action invoke, suffix no more ()"
            Action<int, int> subtraction = new Action<int, int>(MyMath.Subtraction);
            multiplication(100, 200);  //invoke used, but as you see at below it can be omitted!
            subtraction(300, 50);  //invoke was omitted!

            //Example: Func, for function
            //本例: Func, 用于有返回值得的函数
            Func<int, int, int> add = new Func<int, int, int>(MyMath.Add);
            System.Console.WriteLine($"Func delegate, add return: {add(100, 32)}"); ;
            Func<double, double, double> divide = new Func<double, double, double>(MyMath.Divide);
            System.Console.WriteLine($"Func delegate, divide return: {divide(400, 2)}"); ;

            CustomizedIntDelegate cdAdd = new CustomizedIntDelegate(MyMath.Add);
            var v = cdAdd(300, 500);

            System.Console.WriteLine(value: $"Customed delegate Add method: {v}");
            CustomizedDblDelegate cdDiv = new CustomizedDblDelegate(MyMath.Divide);
            var v1 = cdDiv(1000.00, 200.00);
            System.Console.WriteLine(value: $"Customed delegate Divide method: {v1}");

            CustomizedGenericDelegate<int> cgdIntMul = new CustomizedGenericDelegate<int>(MyMath.Multiplication);
            CustomizedGenericDelegate<double> cgdDblSub = new CustomizedGenericDelegate<double>(MyMath.DblSubtraction);
            CustomizedGenericDelegateWithReturn<double, double, double> cgdrDblDiv = new CustomizedGenericDelegateWithReturn<double, double, double>(MyMath.Divide);
            // Equivalent to: var cgdrDblDiv=new CustomizedGenericDelegateWithReturn<double,double,double>(MyMath.Divide);
            cgdIntMul(20, 300);            
            cgdDblSub(999, 333);
            var v3=cgdrDblDiv(66.99,3.3);
            // Don't just put cgdrDblDiv in output such as: Console.WriteLine($“{cgderDblDiv}”); use var please            
            // 不要直接将cgdrDblDiv放到Console.WriteLine没有这个的重写😂
            Console.WriteLine(value: $"Customized Generic Delegate With Return: {v3}"); 

        }

        class MyMath
        {
            //Function
            //返回函数
            public static int Add(int OperandA, int OperandB) => OperandA + OperandB;

            public static double Divide(double OperandA, double OperandB)
            { 
                return OperandA / OperandB;
            }

            //Subroutine
            //功能方法
            public static void Multiplication(int OperandA, int OperandB) => Console.WriteLine($"Action delegation,Multiplication: {OperandA * OperandB}");
            public static void Subtraction(int OperandA, int OperandB) => Console.WriteLine($"Action delegation,Subtraction: {OperandA - OperandB}");
            public static void DblSubtraction(double OperandA,double OperandB)=>System.Console.WriteLine($"Generic delegate, Double Subtraction: {OperandA-OperandB}");
        }
    }
}