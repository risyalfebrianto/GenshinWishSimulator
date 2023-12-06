using Assets.Risyal.ArkanaStudioTest.Core.ContainerSystem;
using Assets.Risyal.ArkanaStudioTest.Core.GachaSystem;
using Assets.Risyal.ArkanaStudioTest.Core.PoolSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Container;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Global;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.GachaSystem
{
    /// <summary>
    /// Untuk menunjukkan hasil dari gacha.
    /// </summary>
    public class ShowGachaResult : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Semua pull yang ada pada game.
        /// </summary>
        private IPull[] _pulls = null;

        /// <summary>
        /// History dari pull yang dilakukan oleh player.
        /// </summary>
        private IListContainer<string>[] _pullHistories = null;

        /// <summary>
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPool<CharacterData> _characterPool = null;

        /// <summary>
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPool<WeaponData> _weaponPool = null;

        /// <summary>
        /// Menunjukkan gambar dari item.
        /// </summary>
        private Image _image = null;

        /// <summary>
        /// Nama dari item.
        /// </summary>
        private TMP_Text _name = null;

        /// <summary>
        /// Rarity dari item.
        /// </summary>
        private TMP_Text _rarity = null;

        /// <summary>
        /// Tombol yang digunakan untuk 
        /// </summary>
        private Button _nextButton = null;

        /// <summary>
        /// Untuk pengecekan hasil gacha.
        /// </summary>
        private int _currentCount = 0;

        /// <summary>
        /// Jenis pull yang di pilih player.
        /// </summary>
        private Pulltype _pullType = default;

        #endregion

        #region Main

        /// <summary>
        /// Untuk menampilkan history.
        /// </summary>
        /// <param name="amount">
        /// Jumlah dari gacha yang dipull.
        /// </param>
        private void DoShowHistory(Pulltype pullType, int amount)
        {
            var pullHistory = _pullHistories.FirstOrDefault(x => x.Id.Contains(pullType.ToString()));

            _currentCount = amount;

            _pullType = pullType;

            NextResult();

            gameObject.SetActive(true);
        }

        /// <summary>
        /// Untuk menunjukkan hasil gacha selanjutnya.
        /// </summary>
        private void NextResult()
        {
            if (_currentCount <= 0)
            {
                gameObject.SetActive(false);

                return;
            }

            _currentCount--;

            var pullHistory = _pullHistories.FirstOrDefault(x => x.Id.Contains(_pullType.ToString()));

            var index = pullHistory.Content.Count - 1 - _currentCount;

            if (_characterPool.Pool.Any(x => x.id == pullHistory.Content[index]))
            {
                var data = _characterPool.Get(pullHistory.Content[index]);

                _image.sprite = data.sprite;
                _name.text = data.name;
                _rarity.text = data.template.Rarity.ToString().ConvertUpperCaseToSpace();
            }
            else
            {
                var data = _weaponPool.Get(pullHistory.Content[index]);

                _image.sprite = data.sprite;
                _name.text = data.name;
                _rarity.text = data.template.Rarity.ToString().ConvertUpperCaseToSpace();
            }
        }

        #endregion

        #region Mono

        private void Awake()
        {
            _pulls = FindObjectsOfType<MonoBehaviour>().OfType<IPull>().ToArray();
            _pullHistories = FindObjectsOfType<MonoBehaviour>().OfType<IListContainer<string>>().ToArray();
            _characterPool = Resources.Load<CharacterPool>("So/Pool/CharacterPool");
            _weaponPool = Resources.Load<WeaponPool>("So/Pool/WeaponPool");
            _image = transform.Find("Content/Sprite").GetComponent<Image>();
            _name = transform.Find("Content/Name").GetComponent<TMP_Text>();
            _rarity = transform.Find("Content/Rarity").GetComponent<TMP_Text>();
            _nextButton = GetComponentInChildren<Button>();

            foreach (var pull in _pulls)
            {
                pull.OnPullFinished += DoShowHistory;
            }

            _nextButton.onClick.AddListener(NextResult);
        }

        private void OnDestroy()
        {
            foreach (var pull in _pulls)
            {
                pull.OnPullFinished -= DoShowHistory;
            }

            _nextButton.onClick.RemoveListener(NextResult);
        }

        #endregion
    }
}