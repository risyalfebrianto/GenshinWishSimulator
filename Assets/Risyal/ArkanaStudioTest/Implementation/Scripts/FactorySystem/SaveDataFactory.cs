using Assets.Risyal.ArkanaStudioTest.Core.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.SaveSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.SaveSystem;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.FactorySystem
{
    /// <summary>
    /// Implementasi IFactory<ISaveData>.
    /// </summary>
    [CreateAssetMenu(fileName = "SaveDataFactory", menuName = "Risyal/So/Factory/SaveDataFactory")]
    public class SaveDataFactory : ScriptableObject, IFactory<ISaveData>
    {
        #region Variable

        /// <summary>
        /// Menangani proses penyimpanan, pemuatan dan penghapusan data.
        /// </summary>
        [SerializeField]
        private SaveManager saveManager = null;

        #endregion

        #region IFactory<ISaveData>

        [field: SerializeField]
        public string Id { get; private set; } = string.Empty;

        public ISaveData Create(params object[] parameters)
        {
            var id = (string)parameters[0];

            switch (id)
            {
                case "Inventory":

                    return new InventorySaveData("InventorySaveData", saveManager);

                case "Pity":

                    return new PitySaveData((string)parameters[1], saveManager);

                case "PullHistory":

                    return new PullHistorySaveData((string)parameters[1], saveManager);
            }

            return null;
        }

        #endregion
    }
}