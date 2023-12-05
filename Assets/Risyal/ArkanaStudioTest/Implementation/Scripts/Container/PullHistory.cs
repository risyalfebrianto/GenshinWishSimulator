using Assets.Risyal.ArkanaStudioTest.Core.ContainerSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Container
{
    /// <summary>
    /// Implementasi IListContainer<string>, untuk menyimpan history dari pull player.
    /// </summary>
    public class PullHistory : MonoBehaviour, IListContainer<string>
    {
        #region IDictionaryContainer<int>

        [field: SerializeField]
        public string Id { get; private set; } = string.Empty;

        [field: SerializeField]
        public List<string> Content { get; private set; } = new List<string>();

        public string Get(string id)
        {
            if (Content.Contains(id))
            {
                return Content.First(x => x == id);
            }

            Debug.LogWarning($"There is no content with id {id} in the container!");

            return string.Empty;
        }

        public void Add(string content)
        {
            Content.Add(content);

            OnContentChanged?.Invoke();
        }

        public void Remove(string id)
        {
            if (Content.Contains(id))
            {
                Content.Remove(id);

                OnContentChanged?.Invoke();
            }
        }

        public void Clear()
        {
            Content.Clear();

            OnContentChanged?.Invoke();
        }

        public Action OnContentChanged { get; set; } = null;

        #endregion
    }
}