using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOP_Lab_3.Base
{
    public abstract class GenericStorageManagerBase<TModel>
    {
        protected string FileName;
        protected BinaryFormatter BinaryFormatter;
        protected Stream Stream;

        public List<TModel> GetItemsList()
        {
            if (new FileInfo(FileName).Length == 0)
            {
                return new List<TModel>();
            }

            Stream = GetExistingFileStreamToRead();
            var itemsList = (List<TModel>) BinaryFormatter.Deserialize(Stream);
            Stream.Close();
            Stream = null;
            return itemsList;
        }

        public abstract TModel GetItemById(int id);

        public abstract bool DoesItemExists(List<TModel> itemsList, int id);

        public abstract List<TModel> FilterOutById(List<TModel> itemsList, int id);

        public bool RemoveItemFromList(int id)
        {
            if (new FileInfo(FileName).Length == 0)
            {
                return false;
            }

            Stream = GetExistingFileStreamToRead();

            var itemsList = (List<TModel>) BinaryFormatter.Deserialize(Stream);

            if (!DoesItemExists(itemsList, id))
            {
                return false;
            }
            
            itemsList = FilterOutById(itemsList, id);
            Stream.Close();
            Stream = GetFileStreamToWrite();
            BinaryFormatter.Serialize(Stream, itemsList);
            Stream.Close();
            Stream = null;
            return true;
        }

        public void AddItemToList(TModel item)
        {
            if (new FileInfo(FileName).Length == 0)
            {
                Stream = GetFileStreamToWrite();
                BinaryFormatter.Serialize(Stream, new List<TModel> {item});
                Stream.Close();
                Stream = null;
                UpdateStorageState();
                return;
            }

            Stream = GetExistingFileStreamToRead();
            var customerList = (List<TModel>) BinaryFormatter.Deserialize(Stream);
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