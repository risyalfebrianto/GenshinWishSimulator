using Assets.Risyal.ArkanaStudioTest.Core.ContainerSystem;
using Assets.Risyal.ArkanaStudioTest.Core.Data;
using Assets.Risyal.ArkanaStudioTest.Core.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.GachaSystem;
using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.SaveSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.FactorySystem;
using System.Linq;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts
{
    /// <summary>
    /// Untuk save data ketika pull telah selesai.
    /// </summary>
    public class SaveDataAfterPull : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Menangani penarikan gacha.
        /// </summary>
        private IPull _pull = null;

        /// <summary>
        /// Menangani pembuatan save data.
        /// </summary>
        private IFactory<ISaveData> _saveDataFactory = null;

        /// <summary>
        /// Menyimpan sejarah pull player.
        /// </summary>
        private IListContainer<string> _pullHistory = null;

        /// <summary>
        /// Menangani inventory yang dimiliki oleh player.
        /// </summary>
        private IInventory _inventory = null;

        /// <summary>
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPityData _pityData = null;

        /// <summary>
        /// Save data untuk inventory.
        /// </summary>
        private ISaveData _inventorySaveData = null;

        /// <summary>
        /// Save data untuk inventory.
        /// </summary>
        private ISaveData _pullHistorySaveData = null;

        /// <summary>
        /// Save data untuk inventory.
        /// </summary>
        private ISaveData _pitySaveData = null;

        #endregion

        #region Main

        /// <summary>
        /// Untuk save data.
        /// </summary>
        /// <param name="pullType">
        /// Tipe pull yang dilakukan.
        /// </param>
        /// <param name="amount">
        /// Banyaknya item yang di pull pada gacha.
        /// </param>
        private async void DoSaveData(Pulltype pullType, int amount)
        {
            await _inventorySaveData.Save(_inventory);
            await _pullHistorySaveData.Save(_pullHistory);
            await _pitySaveData.Save(_pityData);
        }

        #endregion

        #region Mono

        private void Awake()
        {
            _pull = GetComponent<IPull>();
            _saveDataFactory = Resources.Load<SaveDataFactory>("So/Factory/SaveDataFactory");
            _pityData = GetComponent<IPityData>();
            _pullHistory = GetComponent<IListContainer<string>>();
            _inventory = FindObjectsOfType<MonoBehaviour>().OfType<IInventory>().FirstOrDefault();

            _inventorySaveData = _saveDataFactory.Create("Inventory");
            _pullHistorySaveData = _saveDataFactory.Create("PullHistory", _pullHistory.Id);
            _pitySaveData = _saveDataFactory.Create("Pity", _pityData.Id);

            _pull.OnPullFinished += DoSaveData;
        }

        private void OnDestroy()
        {
            _pull.OnPullFinished -= DoSaveData;
        }

        #endregion
    }
}