using System;
using System.ServiceModel;
using WCFArrayGenerator.Reciever;

namespace sorter
{
    class ArrayGenerator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SOAP-CLIENT");
            Random rng = new Random();
            int SIZE = rng.Next(2,20);

            int[] unsorted_array = new int[SIZE];
            Console.Write("Array size ");
            Console.WriteLine(SIZE);

            Console.WriteLine("Unsorted:");
            for (int i = 0; i < SIZE; i++)
            {
                unsorted_array[i] = rng.Next(100);
                Console.Write(unsorted_array[i]);
                Console.Write(" ");
            }

            Console.WriteLine();
            RecieverClient reciever_client = new RecieverClient();
            try 
            {
                reciever_client.Recieve(unsorted_array);
                int[] sorted_array = reciever_client.GetSortedArray();

                Console.WriteLine("Sorted:");
                for (int i = 0; i < sorted_array.Length; i++)
                {
                    Console.Write(sorted_array[i]);
                    Console.Write(" ");
                }
                Console.WriteLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error from ArrayGenerator.cs");
            }
        }
    }
}
