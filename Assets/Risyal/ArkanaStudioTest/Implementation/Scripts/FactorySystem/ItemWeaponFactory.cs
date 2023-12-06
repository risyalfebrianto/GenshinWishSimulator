using Assets.Risyal.ArkanaStudioTest.Core.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool;
using System.Collections;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.FactorySystem
{
    /// <summary>
    /// Menangani pembuatan dari item weapon.
    /// </summary>
    [CreateAssetMenu(fileName = "ItemWeaponFactory", menuName = "Risyal/So/Factory/ItemWeaponFactory")]
    public class ItemWeaponFactory : ScriptableObject, IFactory<IItem>
    {
        #region Variable

        /// <summary>
        /// Menyimpan semua data dari weapon.
        /// </summary>
        [SerializeField]
        private WeaponPool weaponPool = null;

        #endregion

        #region IFactory<IItem>

        [field: SerializeField]
        public string Id { get; private set; } = string.Empty;

        public IItem Create(params object[] parameters)
        {
            var data = weaponPool.Get((string)parameters[0]);

            return new Item(data.id, data.name, string.Empty, ItemType.Weapon, 0);
        }

        #endregion
    }
}