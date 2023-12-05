using Assets.Risyal.ArkanaStudioTest.Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Data
{
    /// <summary>
    /// Implementasi IPityData.
    /// </summary>
    public class PityData : MonoBehaviour, IPityData
    {
        #region IPityData

        [field: SerializeField]
        public string Id { get; private set; } = string.Empty;

        [field: SerializeField]
        public int DefaultRarePity { get; private set; } = 0;

        [field: SerializeField]
        public int RarePity { get; private set; } = 0;

        [field: SerializeField]
        public int DefaultSuperRarePity { get; private set; } = 0;

        [field: SerializeField]
        public int SuperRarePity { get; private set; } = 0;

        public void SetRarePity(int value)
        {
            RarePity = value;

            OnDataChanged?.Invoke();
        }

        public void SetSuperRarePity(int value)
        {
            SuperRarePity = value;

            OnDataChanged?.Invoke();
        }

        public Action OnDataChanged { get; set; }= null;

        #endregion
    }
}