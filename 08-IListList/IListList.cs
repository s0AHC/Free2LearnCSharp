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
            // 千万要注意：等式的右边是List<Users>,而不是 IList<Users>,
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
}