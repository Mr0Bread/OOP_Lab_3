﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using OOP_Lab_3.Base;
using OOP_Lab_3.Models;

namespace OOP_Lab_3.Storage.StorageManagers
{
    public class ShipmentStorageManager : GenericStorageManagerBase<Shipment>
    {
        private static readonly object Padlock = new object();
        private static ShipmentStorageManager _instance;
        public int Counter { get; set; }

        public static ShipmentStorageManager Instance  
        {  
            get  
            {  
                lock (Padlock)
                {
                    return _instance ??= new ShipmentStorageManager();
                }  
            }  
        }
        
        protected override void UpdateStorageState()
        {
            Counter++;
            Storage.SaveStorageStateToOptions();
        }

        public override Shipment GetItemById(int id)
        {
            return GetItemsList().FirstOrDefault(item => item.Id == id);
        }

        public override bool DoesItemExists(List<Shipment> itemsList, int id)
        {
            return itemsList.Exists(x => x.Id == id);
        }

        public override List<Shipment> FilterOutById(List<Shipment> itemsList, int id)
        {
            return itemsList
                .Where(item => item.Id != id)
                .ToList();
        }

        public new void AddItemToList(Shipment shipment)
        {
            shipment.Id = Instance.Counter;
            base.AddItemToList(shipment);
        }
        
        private ShipmentStorageManager()
        {
            FileName = "shipments.dat";
            BinaryFormatter = new BinaryFormatter();
            CreateFileIfNotExist();
        }
    }
}