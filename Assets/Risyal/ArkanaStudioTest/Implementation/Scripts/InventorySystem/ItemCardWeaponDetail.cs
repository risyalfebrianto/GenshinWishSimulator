using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.PoolSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Global;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool;
using TMPro;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.InventorySystem
{
    /// <summary>
    /// Implementasi IItemCardDetail.
    /// </summary>
    public class ItemCardWeaponDetail : MonoBehaviour, IItemCardDetail
    {
        #region Variable

        /// <summary>
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPool<WeaponData> _weaponPool = null;

        /// <summary>
        /// Text yang menampilkan nama dari weapon.
        /// </summary>
        private TMP_Text _nameText = null;

        /// <summary>
        /// Text yang menampilkan rarity dari weapon.
        /// </summary>
        private TMP_Text _rarityText = null;

        /// <summary>
        /// Text yang menampilkan attack dari weapon.
        /// </summary>
        private TMP_Text _attackText = null;

        /// <summary>
        /// Text yang menampilkan Special Effect dari weapon.
        /// </summary>
        private TMP_Text _specialEffectText = null;

        #endregion

        #region IItemCardDetail

        public ItemType ItemType => ItemType.Weapon;

        public void ShowDetail(string id)
        {
            var data = _weaponPool.Get(id);

            _nameText.text = data.name.ConvertUpperCaseToSpace();
            _rarityText.text = data.template.Rarity.ToString().ConvertUpperCaseToSpace();
            _attackText.text = data.template.BaseAttack.ToString();
            _specialEffectText.text = data.template.SpecialEffect;

            gameObject.SetActive(true);
        }

        #endregion

        #region Mono

        private void Awake()
        {
            _weaponPool = Resources.Load<WeaponPool>("So/Pool/WeaponPool");
            _nameText = transform.Find("NameText").GetComponent<TMP_Text>();
            _rarityText = transform.Find("StatsGroup/RarityStat/ValueText").GetComponent<TMP_Text>();
            _attackText = transform.Find("StatsGroup/AttackStat/ValueText").GetComponent<TMP_Text>();
            _specialEffectText = transform.Find("StatsGroup/SpecialEffect/ScrollView/Viewport/Content/ValueText").GetComponent<TMP_Text>();
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}