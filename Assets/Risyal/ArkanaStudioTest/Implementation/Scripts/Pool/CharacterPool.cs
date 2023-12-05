using Assets.Risyal.ArkanaStudioTest.Core.PoolSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool
{
    /// <summary>
    /// Implementasi IPool<CharacterData>.
    /// </summary>
    [CreateAssetMenu(fileName = "CharacterPool", menuName = "Risyal/So/Pool/CharacterPool")]
    public class CharacterPool : ScriptableObject, IPool<CharacterData>
    {
        #region IPool<Characters>

        [field: SerializeField]
        public List<CharacterData> Pool { get; private set; } = new List<CharacterData>();

        public CharacterData Get(string id)
        {
            return Pool.First(x => x.id == id);
        }

        #endregion
    }

    /// <summary>
    /// Data yang dimiliki oleh karakter.
    /// </summary>
    [Serializable]
    public struct CharacterData
    {
        /// <summary>
        /// Id dari karakter.
        /// </summary>
        public string id;

        /// <summary>
        /// Nama dari karakter.
        /// </summary>
        public string name;

        /// <summary>
        /// Gambar yang di tampilkan di UI.
        /// </summary>
        public Sprite sprite;

        /// <summary>
        /// Template stats yang dimiliki oleh karakter.
        /// </summary>
        public CharacterTemplate template;
    }
}