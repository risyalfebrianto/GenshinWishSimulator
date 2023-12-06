using Assets.Risyal.ArkanaStudioTest.Core.ContainerSystem;
using Assets.Risyal.ArkanaStudioTest.Core.GachaSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.GachaSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts
{
    /// <summary>
    /// Untuk menunjukkan total wish yang dilakukan oleh player.
    /// </summary>
    public class ShowTotalWish : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Pull type yang dimiliki saat ini.
        /// </summary>
        private ICurrentPullType _currentPullType = null;

        /// <summary>
        /// Semua pull history yang ada pada game.
        /// </summary>
        private IListContainer<string>[] _pullHistories = null;

        /// <summary>
        /// Total wish yang telah dilakukan oleh player.
        /// </summary>
        private TMP_Text _totalWishText = null;

        /// <summary>
        /// Semua pull yang ada pada game.
        /// </summary>
        private IPull[] _pulls = null;

        #endregion

        #region Main

        /// <summary>
        /// Untuk update total text.
        /// </summary>
        /// <param name="pulltype">
        /// Tipe pull yang dipilih player.
        /// </param>
        private void UpdateTotal(Pulltype pulltype)
        {
            _totalWishText.text = _pullHistories.FirstOrDefault(x => x.Id.Contains(pulltype.ToString())).Content.Count.ToString();
        }

        /// <summary>
        /// Untuk update total text.
        /// </summary>
        /// <param name="pulltype">
        /// Tipe pull yang dipilih player.
        /// </param>
        /// <param name="amount">
        /// Jumlah gacha yang dilakukan player.
        /// </param>
        private void UpdateTotal(Pulltype pulltype, int amount)
        {
            _totalWishText.text = _pullHistories.FirstOrDefault(x => x.Id.Contains(pulltype.ToString())).Content.Count.ToString();
        }

        #endregion

        #region Mono

        private void Awake()
        {
            _currentPullType = FindObjectsOfType<MonoBehaviour>().OfType<ICurrentPullType>().FirstOrDefault();
            _pullHistories = FindObjectsOfType<MonoBehaviour>().OfType<IListContainer<string>>().ToArray();
            _totalWishText = transform.Find("TotalWish").GetComponent<TMP_Text>();
            _pulls = FindObjectsOfType<MonoBehaviour>().OfType<IPull>().ToArray();

            _currentPullType.OnPullTypeChanged += UpdateTotal;

            foreach (var pull in _pulls)
            {
                pull.OnPullFinished += UpdateTotal;
            }
        }

        private void Start()
        {
            UpdateTotal(_currentPullType.CurrentPullType);
        }

        private void OnDestroy()
        {
            _currentPullType.OnPullTypeChanged -= UpdateTotal;

            foreach (var pull in _pulls)
            {
                pull.OnPullFinished -= UpdateTotal;
            }
        }

        #endregion
    }
}