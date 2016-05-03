using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace sorter
{
    [ServiceContract]
    public interface IReciever
    {
        [OperationContract]
        void Recieve(int[] data);

        [OperationContract]
        int[] GetSortedArray();
    }
}
