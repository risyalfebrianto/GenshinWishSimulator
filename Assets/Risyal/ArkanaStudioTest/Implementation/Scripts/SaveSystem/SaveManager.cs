using Assets.Risyal.ArkanaStudioTest.Core.SaveSystem;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.SaveSystem
{
    /// <summary>
    /// Implementasi ISaveManager.
    /// </summary>
    public abstract class SaveManager : ScriptableObject, ISaveManager
    {
        #region ISaveManager

        public abstract void Delete(string id);

        public abstract UniTask<T> Load<T>(string id, params object[] parameters);

        public abstract UniTask Save(string id, params object[] parameters);

        #endregion
    }
}