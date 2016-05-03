using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace sorter
{
   
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Reciever : IReciever
    {
        private int count;
        private int[] sorted_array;

        private Task Sort(int[] data)
        {
            return Task.Run(() =>
            {
                ISorter sorter = Proxy.GetSorter();
                sorted_array = sorter.Sort(data);
            });
        }

        public Reciever()
        {
            count = 0;
        }

        public async void Recieve(int[] data)
        {
            Console.WriteLine("Receiver.Sort: " + ++count);
            Sort(data);
        }

        public int[] GetSortedArray()
        {
            return sorted_array;
        }
    }
}
