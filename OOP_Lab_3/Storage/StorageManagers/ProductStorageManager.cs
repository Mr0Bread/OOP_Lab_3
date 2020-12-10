using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using OOP_Lab_3.Base;
using OOP_Lab_3.Models;

namespace OOP_Lab_3.Storage.StorageManagers
{
    public class ProductStorageManager : GenericStorageManagerBase<Product>
    {
        private static readonly object Padlock = new object();
        private static ProductStorageManager _instance;
        public int Counter { get; set; }

        public static ProductStorageManager Instance  
        {  
            get  
            {  
                lock (Padlock)
                {
                    return _instance ??= new ProductStorageManager();
                }  
            }  
        }

        public override Product GetItemById(int id)
        {
            return GetItemsList().FirstOrDefault(item => item.Id == id);
        }

        public override bool DoesItemExists(List<Product> itemsList, int id)
        {
            return itemsList.Exists(x => x.Id == id);
        }

        public override List<Product> FilterOutById(List<Product> itemsList, int id)
        {
            return itemsList
                .Where(item => item.Id != id)
                .ToList();
        }

        public new void AddItemToList(Product product)
        {
            product.Id = Instance.Counter;
            base.AddItemToList(product);
        }
        
        protected override void UpdateStorageState()
        {
            Counter++;
            Storage.SaveStorageStateToOptions();
        }
        
        private ProductStorageManager()
        {
            FileName = "products.dat";
            BinaryFormatter = new BinaryFormatter();
            CreateFileIfNotExist();
        }
    }
}