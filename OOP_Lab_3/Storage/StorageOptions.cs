using System;

namespace OOP_Lab_3.Storage
{
    [Serializable]
    public class StorageOptions
    {
        public int CustomersCounterState;
        public int OrdersCounterState;
        public int ProductsCounterState;
        public int ShipmentsCounterState;
        
        private static readonly object Padlock = new object();
        private static StorageOptions _instance;

        public int Counter { get; set; }

        public static StorageOptions Instance  
        {  
            get  
            {  
                lock (Padlock)
                {
                    return _instance ??= new StorageOptions();
                }  
            }  
        }
        
        private StorageOptions()
        {}
    }
}