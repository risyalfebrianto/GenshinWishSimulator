namespace Assets.Risyal.ArkanaStudioTest.Core.InventorySystem
{
    /// <summary>
    /// Untuk menunjuukan detail dari kartu.
    /// </summary>
    public interface IItemCardDetail
    {
        /// <summary>
        /// Tipe item yang ditunjukkan detailnya.
        /// </summary>
        ItemType ItemType { get; }

        /// <summary>
        /// Untuk menunjukkan detail.
        /// </summary>
        /// <param name="id">
        /// Id dari item yang ingin ditunjukkan detailnya.
        /// </param>
        void ShowDetail(string id);
    }
}