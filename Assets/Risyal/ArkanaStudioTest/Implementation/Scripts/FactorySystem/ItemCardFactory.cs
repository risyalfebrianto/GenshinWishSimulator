using Assets.Risyal.ArkanaStudioTest.Core.FactorySystem;
using Assets.Risyal.ArkanaStudioTest.Core.InventorySystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.ObjectPooling;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.FactorySystem
{
    /// <summary>
    /// Menangani pembuatan dari item card.
    /// </summary>
    [CreateAssetMenu(fileName = "ItemCardFactory", menuName = "Risyal/So/Factory/ItemCardFactory")]
    public class ItemCardFactory : ScriptableObject, IFactory<IItemCard>
    {
        #region Variable

        /// <summary>
        /// Menangani object pooling pada suatu object.
        /// </summary>
        [SerializeField]
        private ObjectPoolingManager poolingManager = null;

        #endregion

        #region IFactory<ItemCard>

        [field: SerializeField]
        public string Id { get; private set; } = string.Empty;

        public IItemCard Create(params object[] parameters)
        {
            var obj = poolingManager.GetFreeItem();

            var objMono = (MonoBehaviour)obj;

            objMono.transform.SetParent((Transform)parameters[0]);
            objMono.transform.localScale = Vector3.one;

            return (IItemCard)obj;
        }

        #endregion
    }
}