using Assets.Risyal.ArkanaStudioTest.Core.GachaSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.GachaSystem
{
    /// <summary>
    /// Menangani tombol untuk melakukan pull.
    /// </summary>
    public class PullButton : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Jumlah pull yang ingin dilakukan.
        /// </summary>
        [SerializeField]
        private int pullAmount = 0;

        /// <summary>
        /// Tipe pull yang ingin dilakukan.
        /// </summary>
        private ICurrentPullType _pulltype = default;

        /// <summary>
        /// Menangani pull gacha.
        /// </summary>
        private IPull[] _pulls = null;

        /// <summary>
        /// Tombol yang digunakan untuk melakukan pull.
        /// </summary>
        private Button _button = null;

        #endregion

        #region Main

        /// <summary>
        /// Untuk melakukan pull.
        /// </summary>
        private void DoPull()
        {
            var pull = _pulls.FirstOrDefault(x => x.Pulltype == _pulltype.CurrentPullType);

            pull.DoPull(pullAmount);
        }

        #endregion

        #region Mono

        private void Awake()
        {
            _pulltype = FindObjectsOfType<MonoBehaviour>().OfType<ICurrentPullType>().FirstOrDefault();
            _pulls = FindObjectsOfType<MonoBehaviour>().OfType<IPull>().ToArray();
            _button = GetComponent<Button>();

            _button.onClick.AddListener(DoPull);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(DoPull);
        }

        #endregion
    }
}