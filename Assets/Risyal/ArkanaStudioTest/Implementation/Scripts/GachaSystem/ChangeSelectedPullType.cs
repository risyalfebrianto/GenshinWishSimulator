using Assets.Risyal.ArkanaStudioTest.Core.GachaSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.GachaSystem
{
    /// <summary>
    /// Untuk mengganti tipe pull yang ingin dilakukan.
    /// </summary>
    public class ChangeSelectedPullType : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Tipe pull yang ingin dilakukan.
        /// </summary>
        [SerializeField]
        private Pulltype pullType = default;

        /// <summary>
        /// Tombol yang digunakan untuk melakukan pull.
        /// </summary>
        private Button _button = null;

        /// <summary>
        /// Tipe pull yang ingin dilakukan.
        /// </summary>
        private ICurrentPullType _pulltype = default;

        #endregion

        #region Mono

        private void Awake()
        {
            _pulltype = FindObjectsOfType<MonoBehaviour>().OfType<ICurrentPullType>().FirstOrDefault();
            _button = GetComponent<Button>();

            _button.onClick.AddListener(() => _pulltype.ChangePullType(pullType));
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        #endregion
    }
}