using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Core.InventorySystem
{
    /// <summary>
    /// Menangani card item pada game.
    /// </summary>
    public interface IItemCard
    {
        /// <summary>
        /// Id dari item yang ditampilkan pada scene.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Tipe item yang dimiliki.
        /// </summary>
        ItemType ItemType { get; set; }
    }
}