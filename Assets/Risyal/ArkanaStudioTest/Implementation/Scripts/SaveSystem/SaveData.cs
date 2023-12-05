using Assets.Risyal.ArkanaStudioTest.Core.SaveSystem;
using Cysharp.Threading.Tasks;

namespace Assets.KUMAGEMA.InventoryItem.Implementation.Scripts.SaveSystem
{
    /// <summary>
    /// Implementasi ISaveData.
    /// </summary>
    public abstract class SaveData : ISaveData
    {
        #region Constructor

        public SaveData(string id, ISaveManager saveManager)
        {
            Id = id;
            SaveManager = saveManager;
        }

        #endregion

        #region ISaveData

        public string Id { get; protected set; } = string.Empty;

        public ISaveManager SaveManager { get; protected set; } = null;

        public abstract UniTask Save(params object[] parameters);

        public abstract UniTask Load(params object[] parameters);

        public abstract void Apply(object source);

        public abstract UniTask Delete();

        #endregion
    }
}