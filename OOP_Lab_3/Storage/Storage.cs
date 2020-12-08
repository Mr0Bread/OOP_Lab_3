using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using OOP_Lab_3.Storage.StorageManagers;

namespace OOP_Lab_3.Storage
{
    public static class Storage
    {
        private static readonly string FileName = "storage.dat";
        
        public static void InitializeStorage()
        {
            if (!File.Exists(FileName))
            {
                File.Create(FileName).Close();
            }

            if (new FileInfo(FileName).Length == 0)
            {
                OrderStorageManager.Instance.Counter = 0;
                CustomerStorageManager.Instance.Counter = 0;
                ProductStorageManager.Instance.Counter = 0;
                ShipmentStorageManager.Instance.Counter = 0;
                return;
            }

            var storageOptions = LoadStorageOptionsFile();
            
            OrderStorageManager.Instance.Counter = storageOptions.OrdersCounterState;
            CustomerStorageManager.Instance.Counter = storageOptions.CustomersCounterState;
            ProductStorageManager.Instance.Counter = storageOptions.ProductsCounterState;
            ShipmentStorageManager.Instance.Counter = storageOptions.ShipmentsCounterState;
        }

        public static void SaveStorageStateToOptions()
        {
            StorageOptions.Instance.OrdersCounterState = OrderStorageManager.Instance.Counter;
            StorageOptions.Instance.CustomersCounterState = CustomerStorageManager.Instance.Counter;
            StorageOptions.Instance.ProductsCounterState = ProductStorageManager.Instance.Counter;
            StorageOptions.Instance.ShipmentsCounterState = ShipmentStorageManager.Instance.Counter;

            UpdateStorageOptionsFile();
        }

        private static StorageOptions LoadStorageOptionsFile()
        {
            var storageOptionsFile = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            var binaryFormatter = new BinaryFormatter();
            var storageOptions = (StorageOptions) binaryFormatter.Deserialize(storageOptionsFile);
            storageOptionsFile.Close();
            return storageOptions;
        }

        private static void UpdateStorageOptionsFile()
        {
            var storageOptionsFile = new FileStream(FileName, FileMode.Open, FileAccess.Write);
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(storageOptionsFile, StorageOptions.Instance);
            storageOptionsFile.Close();
        }
    }
}