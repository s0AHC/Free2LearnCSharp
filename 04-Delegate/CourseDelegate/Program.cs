using System;
using System.Collections.Generic;

namespace CourseDelegate
{

    //有点郁闷了，课程名是Delegate，我也是想说delegate，不知道怎么就让generic蹭了流量，似乎超过delegate了。😂
    class Program
    {
        // 代理是对方法的，所以应用代理必然有方法与之对应
        // Define some customized delegates
        // 自定义一些代理
        public delegate int CustomizedIntDelegate(int OperandA,int OperandB);  
        public delegate double CustomizedDblDelegate(double OperandA,double OperandB); 

        // Define a customized generic delegate, no return
        // 自定义一个无返回值的泛型代理
        public delegate void CustomizedGenericDelegate<T>(T OperandA,T OperandB);
        
        /*
         Define a customized generic delegate with a return
         自定义一个有返回值的泛型代理
         1. All argumets type and return type should be put into the generic arguments type list, inclusived by <>, 
         2. In the generic arguments type list should conduct by arguments type, the return type as ending. 
            Same as Func delegate In example: T1 and T2 are argumets T is return type!
         1. 所有泛型的形参和返回类型都应该被放置在泛型参数列表<>中, 列表中一定是由参数作为起始，放完参数才能放返回类型。 
         2. 本例中T1和T2是参数，T是返回类型,其实系统定义Func delegate也是这样的        
        */

        public delegate T CustomizedGenericDelegateWithReturn<T1,T2,T>(T1 OperandA,T2 OperandB);
        static void Main(string[] args)
        {
            //两个普通委托调用, invoke可以省略
            CustomizedIntDelegate cdAdd = new CustomizedIntDelegate(MyMath.Add);
            var v = cdAdd.Invoke(300, 500);
            System.Console.WriteLine(value: $"Customed delegate Add method: {v}");
            v+=cdAdd(200,1000);
            System.Console.WriteLine(value: $"Customed delegate Add method with Multi cast: {v}");
            
            CustomizedDblDelegate cdDiv = new CustomizedDblDelegate(MyMath.Divide);
            var v1 = cdDiv(1000.00, 200.00);
            System.Console.WriteLine(value: $"Customed delegate Divide method: {v1}");

            /*
                Use system defined simple generic delegate class: Action and Func      
                使用系统定义的简单泛型delegate类型: Action and Func 
            */
            //Example: Action, for subroutine. 
            //本例: Action，用于无法返回的函数
            Action<int, int> multiplication = new Action<int, int>(MyMath.Multiplication); //Attention: just put method's name in Action invoke, suffix no more ()"
            Action<int, int> subtraction = new Action<int, int>(MyMath.Subtraction);
            multiplication.Invoke(100, 200);  //invoke used, but as you see at below it can be omitted!
            subtraction(300, 50);  //invoke was omitted!

            //Example: Func, for function
            //本例: Func, 用于有返回值得的函数
            Func<int, int, int> add = new Func<int, int, int>(MyMath.Add);
            System.Console.WriteLine($"Func delegate, add return: {add(100, 32)}"); ;
            Func<double, double, double> divide = new Func<double, double, double>(MyMath.Divide);
            System.Console.WriteLine($"Func delegate, divide return: {divide(400, 2)}"); ;

            /*
                使用自定义的泛型委托调用
            */
            // 无返回的泛型代理
            CustomizedGenericDelegate<int> cgdIntMul = new CustomizedGenericDelegate<int>(MyMath.Multiplication);
            CustomizedGenericDelegate<double> cgdDblSub = new CustomizedGenericDelegate<double>(MyMath.DblSubtraction);
            cgdIntMul(20, 300);            
            cgdDblSub(999, 333);
            
            // 有返回的泛型代理
            CustomizedGenericDelegateWithReturn<double, double, double> cgdrDblDiv = new CustomizedGenericDelegateWithReturn<double, double, double>(MyMath.Divide);
            // Equivalent to: var cgdrDblDiv=new CustomizedGenericDelegateWithReturn<double,double,double>(MyMath.Divide);
            // Equivalent to: double v3=cgdrDblDiv(66.99,11);
            var v3=cgdrDblDiv(66.99,11);
            // Don't just put cgdrDblDiv in output such as: Console.WriteLine($“{cgderDblDiv}”); use var please            
            // 不要直接将cgdrDblDiv放到Console.WriteLinev3+=cgdrDblDiv(33,11);因为没有这个的重写😂
            Console.WriteLine(value: $"Customized Generic Delegate With Return: {v3}"); 
            v3+=cgdrDblDiv(66,3.3);
            Console.WriteLine(value: $"Customized Generic Delegate With Return multi cast: {v3}"); 

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