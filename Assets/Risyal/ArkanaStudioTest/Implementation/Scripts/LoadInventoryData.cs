using Assets.Risyal.ArkanaStudioTest.Core.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.SaveSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.FactorySystem;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts
{
    /// <summary>
    /// Untuk memuat gacha data.
    /// </summary>
    public class LoadInventoryData : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Menangani inventory yang dimiliki oleh player.
        /// </summary>
        private IInventory _inventory = null;

        /// <summary>
        /// Menangani pembuatan save data.
        /// </summary>
        private IFactory<ISaveData> _saveDataFactory = null;

        #endregion

        #region Mono

        private async void Awake()
        {
            _saveDataFactory = Resources.Load<SaveDataFactory>("So/Factory/SaveDataFactory");
            _inventory = GetComponent<IInventory>();

            var inventorySaveData = _saveDataFactory.Create("Inventory");

            await inventorySaveData.Load();
            inventorySaveData.Apply(_inventory);
        }

        #endregion
    }
}