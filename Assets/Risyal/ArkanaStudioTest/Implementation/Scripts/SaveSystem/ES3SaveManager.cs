using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.SaveSystem;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.KUMAGEMA.InventoryItem.Implementation.Scripts.SaveSystem
{
    /// <summary>
    /// Implementasi ISaveManager memakai ES3.
    /// </summary>
    [CreateAssetMenu(menuName = "Risyal/So/SaveSystem/ES3SaveManager", fileName = "ES3SaveManager")]
    public class ES3SaveManager : SaveManager
    {
        #region ISaveManager

        public override async UniTask Save(string id, params object[] parameters)
        {
            var data = JsonConvert.SerializeObject(parameters[0]);

            ES3.Save(id, data);
        }

        public override async UniTask<T> Load<T>(string id, params object[] parameters)
        {
            if (!ES3.KeyExists(id))
            {
                Debug.LogWarning("Key with id " + id + " not exist!");

                return default;
            }

            var data = ES3.Load(id);

            return JsonConvert.DeserializeObject<T>((string)data);
        }

        public override void Delete(string id)
        {
            ES3.DeleteFile(id);
        }

        #endregion
    }
}