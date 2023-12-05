using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using System;

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

        public string Id { get; private set; } = string.Empty;

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public ItemType ItemType { get; private set; } = default;

        public int Amount { get; set; } = 0;

        #endregion
    }
}