using System;
using System.IO;
using System.Threading.Tasks;
using System.ServiceModel;
using ArrayStore.Proxy;

namespace sorter
{
    public class SortArray : ArrayStore.Proxy.IArrayStoreCallback 
    {
        ArrayType array_type;
        int key;
        
        public SortArray(ArrayType array_type)
        {
            this.array_type = array_type;   
            ArrayStoreClient array_store_client = new ArrayStoreClient(new InstanceContext(this));
            key = array_store_client.Subscribe(array_type);
        }

        public void Save(int[] data)
        {
            using (StreamWriter writetext = new StreamWriter("EvenArrays.txt"))
            {
                writetext.WriteLine(data.Length + ":");
                for (int i = 0; i < data.Length; i++)
                {
                    writetext.Write(data[i]);
                    writetext.Write(" ");
                }
                writetext.WriteLine();
            }
            Console.WriteLine("I've saved it, trust me");
        }
    }

    class Store
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from Callback");
            SortArray array_odd = new SortArray(ArrayType.Odd);
            SortArray array_even = new SortArray(ArrayType.Even);
            Console.ReadLine();
       }
    }
}
