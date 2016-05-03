using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace sorter
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Array : IArrayStore
    {
        IArrayStoreCallback callback = null;
        int key;

        public void Ring(int[] data)
        {
            Task.Run(() =>
            {
                try
                {
                    //if (data.Length % 2 == 0)
                    //{
                        callback.Save(data);
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Error from Array.cs");
                    Proxy.GetSorter().DeleteSubscriber(key);
                }
            });
        }

        public int Subscribe(ArrayType arrayType)
        {
            callback = OperationContext.Current.GetCallbackChannel<IArrayStoreCallback>();
            key = Proxy.GetSorter().AddSubscriber(Ring, arrayType);
            return key;
        }
    }
}
