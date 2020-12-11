using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using OOP_Lab_3.Base;
using OOP_Lab_3.Models;

namespace OOP_Lab_3.Storage.StorageManagers
{
    public class UserStorageManager : GenericStorageManagerBase<User>
    {
        private static readonly object Padlock = new object();
        private static UserStorageManager _instance;

        public int Counter { get; set; }

        protected override void UpdateStorageState()
        {
            Counter++;
            Storage.SaveStorageStateToOptions();
        }

        public static UserStorageManager Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ??= new UserStorageManager();
                }
            }
        }

        private UserStorageManager()
        {
            FileName = "users.dat";
            BinaryFormatter = new BinaryFormatter();
            CreateFileIfNotExist();
        }

        public override User GetItemById(int id)
        {
            return GetItemsList().FirstOrDefault(item => item.Id == id);
        }

        public override bool DoesItemExists(List<User> itemsList, int id)
        {
            return itemsList.Exists(x => x.Id == id);
        }

        public override List<User> FilterOutById(List<User> itemsList, int id)
        {
            return itemsList
                .Where(item => item.Id != id)
                .ToList();
        }
    }
}