using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CodeSampleModalLayer
{
    [Serializable]
    public class ItemIcon
    {
        public Utilities.ItemType itemName;
        public Sprite iconSprite;
    }

    [CreateAssetMenu(fileName = "AppData", menuName = "ScriptableObjects/AppData", order = 1)]
    public class AppData : ScriptableObject
    {
        [Header("ItemIcons")]
        [Space(5)]
        [SerializeField]
        private ItemIcon[] itemIcons = default;

        [Header("JSON Files")]
        [SerializeField]
        private TextAsset itemJSONFile = default;

        public TextAsset ItemJSONFile { get { return itemJSONFile; } }

        public Sprite GetItemIconByItemType(Utilities.ItemType type)
        {
            foreach (ItemIcon i in itemIcons)
            {
                if (i.itemName.Equals(type))
                {
                    return i.iconSprite;
                }
            }
            // Item not found in the list
            Debug.LogError($"AppData.cs GetItemIconByItemName() :: Item of type {type} not found in ItemIcons list.");
            return null;
        }
    }
}