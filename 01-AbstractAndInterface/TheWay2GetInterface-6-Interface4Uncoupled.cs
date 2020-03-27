using System;

/*
 * Use interface to uncoupled 
 */
namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * change phone at here, don't change Person, that called "Uncoupled"
             */
            var user=new Person(new Huawei());
            user.HandlePhone();
        }
    }

    /*
     * Person class was closed, change phone just in Main()
     */
    class Person
    {
        private IMobilePhone _iMobilePhone;

        public Person(IMobilePhone imobilephone)
        {
            _iMobilePhone = imobilephone;
        }
        
        public void HandlePhone()
        {
            _iMobilePhone.Dial();
            _iMobilePhone.HangUp();
            _iMobilePhone.PickUp();
            _iMobilePhone.SMSIn();
            _iMobilePhone.SMSOut();
        }
    }

    interface IMobilePhone
    {
        void Dial();
        void HangUp();
        void PickUp();
        void SMSOut();
        void SMSIn();
    }

    class Huawei : IMobilePhone
    {
        public void Dial()
        {
            Console.WriteLine("Output: Huawei Dial...");
        }

        public void HangUp()
        {
            Console.WriteLine("Output: Huawei HangUp");
        }

        public void PickUp()
        {
            Console.WriteLine("Output: Huawei Pickup");
        }

        public void SMSOut()
        {
            Console.WriteLine("Output: Huawei SMS out");
        }

        public void SMSIn()
        {
            Console.WriteLine("Output: Huawei SMS in");
        }
    }

    class Apple : IMobilePhone
    {
        public void Dial()
        {
            Console.WriteLine("Output: Apple Dial...");
        }

        public void HangUp()
        {
            Console.WriteLine("Output: Apple HangUp");
        }

        public void PickUp()
        {
            Console.WriteLine("Output: Apple Pickup");
        }

        public void SMSOut()
        {
            Console.WriteLine("Output: Apple SMS out");
        }

        public void SMSIn()
        {
            Console.WriteLine("Output: Apple SMS in");
        }
    }
}