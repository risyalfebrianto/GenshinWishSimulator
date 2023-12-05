
using Assets.KUMAGEMA.InventoryItem.Implementation.Scripts.SaveSystem;
using Assets.Risyal.ArkanaStudioTest.Core.Data;
using Assets.Risyal.ArkanaStudioTest.Core.SaveSystem;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.SaveSystem
{
    /// <summary>
    /// Untuk menyimpan data pity.
    /// </summary>
    public class PitySaveData : SaveData
    {
        #region Variable

        /// <summary>
        /// Data pity yang disave.
        /// </summary>
        private SavePityData _savedPityData = null;

        #endregion

        #region Constructor

        public PitySaveData(string id, ISaveManager saveManager) : base(id, saveManager)
        {
            _savedPityData = new();
        }

        #endregion

        #region SaveData

        public override async UniTask Save(params object[] parameters)
        {
            var pityData = (IPityData)parameters[0];

            _savedPityData.rarePity = pityData.RarePity;
            _savedPityData.superRarePity = pityData.SuperRarePity;

            await SaveManager.Save(Id, _savedPityData);
        }

        public override async UniTask Load(params object[] parameters)
        {
            _savedPityData = await SaveManager.Load<SavePityData>(Id);
        }

        public override void Apply(object source)
        {
            var pityData = (IPityData)source;

            if (_savedPityData != null)
            {
                pityData.SetRarePity(_savedPityData.rarePity);
                pityData.SetSuperRarePity(_savedPityData.superRarePity);
            }
        }

        public override async UniTask Delete()
        {
            SaveManager.Delete(Id);
        }

        #endregion
    }

    /// <summary>
    /// Data pity yang di simpan.
    /// </summary>
    [Serializable]
    public class SavePityData
    {
        /// <summary>
        /// Jumlah rare pity yang dimiliki player.
        /// </summary>
        public int rarePity;

        /// <summary>
        /// Jumlah super rare pity yang dimiliki player.
        /// </summary>
        public int superRarePity;
    }
}