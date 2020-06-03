using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace List
{
    public class Users  //Class Users；类 用户
    {
        public string Name;
        public int Age;

        // Constructor of two parameters; 两参数的构造函数
        // Attention: There is no customized non-parameter constructor, so system will build a implicit non-parameter constructor with default
        // The default values like(int 0/ double 0.0D/ bool false/ string null/ decmial 0.0M etc. ).
        // 注意: 如果没有自定义无参构造器，系统会自动用默认值生成一个隐式构造器作为默认构造器
        public Users(string _Name, int _Age)
        {
            Name = _Name;
            Age = _Age;
        }
    }
       
    class Program
    {
        static void Main(string[] args)
        {
            Users U = new Users("jiang", 24);
            
            IList<Users> UILists = new List<Users>(); 
            // Attention: IList<T> use List<T> to new an instantiation, see the right side of equal sign.
            // 千万要注意：等式的右边是List<Users>,而不是 IList<Users>, otherwise your will get error: interface can't be instantiation
            //如果在List前面加一个I， 就会出现错误：抽象类或接口无法创建实例。
            
            UILists.Add(U);

            U = new Users("wang", 22);
            UILists.Add(U);

            List<Users> I = ConvertIListToList<Users>(UILists);

            Console.WriteLine(I[0].Name);
            Console.WriteLine(I[1].Name);

            Console.Read();
        }

        /// <summary>
        /// 转换IList<T>为List<T>      // Convert IList<T> to List<T>
        /// </summary>
        /// <typeparam name="T">指定的集合中泛型的类型</typeparam> // Assign the type of generic inside the collection
        /// <param name="AnIList">需要转换的IList</param>    // The IList<T> that will be convert
        /// <returns></returns>

        // The static method for convert IList<T> to List<T>
        // 泛型转换的静态方法。
        public static List<T> ConvertIListToList<T>(IList<T> AnIList) where T : class   
        {
            if (AnIList != null && AnIList.Count >= 1)
            {
                List<T> list = new List<T>();

                // Copy all elements of IList<T> to List<T>
                // 将IList中的元素复制到List中
                for (int i = 0; i < AnIList.Count; i++)  
                {
                    T temp = AnIList[i] as T;
                    if (temp != null)
                        list.Add(temp);
                }
                return list;
            }
            return null;
        }
    }

    /*
        IList<> is generic interface, defined some methods should be implemented by coder.
        IList<>是个泛型接口,定义了一些操作方法这些方法要你自己去实现;
        List<> is generic class has implemented method that defined by IList<>.
        List <>是泛型类,它已经实现了IList<>定义的那些方法。

        Let's check below two sentances:
            IList<Class1> iList1 =new List<Class1>();
            List<Class1> List1 =new List<Class1>();

        As you saw they all just create an instant of List<Class1> object, so we can say that an equivalent operation.
        这两行代码，从操作上来看，实际上都是创建了一个List<Class1>对象的实例，也就是说，他们的操作没有区别。
        but the return value type are different.
        只是用于保存这个操作的返回值变量类型不一样而已。

        Why we use IList? Just for the different purpose. Use IList<T> means we thought IList<T> defined methods are enough for us.
        那么，我们可以这么理解，这两行代码的目的不一样。
        
        List<Class1> iList1 =new List<Class1>(); This sentance want to create a List<Class1> object and want to use List<> defined methods.
        List<Class1> List1 =new List<Class1>();  这句是想创建一个List<Class1>，而且需要使用到List<T>的功能，进行相关操作。
        
        IList<Class1> iList1 =new List<Class1>(); This sentance want to create an instant of IList<Class1> but implement by List<T>,
        Although implement by List but iList1 will just use IList<Class1> defined methods.   
        IList<Class1> iList1 =new List<Class1>(); 只是想创建一个基于接口IList<Class1>的对象的实例，只是这个接口是由List<T>实现的。所以它只是希望使用到IList<T>接口规定的功能而已。
    */
}