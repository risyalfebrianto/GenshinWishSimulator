using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts
{
    /// <summary>
    /// Untuk menunjukkan detail dari card.
    /// </summary>
    public class ShowCardDetail : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Detail dari card.
        /// </summary>
        private IItemCardDetail[] _cardDetail = null;

        /// <summary>
        /// Item card yang ada pada GameObject.
        /// </summary>
        private IItemCard _itemCard = null;

        /// <summary>
        /// Tombol untuk menunjukkan detail.
        /// </summary>
        private Button _button = null;

        #endregion

        #region Main

        /// <summary>
        /// Untuk menunjukkan detail dari card.
        /// </summary>
        private void ShowDetail()
        {
            _cardDetail.First(x => x.ItemType == _itemCard.ItemType).ShowDetail(_itemCard.Id);
        }

        #endregion

        #region Mono

        private void Awake()
        {
            _itemCard = GetComponent<IItemCard>();
            _cardDetail = FindObjectsOfType<MonoBehaviour>(true).OfType<IItemCardDetail>().ToArray();
            _button = GetComponent<Button>();

            _button.onClick.AddListener(ShowDetail);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ShowDetail);
        }

        #endregion
    }
}