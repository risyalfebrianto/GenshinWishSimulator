namespace Assets.Risyal.ArkanaStudioTest.Core.InventorySystem
{
    /// <summary>
    /// Menangani item yang ada pada dalam game.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Id dari item.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Nama yang dimiliki item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Deskripsi yang dimiliki item.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Tipe yang dimiliki item.
        /// </summary>
        ItemType ItemType { get; }

        /// <summary>
        /// Jumlah item yang dimiliki.
        /// </summary>
        int Amount { get; set; }
    }

    /// <summary>
    /// Tipe item yang tersedia pada game.
    /// </summary>
    public enum ItemType
    {
        Character,
        Weapon
    }
}