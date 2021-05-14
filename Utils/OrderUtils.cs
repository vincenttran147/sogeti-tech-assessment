using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Models;

namespace Utils
{
    public static class OrderUtils
    {
        static readonly string filePath = @"data\orders.json";
        static bool UpdateFile(Action<List<Order>> operation)
        {
            try
            {
                // Read all json data to string
                string rawJsonString = File.ReadAllText(filePath);
                List<Order> orderList = JsonConvert.DeserializeObject<List<Order>>(rawJsonString);
                orderList = orderList == null ? new List<Order>() : orderList;
                operation(orderList);

                // Update json data string
                rawJsonString = JsonConvert.SerializeObject(orderList, Formatting.Indented);
                File.WriteAllText(filePath, rawJsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
        static bool ReadFile(Action<List<Order>> operation)
        {
            try
            {
                // Read all json data to string
                string rawJsonString = File.ReadAllText(filePath);
                List<Order> orderList = JsonConvert.DeserializeObject<List<Order>>(rawJsonString);
                operation(orderList);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool WriteOrder(Order order)
        {
            return UpdateFile((orderList) =>
            {
                orderList.Add(order);
            });
        }
        public static bool UpdateOrder(Order newOrder, Func<Order, bool> query)
        {
            return UpdateFile((orderList) =>
            {
                Order order = orderList.Find((order) => query(order));
                if (newOrder.orderName != null)
                {
                    order.orderName = newOrder.orderName;
                }
                if (newOrder.orderDescription != null)
                {
                    order.orderDescription = newOrder.orderDescription;
                }
            });
        }
        public static bool RemoveOrder(Func<Order, bool> query)
        {
            return UpdateFile((orderList) =>
            {
                Order order = orderList.Find((order) => query(order));
                orderList.Remove(order);
            });
        }
        public static List<Order> QueryOrder(Func<Order, bool> query)
        {
            List<Order> queryResult = new List<Order>();
            ReadFile((orderList) =>
            {
                queryResult.AddRange(orderList.Where((order) => query(order)).ToArray());
            });
            return queryResult;
        }
    }
}