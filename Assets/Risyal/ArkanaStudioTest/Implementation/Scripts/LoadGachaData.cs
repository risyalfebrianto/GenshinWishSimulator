using Assets.KUMAGEMA.InventoryItem.Implementation.Scripts.SaveSystem;
using Assets.Risyal.ArkanaStudioTest.Core.ContainerSystem;
using Assets.Risyal.ArkanaStudioTest.Core.Data;
using Assets.Risyal.ArkanaStudioTest.Core.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.GachaSystem;
using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.SaveSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.SaveSystem;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts
{
    /// <summary>
    /// Untuk memuat gacha data.
    /// </summary>
    public class LoadGachaData : MonoBehaviour
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
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPityData _pityData = null;

        /// <summary>
        /// Save data untuk inventory.
        /// </summary>
        private ISaveData _pullHistorySaveData = null;

        /// <summary>
        /// Save data untuk inventory.
        /// </summary>
        private ISaveData _pitySaveData = null;

        #endregion

        #region Mono

        private async void Awake()
        {
            _saveDataFactory = Resources.Load<SaveDataFactory>("So/Factory/SaveDataFactory");
            _pityData = GetComponent<IPityData>();
            _pullHistory = GetComponent<IListContainer<string>>();

            _pullHistorySaveData = _saveDataFactory.Create("PullHistory", _pullHistory.Id);
            _pitySaveData = _saveDataFactory.Create("Pity", _pityData.Id);

            await _pullHistorySaveData.Load();
            _pullHistorySaveData.Apply(_pullHistory);

            await _pitySaveData.Load();
            _pitySaveData.Apply(_pityData);
        }

        #endregion
    }
}