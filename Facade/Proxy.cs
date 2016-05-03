using Ninject;
using System;
using System.IO;

namespace sorter
{
    public class Proxy
    {
        private static object locker = new object();
        private static ISorter isorter = null;

        public static ISorter GetSorter()
        {
            lock (locker)
            {
                if (isorter == null)
                {
                    try
                    {
                        isorter = new sorter.Sorter();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Error from Proxy.cs");
                    }
                }

                return isorter;
            }
        }
    }
}
