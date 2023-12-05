using Assets.Risyal.ArkanaStudioTest.Core.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.FactorySystem
{
    /// <summary>
    /// Menangani pembuatan dari item character.
    /// </summary>
    [CreateAssetMenu(fileName = "ItemCharacterFactory", menuName = "Risyal/So/Factory/ItemCharacterFactory")]
    public class ItemCharacterFactory : ScriptableObject, IFactory<IItem>
    {
        #region Variable

        /// <summary>
        /// Menyimpan semua data dari karakter.
        /// </summary>
        [SerializeField]
        private CharacterPool characterPool = null;

        #endregion

        #region IFactory<IItem>

        [field: SerializeField]
        public string Id { get; private set; } = string.Empty;

        public IItem Create(params object[] parameters)
        {
            var data = characterPool.Get((string)parameters[0]);

            return new Item(data.id, data.name, string.Empty, ItemType.Character, 1);
        }

        #endregion
    }
}