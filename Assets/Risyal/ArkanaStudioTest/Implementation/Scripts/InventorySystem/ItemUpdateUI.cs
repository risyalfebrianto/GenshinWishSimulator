using Assets.Risyal.ArkanaStudioTest.Core.Data;
using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.PoolSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.InventorySystem
{
    /// <summary>
    /// Untuk update sprite pada item.
    /// </summary>
    public class ItemUpdateUI : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Gambar yang ada pada GameObject.
        /// </summary>
        private Image _image = null;

        /// <summary>
        /// Menampilkan text jumlah item.
        /// </summary>
        private TMP_Text _countText = null;

        /// <summary>
        /// Item card yang ada pada GameObject.
        /// </summary>
        private IItemCard _itemCard = null;

        /// <summary>
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPool<CharacterData> _characterPool = null;

        /// <summary>
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPool<WeaponData> _weaponPool = null;

        /// <summary>
        /// Menangani inventory yang dimiliki oleh player.
        /// </summary>
        private IInventory _inventory = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _image = GetComponent<Image>();
            _countText = GetComponentInChildren<TMP_Text>();
            _itemCard = GetComponent<IItemCard>();
            _characterPool = Resources.Load<CharacterPool>("So/Pool/CharacterPool");
            _weaponPool = Resources.Load<WeaponPool>("So/Pool/WeaponPool");
            _inventory = FindObjectsOfType<MonoBehaviour>().OfType<IInventory>().FirstOrDefault();
        }

        private void OnEnable()
        {
            _image.sprite = _itemCard.ItemType == ItemType.Character ? 
                _characterPool.Get(_itemCard.Id).sprite : 
                _weaponPool.Get(_itemCard.Id).sprite;

            //Debug.Log(_inventory.Items.FirstOrDefault(x => x.Id == _itemCard.Id).Amount);
            //Debug.Log(_itemCard.Id);

            _countText.text = _inventory.Items.FirstOrDefault(x => x.Id == _itemCard.Id).Amount.ToString() + "x";
        }

        #endregion
    }
}