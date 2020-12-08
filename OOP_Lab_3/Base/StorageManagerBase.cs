using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOP_Lab_3.Base
{
    public abstract class StorageManagerBase
    {
        protected string FileName;
        protected BinaryFormatter BinaryFormatter;
        protected Stream Stream;
        
        public List<ModelBase> GetItemsList()
        {
            if (new FileInfo(FileName).Length == 0)
            {
                return new List<ModelBase>();
            }

            Stream = GetExistingFileStreamToRead();
            var itemsList = (List<ModelBase>) BinaryFormatter.Deserialize(Stream);
            Stream.Close();
            Stream = null;
            return itemsList;
        }

        public ModelBase GetItemById(int id)
        {
            return GetItemsList().FirstOrDefault(item => item.Id == id);
        }

        public bool RemoveItemFromList(int id)
        {
            if (new FileInfo(FileName).Length == 0)
            {
                return false;
            }

            Stream = GetExistingFileStreamToRead();

            var itemsList = (List<ModelBase>) BinaryFormatter.Deserialize(Stream);

            if (!itemsList.Exists(x => x.Id == id))
            {
                return false;
            }

            itemsList = itemsList
                .Where(item => item.Id != id)
                .ToList();
            Stream.Close();
            Stream = GetFileStreamToWrite();
            BinaryFormatter.Serialize(Stream, itemsList);
            Stream.Close();
            Stream = null;
            return true;
        }

        public void AddItemToList(ModelBase item)
        {
            if (new FileInfo(FileName).Length == 0)
            {
                Stream = GetFileStreamToWrite();
                BinaryFormatter.Serialize(Stream, new List<ModelBase> {item});
                Stream.Close();
                Stream = null;
                UpdateStorageState();
                return;
            }
            
            Stream = GetExistingFileStreamToRead();
            var customerList = (List<ModelBase>) BinaryFormatter.Deserialize(Stream);
            customerList.Add(item);
            Stream.Close();
            Stream = GetFileStreamToWrite();
            BinaryFormatter.Serialize(Stream, customerList);
            Stream.Close();
            Stream = null;
            UpdateStorageState();
        }

        protected FileStream GetExistingFileStreamToRead()
        {
            return new FileStream(FileName, FileMode.Open, FileAccess.Read);
        }

        protected FileStream GetFileStreamToWrite()
        {
            return new FileStream(FileName, FileMode.Open, FileAccess.Write);
        }

        protected void CreateFileIfNotExist()
        {
            if (!File.Exists(FileName))
            {
                File.Create(FileName).Close();
            }
        }

        protected abstract void UpdateStorageState();
    }
}