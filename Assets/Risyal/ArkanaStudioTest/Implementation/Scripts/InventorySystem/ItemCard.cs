using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.ObjectPooling;
using System.Collections;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.InventorySystem
{
    /// <summary>
    /// Implementasi IItemCard.
    /// </summary>
    public class ItemCard : MonoBehaviour, IItemCard, IPooledObject
    {
        #region IItemCard

        [field: SerializeField]
        public string Id { get; set; } = string.Empty;

        [field: SerializeField]
        public ItemType ItemType { get; set; } = default;

        #endregion

        #region IPooledObject

        public bool IsActive => gameObject.activeInHierarchy;

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}