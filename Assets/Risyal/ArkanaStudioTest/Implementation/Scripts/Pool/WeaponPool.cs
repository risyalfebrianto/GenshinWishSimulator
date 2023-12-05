using Assets.Risyal.ArkanaStudioTest.Core.PoolSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool
{
    /// <summary>
    /// Implementasi IPool<WeaponPool>.
    /// </summary>
    [CreateAssetMenu(fileName = "WeaponPool", menuName = "Risyal/So/Pool/WeaponPool")]
    public class WeaponPool : ScriptableObject, IPool<WeaponData>
    {
        #region IPool<Characters>

        [field: SerializeField]
        public List<WeaponData> Pool { get; private set; } = new List<WeaponData>();

        public WeaponData Get(string id)
        {
            return Pool.First(x => x.id == id);
        }

        #endregion
    }

    /// <summary>
    /// Data yang dimiliki oleh senjata.
    /// </summary>
    [Serializable]
    public struct WeaponData
    {
        /// <summary>
        /// Id dari senjata.
        /// </summary>
        public string id;

        /// <summary>
        /// Nama dari senjata.
        /// </summary>
        public string name;

        /// <summary>
        /// Gambar yang di tampilkan di UI.
        /// </summary>
        public Sprite sprite;

        /// <summary>
        /// Template stats yang dimiliki oleh senjata.
        /// </summary>
        public WeaponTemplate template;
    }
}