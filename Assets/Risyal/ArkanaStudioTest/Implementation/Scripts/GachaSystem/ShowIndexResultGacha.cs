using Assets.Risyal.ArkanaStudioTest.Core.ContainerSystem;
using Assets.Risyal.ArkanaStudioTest.Core.GachaSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.GachaSystem
{
    /// <summary>
    /// Untuk menunjukkan total gacha yang dilakukan.
    /// </summary>
    public class ShowIndexResultGacha : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Tombol yang digunakan untuk 
        /// </summary>
        private Button _nextButton = null;

        /// <summary>
        /// Semua pull yang ada pada game.
        /// </summary>
        private IPull[] _pulls = null;

        /// <summary>
        /// Menampilkan text index saat ini.
        /// </summary>
        private TMP_Text _currentIndexText = null;

        /// <summary>
        /// Menampilkan text gacha maksimal yang dilakukan player.
        /// </summary>
        private TMP_Text _maxGachaText = null;

        /// <summary>
        /// Index gacha saat ini.
        /// </summary>
        private int _currentIndex = 1;

        #endregion

        #region Main

        /// <summary>
        /// Untuk menampilkan history.
        /// </summary>
        /// <param name="amount">
        /// Jumlah dari gacha yang dipull.
        /// </param>
        private void UpdateGachaCount(Pulltype pullType, int amount)
        {
            _currentIndex = 1;

            _maxGachaText.text = amount.ToString();
            _currentIndexText.text = _currentIndex.ToString();
        }

        /// <summary>
        /// Untuk menunjukkan hasil gacha selanjutnya.
        /// </summary>
        private void NextResult()
        {
            _currentIndex++;

            _currentIndexText.text = _currentIndex.ToString();
        }

        #endregion

        #region Mono

        private void Awake()
        {
            _pulls = FindObjectsOfType<MonoBehaviour>().OfType<IPull>().ToArray();
            _currentIndexText = transform.Find("CurrentCount").GetComponent<TMP_Text>();
            _maxGachaText = transform.Find("MaxCount").GetComponent<TMP_Text>();
            _nextButton = transform.parent.GetComponentInChildren<Button>();

            foreach (var pull in _pulls)
            {
                pull.OnPullFinished += UpdateGachaCount;
            }

            _nextButton.onClick.AddListener(NextResult);
        }

        private void OnDestroy()
        {
            foreach (var pull in _pulls)
            {
                pull.OnPullFinished -= UpdateGachaCount;
            }

            _nextButton.onClick.RemoveListener(NextResult);
        }

        #endregion
    }
}