using System;
using System.Collections.Generic;

namespace OOP_Lab_3.Storage
{
    [Serializable]
    public class StorageOptions
    {
        private List<StorageOption> _storageOptions;
        public List<StorageOption> StorageOptionsList
        {
            get
            {
                return _storageOptions ??= new List<StorageOption>();
            }
            set => _storageOptions = value;
        }
        
        private static readonly object Padlock = new object();
        private static StorageOptions _instance;

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