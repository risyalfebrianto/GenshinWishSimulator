using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.ObjectPooling;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.ObjectPooling;
using System.Collections;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.InventorySystem
{
    /// <summary>
    /// Implementasi IItemCard.
    /// </summary>
    public class ItemCard : PooledObject, IItemCard
    {
        #region IItemCard

        [field: SerializeField]
        public string Id { get; set; } = string.Empty;

        [field: SerializeField]
        public ItemType ItemType { get; set; } = default;

        #endregion
    }
}