using Assets.Risyal.ArkanaStudioTest.Core.ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.ObjectPooling
{
    /// <summary>
    /// Implementasi IObjectPoolingManager.
    /// </summary>
    [CreateAssetMenu(fileName = "ObjectPoolingManager", menuName = "Risyal/So/ObjectPooling/ObjectPoolingManager")]
    public class ObjectPoolingManager : ScriptableObject, IObjectPoolingManager
    {
        #region Variable

        /// <summary>
        /// Object pooling yang di manage.
        /// </summary>
        private List<IPooledObject> _pooledObject = new List<IPooledObject>();

        /// <summary>
        /// Prefab dari pooled object yang dijadikan sebagai acuan untuk pembuatan object.
        /// </summary>
        [SerializeField]
        private PooledObject prefab = null;

        #endregion

        #region IObjectPoolingManager

        public IPooledObject GetFreeItem(params object[] parameters)
        {
            foreach (var obj in _pooledObject)
            {
                if (!obj.IsActive)
                {
                    return obj;
                }
            }

            var newPooledObject = Instantiate(prefab);

            _pooledObject.Add(newPooledObject);

            return newPooledObject;
        }

        #endregion
    }
}