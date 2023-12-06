using Assets.Risyal.ArkanaStudioTest.Core.PoolSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Template;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool
{
    /// <summary>
    /// Implementasi IPool<CharacterData>.
    /// </summary>
    [CreateAssetMenu(fileName = "BannerPool", menuName = "Risyal/So/Pool/BannerPool")]
    public class BannerPool : ScriptableObject, IPool<BannerData>
    {
        #region IPool<Characters>

        [field: SerializeField]
        public List<BannerData> Pool { get; private set; } = new List<BannerData>();

        public BannerData Get(string id)
        {
            return Pool.First(x => x.id == id);
        }

        #endregion
    }

    /// <summary>
    /// Data yang dimiliki oleh banner.
    /// </summary>
    [Serializable]
    public struct BannerData
    {
        /// <summary>
        /// Id dari karakter.
        /// </summary>
        public string id;

        /// <summary>
        /// Gambar yang di tampilkan di UI.
        /// </summary>
        public Sprite sprite;
    }
}