using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.PoolSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.InventorySystem
{
    /// <summary>
    /// Untuk update user interface inventory.
    /// </summary>
    public class InventoryCharacterUpdateUI : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPool<CharacterData> _characterPool = null;

        #endregion
    }
}