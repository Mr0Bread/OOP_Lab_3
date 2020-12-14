using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using OOP_Lab_3.Models;
using OOP_Lab_3.Storage.StorageManagers;

namespace OOP_Lab_3.Storage
{
    public static class Storage
    {
        private static readonly string FileName = "storage.dat";
        private static readonly string InstancePropertyName = "Instance";
        private static readonly string StorageManagersNamespace = "OOP_Lab_3.Storage.StorageManagers";

        public static void InitializeStorage()
        {
            if (!File.Exists(FileName) || new FileInfo(FileName).Length == 0)
            {
                File.Create(FileName).Close();
                InitializeStorageOptions();
                SetAllCountersToValue(0);
                InitializeUserStorage();
                return;
            }

            SetAllCountersFromOptions(LoadStorageOptionsFile());

            if (UserStorageManager.Instance.Counter == 0)
            {
                InitializeUserStorage();
            }
        }

        private static void SetAllCountersFromOptions(StorageOptions storageOptions)
        {
            StorageOptions.Instance
                .StorageOptionsList = storageOptions.StorageOptionsList;
            
            StorageOptions.Instance
                .StorageOptionsList
                .ForEach(option =>
                {
                    var instance = GetStorageManagersTypes()
                        .FirstOrDefault(type => type.ToString() == option.StorageManagerTypeNamespace)
                        .GetProperty(InstancePropertyName)
                        .GetValue(null, null);

                    instance
                        .GetType()
                        .GetProperty("Counter")
                        .SetValue(instance, option.Counter);
                });
        }

        private static void InitializeStorageOptions()
        {
            GetStorageManagersTypes()
                .ForEach(type =>
                {
                    StorageOptions.Instance
                        .StorageOptionsList
                        .Add(new StorageOption{ Counter = 0, StorageManagerTypeNamespace = type.ToString() });
                });
        }

        public static void SaveStorageStateToOptions()
        {
            StorageOptions.Instance
                .StorageOptionsList
                .ForEach(option =>
                {
                    var storageManagerType = GetStorageManagersTypes()
                        .FirstOrDefault(x =>
                        {
                            var storageManagerNamespace = option.StorageManagerTypeNamespace;
                            return x.Name == Type.GetType(storageManagerNamespace).Name;
                        });
                    
                    var instance = storageManagerType
                        .GetProperty(InstancePropertyName)
                        .GetValue(null, null);

                    option.Counter = (int) instance
                        .GetType()
                        .GetProperty("Counter")
                        .GetValue(instance, null);
                });

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

        private static void InitializeUserStorage()
        {
            var user = new User {Login = "admin", Password = "admin"};
            UserStorageManager.Instance.AddItemToList(user);
        }

        private static void SetAllCountersToValue(int counter)
        {
            GetStorageManagersTypes()
                .ToList()
                .ForEach(type =>
                {
                    var instance = type
                        .GetProperty(InstancePropertyName)
                        .GetValue(null, null);
                    
                    instance
                        .GetType()
                        .GetProperty("Counter")
                        .SetValue(instance, counter);
                });
        }

        private static List<Type> GetStorageManagersTypes()
        {
            var storageManagers = from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.IsClass && t.Namespace == StorageManagersNamespace
                select t;
            return storageManagers.ToList();
        }

        private static void SetStorageManagerCounterToValue(int counter, Type storageManagerType)
        {
            GetStorageManagersTypes()
                .FirstOrDefault(x => x.Name == storageManagerType.Name)
                .GetProperty(InstancePropertyName)
                .SetValue(null, counter);
        }
    }
}