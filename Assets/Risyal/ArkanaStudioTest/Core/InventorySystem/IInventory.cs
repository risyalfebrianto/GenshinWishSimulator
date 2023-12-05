using System;
using System.Collections.Generic;

namespace Assets.Risyal.ArkanaStudioTest.Core.InventorySystem
{
    /// <summary>
    /// Menangani inventory pada game.
    /// </summary>
    public interface IInventory
    {
        /// <summary>
        /// Id yang dimiliki inventory.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Slot maksimal yang bisa dimiliki oleh inventory.
        /// </summary>
        int MaxSlot { get; }

        /// <summary>
        /// Semua item yang ada pada inventory.
        /// </summary>
        List<IItem> Items { get; }

        /// <summary>
        /// Untuk mendapatkan item yang ada pada inventory.
        /// </summary>
        /// <param name="id">
        /// Id dari item yang ingin didapatkan.
        /// </param>
        /// <returns>
        /// Mengembalikan nilai berupa IItem.
        /// </returns>
        IItem Get(string id);

        /// <summary>
        /// Untuk menambah item kedalam inventory.
        /// </summary>
        /// <param name="item">
        /// Item yang ditambahkan.
        /// </param>
        /// <param name="amount">
        /// Jumlah dari item yang ditambahkan.
        /// </param>
        void AddItem(IItem item, int amount);

        /// <summary>
        /// Untuk menghilangkan item kedalam inventory.
        /// </summary>
        /// <param name="item">
        /// Item yang dihilangkan.
        /// </param>
        /// <param name="amount">
        /// Jumlah dari item yang dihilangkan.
        /// </param>
        void RemoveItem(IItem item, int amount);

        /// <summary>
        /// Untuk menghapus semua isi inventory.
        /// </summary>
        void Clear();

        /// <summary>
        /// Event yang dipanggil ketika item ditambahkan.
        /// </summary>
        Action<IItem> OnItemAdded { get; set; }

        /// <summary>
        /// Event yang dipanggil ketika item dihilangkan.
        /// </summary>
        Action<IItem> OnItemRemoved { get; set; }
    }
}