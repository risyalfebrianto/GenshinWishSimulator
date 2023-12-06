using Assets.Risyal.ArkanaStudioTest.Core.GachaSystem;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.GachaSystem
{
    /// <summary>
    /// Implementasi ICurrentPullType.
    /// </summary>
    public class SelectedPullType : MonoBehaviour, ICurrentPullType
    {
        #region ISelectedPullType

        [ShowInInspector]
        public Pulltype CurrentPullType { get; private set; } = default;

        public void ChangePullType(Pulltype pullType)
        {
            CurrentPullType = pullType;

            OnPullTypeChanged?.Invoke(CurrentPullType);
        }

        public Action<Pulltype> OnPullTypeChanged { get; set; } = null;

        #endregion
    }
}