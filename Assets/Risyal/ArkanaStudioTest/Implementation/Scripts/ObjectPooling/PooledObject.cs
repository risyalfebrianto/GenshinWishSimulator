using Assets.Risyal.ArkanaStudioTest.Core.ObjectPooling;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.ObjectPooling
{
    /// <summary>
    /// Implementasi IPooledObject.
    /// </summary>
    public class PooledObject : MonoBehaviour, IPooledObject
    {
        #region IPooledObject

        [field: SerializeField]
        public string Id { get; set; } = string.Empty;

        public bool IsActive => gameObject.activeInHierarchy;

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}