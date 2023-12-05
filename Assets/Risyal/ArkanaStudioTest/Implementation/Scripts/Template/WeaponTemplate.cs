using Assets.Risyal.ArkanaStudioTest.Core.Template;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Template
{
    /// <summary>
    /// Implementasi IWeaponTemplate.
    /// </summary>
    [CreateAssetMenu(fileName = "WeaponTemplate", menuName = "Risyal/So/Template/WeaponTemplate")]
    public class WeaponTemplate : ScriptableObject, IWeaponTemplate
    {
        #region IWeaponTemplate

        [field: SerializeField]
        public WeaponRarity Rarity { get;private set; } = default;

        [field: SerializeField]
        public WeaponType WeaponType { get; private set; } = default;

        [field: SerializeField]
        public float BaseAttack { get;private set; } = 0;

        [field: SerializeField, TextArea]
        public string SpecialEffect { get;private set; } = string.Empty;

        #endregion
    }
}