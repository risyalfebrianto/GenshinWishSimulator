using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.InventorySystem
{
    /// <summary>
    /// Implementasi IInventory untuk menyimpan item yang ada pada dalam game.
    /// </summary>
    public class PlayerInventory : MonoBehaviour, IInventory
    {
        #region IInventory

        public string Id { get; private set; } = string.Empty;

        public int MaxSlot { get; private set; } = 99;

        public List<IItem> Items { get; private set; } = new List<IItem>();

        public Action<IItem> OnItemAdded { get; set; } = null;

        public Action<IItem> OnItemRemoved { get; set; } = null;

        public IItem Get(string id)
        {
            return Items.First(x => x.Id == id);
        }

        public void AddItem(IItem item, int amount)
        {
            var itemOwned = Items.FirstOrDefault(x => x.Id == item.Id);

            if (itemOwned == null)
            {
                Items.Add(item);

                itemOwned = item;
            }

            itemOwned.Amount++;

            OnItemAdded?.Invoke(itemOwned);
        }

        public void RemoveItem(IItem item, int amount)
        {
            var itemOwned = Items.FirstOrDefault(x => x.Id == item.Id);

            if (itemOwned != null)
            {
                Items.Remove(itemOwned);

                OnItemRemoved?.Invoke(itemOwned);

                return;
            }

            Debug.LogWarning($"There is no item with id {item.Id} in inventory {Id}.");
        }

        public void Clear()
        {
            Items.Clear();
        }

        #endregion
    }
}