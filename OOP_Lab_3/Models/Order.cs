using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using OOP_Lab_3.Annotations;
using OOP_Lab_3.Base;

namespace OOP_Lab_3.Models
{
    [Serializable]
    public class Order : ModelBase
    {
        private int _incrementId;
        private int _customerId;
        private List<(int ProductId, int Quantity)> _orderList;
        private float _ordersTotal;
        private Shipment _orderShipment;

        public int IncrementId
        {
            get => _incrementId;
            set
            {
                _incrementId = value;
                OnPropertyChanged(nameof(IncrementId));
            }
        }

        public int CustomerId
        {
            get => _customerId;
            set
            {
                _customerId = value;
                OnPropertyChanged(nameof(CustomerId));
            }
        }

        public List<(int ProductId, int Quantity)> OrderList
        {
            get => _orderList;
            set
            {
                _orderList = value;
                OnPropertyChanged(nameof(OrderList));
            }
        }

        public float OrdersTotal
        {
            get => _ordersTotal;
            set
            {
                _ordersTotal = value;
                OnPropertyChanged(nameof(OrdersTotal));
            }
        }

        public Shipment OrderShipment
        {
            get => _orderShipment;
            set
            {
                _orderShipment = value;
                OnPropertyChanged(nameof(OrderShipment));
            }
        }
    }
}