using System.ServiceModel;

namespace sorter
{
    [ServiceContract(SessionMode = SessionMode.Required, 
                CallbackContract = typeof(IArrayStoreCallback))]
    public interface IArrayStore
    {
        [OperationContract]
        int Subscribe(ArrayType type);
    }

    public interface IArrayStoreCallback
    {
        [OperationContract(IsOneWay = true)]
        void Save(int[] data);
    }
}
