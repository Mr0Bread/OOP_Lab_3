using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using OOP_Lab_3.Base;
using OOP_Lab_3.Models;

namespace OOP_Lab_3.Storage.StorageManagers
{
    public class OrderStorageManager : GenericStorageManagerBase<Order>
    {
        private static readonly object Padlock = new object();
        private static OrderStorageManager _instance;
        public int Counter { get; set; }

        public static OrderStorageManager Instance  
        {  
            get  
            {  
                lock (Padlock)
                {
                    return _instance ??= new OrderStorageManager();
                }  
            }  
        }

        public override Order GetItemById(int id)
        {
            return GetItemsList().FirstOrDefault(item => item.Id == id);
        }

        public override bool DoesItemExists(List<Order> itemsList, int id)
        {
            return itemsList.Exists(x => x.Id == id);
        }

        public override List<Order> FilterOutById(List<Order> itemsList, int id)
        {
            return itemsList
                .Where(item => item.Id != id)
                .ToList();
        }

        public new void AddItemToList(Order order)
        {
            order.Id = Instance.Counter;
            base.AddItemToList(order);
        }
        
        protected override void UpdateStorageState()
        {
            Counter++;
            Storage.SaveStorageStateToOptions();
        }
        
        private OrderStorageManager()
        {
            FileName = "orders.dat";
            BinaryFormatter = new BinaryFormatter();
            CreateFileIfNotExist();
        }
    }
}