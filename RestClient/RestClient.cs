using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RestClient
{
    class RestClient
    {

        public class ArrayType
        { 
            public int[] data;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("WEB-CLIENT\n");
            ClientTest().Wait();
        }

        static async Task ClientTest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12345/");

            Random rng = new Random();
            int SIZE = rng.Next(2, 20);
            int[] unsorted_array = new int[SIZE];
            Console.Write("Array size ");
            Console.WriteLine(SIZE);

            Console.WriteLine("Unsorted:");
            for (int i = 0; i < SIZE; i++)
            {
                unsorted_array[i] = rng.Next(100, 1000);
                Console.Write(unsorted_array[i]);
                Console.Write(" ");
            }
            Console.WriteLine();

            ArrayType arg = new ArrayType();
            arg.data = unsorted_array;

            HttpResponseMessage response = await client.PostAsJsonAsync("api/Sample/ArraySort", arg);

            if (response.IsSuccessStatusCode)
            {
                ArrayType ret = response.Content.ReadAsAsync<ArrayType>().Result;
                Console.WriteLine("Sorted:");
                foreach (int i in ret.data)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
