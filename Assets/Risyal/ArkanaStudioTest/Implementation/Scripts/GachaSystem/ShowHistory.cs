using Assets.Risyal.ArkanaStudioTest.Core.ContainerSystem;
using Assets.Risyal.ArkanaStudioTest.Core.GachaSystem;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.GachaSystem
{
    /// <summary>
    /// Untuk menampilkan history pull;
    /// </summary>
    public class ShowHistory : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Pull tipe yang dipilih saat ini.
        /// </summary>
        private ICurrentPullType _currentPullType = null;

        /// <summary>
        /// History pull yang telah dilakukan oleh player.
        /// </summary>
        private IListContainer<string>[] _pullHistory = null;

        /// <summary>
        /// Menampilkan history.
        /// </summary>
        private TMP_Text _historyText = null;

        /// <summary>
        /// Tombol yang digunakan untuk menampilkan history.
        /// </summary>
        private Button _historyButton = null;

        #endregion

        #region Main

        /// <summary>
        /// Untuk menampilkan history.
        /// </summary>
        private void DoShowHistory()
        {
            _historyText.text = string.Empty;

            var pullHistory = _pullHistory.FirstOrDefault(x => x.Id.Contains(_currentPullType.CurrentPullType.ToString()));

            var count = 1;

            for (var i = pullHistory.Content.Count - 1; i >= 0; i--)
            {
                _historyText.text += $"{count}. {pullHistory.Content[i]} \n\n";
                count++;
            }

            transform.parent.parent.parent.gameObject.SetActive(true);
        }

        #endregion

        #region Mono

        private void Awake()
        {
            _currentPullType = FindObjectsOfType<MonoBehaviour>().OfType<ICurrentPullType>().FirstOrDefault();
            _pullHistory = FindObjectsOfType<MonoBehaviour>().OfType<IListContainer<string>>().ToArray();
            _historyText = GetComponent<TMP_Text>();
            _historyButton = FindObjectsOfType<Button>().FirstOrDefault(x => x.name == "HistoryButton");

            _historyButton.onClick.AddListener(DoShowHistory);
        }

        private void OnDestroy()
        {
            _historyButton.onClick.RemoveListener(DoShowHistory);
        }

        #endregion
    }
}