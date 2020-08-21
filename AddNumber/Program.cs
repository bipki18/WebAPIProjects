using System;

namespace AddNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            int result = Product.AddNumber(10, 20);

            Console.WriteLine("the sum is"+ result);

            Console.ReadLine();
        }
    }



    public class Product
    {
        private Product()
        {
        }
        public static int AddNumber(int i ,int j)
        {
            return i + j;
        }

    }


}
