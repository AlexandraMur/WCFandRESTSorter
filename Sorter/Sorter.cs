using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using Ninject.Extensions.Xml;
using Ninject.Extensions.Xml.Processors;
using isorter;

namespace sorter
{
    public class Sorter : ISorter
    {
        int subscribersCount;
        private Dictionary<int, Notify> oddObservers;
        private Dictionary<int, Notify> evenObservers;
        private List<int[]> oddMessages;
        private List<int[]> evenMessages;
        private isorter.ISorter sorter;

        public Sorter()
        {
            subscribersCount = 0;            
            oddObservers = new Dictionary<int, Notify>();
            evenObservers = new Dictionary<int, Notify>();

            oddMessages = new List<int[]>();
            evenMessages = new List<int[]>();

            try
            {
                string[] type_of_sorter = System.IO.File.ReadAllLines(@"Sorter2.txt");
                var kernel = new Ninject.StandardKernel();
                kernel.Load(type_of_sorter[0]);
                sorter = kernel.Get<isorter.ISorter>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error from Sorter.cs");
                Console.ReadLine();
            }

        }

        private void SaveData(ArrayType type, int[] data) 
        {
            if (type == ArrayType.Even)
            {
                evenMessages.Add(data);
            }

            oddMessages.Add(data);
        }

        private string GetArrayAsString(int[] data)
        {
            string ret = "{";
            int i = 0;
            for (; i < data.Length - 1; i++)
            {
                ret = ret + data[i] + ", ";
            }
            ret = ret + data[i] + "}";
            return ret;
        }

        private List<int[]> GetMessages(ArrayType arrayType)
        {
            if (arrayType.Equals(ArrayType.Odd))
            {
                return oddMessages;
            }
            return evenMessages;
        }

        private void NotifyObservers(ArrayType arrayType)
        {
            Dictionary<int, Notify> arrayObservers = new Dictionary<int, Notify>();
            if (arrayType == ArrayType.Even)
            {
                arrayObservers = evenObservers;
            }
            else
            {
                return;
                //arrayObservers = oddObservers;
            }

            if (arrayObservers.Count == 0)
            {
                return;
            }

            lock (arrayObservers)
            {
                List<int[]> messages = GetMessages(arrayType);
                lock (messages)
                {
                    foreach (KeyValuePair<int, Notify> observer in arrayObservers)
                    {
                        foreach (int[] message in messages)
                        {
                            observer.Value(message);
                        }
                    }
                    messages.Clear();
                }
            }                                                                                                                  
        }

        private ArrayType GetArrayType(int[] data)
        {
            if (data.Count() % 2 == 0)
            {
                return ArrayType.Even;
            }
            return ArrayType.Odd;
        }

        public int[] Sort(int[] data)
        {
            ArrayType arrayType = GetArrayType(data);
            Console.WriteLine(arrayType);
            int[] sorted_array = sorter.Sort(data);
            SaveData(arrayType, sorted_array);
            NotifyObservers(arrayType);
            return sorted_array;
        }

        public int AddSubscriber(Notify observer, ArrayType target)
        {
            Dictionary<int, Notify> arrayObservers = new Dictionary<int, Notify>();

            if (target == ArrayType.Even)
            {
                arrayObservers = evenObservers;
            }
            else 
            {
                arrayObservers = oddObservers;
            }

            lock (arrayObservers)
            {
                subscribersCount++;
                arrayObservers.Add(subscribersCount, observer);
                Console.WriteLine("Observer " + subscribersCount + "(" + target + ") was connected");
            }
            return subscribersCount;
        }

        public void DeleteSubscriber(int key)
        {
            if (evenObservers.ContainsKey(key))
            {
                lock (evenObservers)
                {
                    evenObservers.Remove(key);
                }
            }
            if (oddObservers.ContainsKey(key))
            {
                lock (oddObservers)
                {
                    oddObservers.Remove(key);
                }
            }

            Console.WriteLine("Observer " + key + " was disconnected");
        }
    }
}
