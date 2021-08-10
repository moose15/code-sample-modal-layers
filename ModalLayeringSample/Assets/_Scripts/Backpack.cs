using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSampleModalLayer
{
    public class Backpack
    {
        private const int maxTotalItems = 10;
        private List<Item> itemList = new List<Item>();
        // public List<Item> ItemList { get { return itemList; } }

        public int MaxTotalItems { get { return maxTotalItems; } }
        public List<Item> ItemList { get { return itemList; } }

        public void AddItem(Item item)
        {
            item.IsItemInBackPack = true;
            itemList.Add(item);
            Debug.Log($"Item is added to the backpack. Count: {GetTotalItemsInBackpack()}");
        }

        public void RemoveItemById(string id)
        {
            foreach (Item i in itemList)
            {
                if (i.id.Equals(id))
                {
                    itemList.Remove(i);
                    return;
                }
            }
        }

        public int GetTotalItemsInBackpack()
        {
            return itemList.Count;
        }
        public bool IsBackpackEmpty()
        {
            return (GetTotalItemsInBackpack() == 0);
        }

        public bool IsBackpackFull()
        {
            return (GetTotalItemsInBackpack() >= maxTotalItems);
        }
    }
}