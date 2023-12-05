using Assets.KUMAGEMA.InventoryItem.Implementation.Scripts.SaveSystem;
using Assets.Risyal.ArkanaStudioTest.Core.ContainerSystem;
using Assets.Risyal.ArkanaStudioTest.Core.SaveSystem;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.SaveSystem
{
    /// <summary>
    /// Untuk menyimpan data pull history.
    /// </summary>
    public class PullHistorySaveData : SaveData
    {
        #region Variable

        /// <summary>
        /// Sejarah penarikan gacha. 
        /// </summary>
        private List<string> history = new List<string>();

        #endregion

        #region Constructor

        public PullHistorySaveData(string id, ISaveManager saveManager) : base(id, saveManager)
        {

        }

        #endregion

        #region SaveData

        public override async UniTask Save(params object[] parameters)
        {
            var pullHistory = (IListContainer<string>)parameters[0];

            await SaveManager.Save(Id, pullHistory.Content);
        }

        public override async UniTask Load(params object[] parameters)
        {
            history.Clear();

            var data = await SaveManager.Load<List<string>>(Id);

            if (data == null)
            {
                return;
            }

            foreach (var item in data)
            {
                history.Add(item);
            }
        }

        public override void Apply(object source)
        {
            var pullHistory = (IListContainer<string>)source;

            foreach (var item in history)
            {
                pullHistory.Add(item);
            }
        }

        public override async UniTask Delete()
        {
            SaveManager.Delete(Id);
        }

        #endregion
    }
}