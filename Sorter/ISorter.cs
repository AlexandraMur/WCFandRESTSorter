namespace sorter
{
    public delegate void Notify(int[] data);

    public interface ISorter
    {
        int[] Sort(int[] data);
        int AddSubscriber(Notify obserer, ArrayType target);
        void DeleteSubscriber(int key);
    }
}
