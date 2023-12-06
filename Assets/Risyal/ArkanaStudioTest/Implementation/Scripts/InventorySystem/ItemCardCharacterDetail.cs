using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.PoolSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Global;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.InventorySystem
{
    /// <summary>
    /// Implementasi IItemCardDetail.
    /// </summary>
    public class ItemCardCharacterDetail : MonoBehaviour, IItemCardDetail
    {
        #region Variable

        /// <summary>
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPool<CharacterData> _characterPool = null;

        /// <summary>
        /// Text yang menampilkan nama dari character.
        /// </summary>
        private TMP_Text _nameText = null;

        /// <summary>
        /// Text yang menampilkan rarity dari character.
        /// </summary>
        private TMP_Text _rarityText = null;

        /// <summary>
        /// Text yang menampilkan health dari character.
        /// </summary>
        private TMP_Text _healthText = null;

        /// <summary>
        /// Text yang menampilkan attack dari character.
        /// </summary>
        private TMP_Text _attackText = null;

        /// <summary>
        /// Text yang menampilkan defence dari character.
        /// </summary>
        private TMP_Text _defenceText = null;

        #endregion

        #region IItemCardDetail

        public ItemType ItemType => ItemType.Character;

        public void ShowDetail(string id)
        {
            var data = _characterPool.Get(id);

            _nameText.text = data.name.ConvertUpperCaseToSpace();
            _rarityText.text = data.template.Rarity.ToString().ConvertUpperCaseToSpace();
            _healthText.text = data.template.Hp.ToString();
            _attackText.text = data.template.Attack.ToString();
            _defenceText.text= data.template.Defence.ToString();

            gameObject.SetActive(true);
        }

        #endregion

        #region Mono

        private void Awake()
        {
            _characterPool = Resources.Load<CharacterPool>("So/Pool/CharacterPool");
            _nameText = transform.Find("NameText").GetComponent<TMP_Text>();
            _rarityText = transform.Find("StatsGroup/RarityStat/ValueText").GetComponent<TMP_Text>();
            _healthText = transform.Find("StatsGroup/HpStat/ValueText").GetComponent<TMP_Text>();
            _attackText = transform.Find("StatsGroup/AttackStat/ValueText").GetComponent<TMP_Text>();
            _defenceText = transform.Find("StatsGroup/DefenceStat/ValueText").GetComponent<TMP_Text>();
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}