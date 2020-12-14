using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using OOP_Lab_3.Base;
using OOP_Lab_3.Models;

namespace OOP_Lab_3.Storage.StorageManagers
{
    public sealed class CustomerStorageManager : GenericStorageManagerBase<Customer>
    {
        private static readonly object Padlock = new object();
        private static CustomerStorageManager _instance;
        
        public int Counter { get; set; }
        protected override void UpdateStorageState()
        {
            Counter++;
            Storage.SaveStorageStateToOptions();
        }

        public static CustomerStorageManager Instance  
        {  
            get  
            {  
                lock (Padlock)
                {
                    return _instance ??= new CustomerStorageManager();
                }  
            }  
        }

        public new void AddItemToList(Customer customer)
        {
            customer.Id = Instance.Counter;
            base.AddItemToList(customer);
        }
        
        private CustomerStorageManager()
        {
            FileName = "customers.dat";
            BinaryFormatter = new BinaryFormatter();
            CreateFileIfNotExist();
        }
    }
}