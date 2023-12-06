using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using System;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.InventorySystem
{
    /// <summary>
    /// Implementasi IItem.
    /// </summary>
    [Serializable]
    public class Item : IItem
    {
        #region Constructor

        /// <summary>
        /// Constructor untuk item.
        /// </summary>
        /// <param name="id">
        /// Id dari item.
        /// </param>
        /// <param name="name">
        /// Nama dari item.
        /// </param>
        /// <param name="description">
        /// Deskripsi yang dimiliki item.
        /// </param>
        /// <param name="itemType">
        /// Tipe yang dimiliki item.
        /// </param>
        /// <param name="amount">
        /// Jumlah item.
        /// </param>
        public Item(string id, string name, string description, ItemType itemType, int amount)
        {
            Id = id;
            Name = name;
            Description = description;
            ItemType = itemType;
            Amount = amount;
        }

        #endregion

        #region IItem

        [field: SerializeField]
        public string Id { get; private set; } = string.Empty;

        [field: SerializeField]
        public string Name { get; private set; } = string.Empty;

        [field: SerializeField]
        public string Description { get; private set; } = string.Empty;

        [field: SerializeField]
        public ItemType ItemType { get; private set; } = default;

        [field: SerializeField]
        public int Amount { get; set; } = 0;

        #endregion
    }
}