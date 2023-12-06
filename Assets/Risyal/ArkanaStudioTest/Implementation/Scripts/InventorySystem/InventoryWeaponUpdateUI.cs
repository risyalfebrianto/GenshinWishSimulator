using Assets.Risyal.ArkanaStudioTest.Core.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.ObjectPooling;
using Assets.Risyal.ArkanaStudioTest.Core.PoolSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.InventorySystem
{
    /// <summary>
    /// Untuk update user interface inventory.
    /// </summary>
    public class InventoryWeaponUpdateUI : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Data pity yang dimiliki oleh player.
        /// </summary>
        private IPool<WeaponData> _weaponPool = null;

        /// <summary>
        /// Menangani inventory yang dimiliki oleh player.
        /// </summary>
        private IInventory _inventory = null;

        /// <summary>
        /// Menangani pembuatan dari object pooling.
        /// </summary>
        private IFactory<IItemCard> _itemCardFactory = null;

        /// <summary>
        /// Card yang telah di instantiate di scene.
        /// </summary>
        private List<IItemCard> _cards = new List<IItemCard>();

        #endregion

        #region Mono

        private void Awake()
        {
            _weaponPool = Resources.Load<WeaponPool>("So/Pool/WeaponPool");
            _inventory = FindObjectsOfType<MonoBehaviour>().OfType<IInventory>().FirstOrDefault();
            _itemCardFactory = Resources.Load<ItemCardFactory>("So/Factory/ItemCardFactory");
        }

        private void OnEnable()
        {
            foreach (var item in _inventory.Items.Where(x => x.ItemType == ItemType.Weapon))
            {
                var card = _itemCardFactory.Create(transform);

                if (string.IsNullOrEmpty(item.Id))
                {
                    continue;
                }

                card.Id = item.Id;
                card.ItemType = item.ItemType;

                if (!_cards.Contains(card))
                {
                    _cards.Add(card);
                }

                ((IPooledObject)card).Activate();
            }
        }

        private void OnDisable()
        {
            foreach (var card in _cards)
            {
                ((IPooledObject)card).Deactivate();
            }
        }

        #endregion
    }
}