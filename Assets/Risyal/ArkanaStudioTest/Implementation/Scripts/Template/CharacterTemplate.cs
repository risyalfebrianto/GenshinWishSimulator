using Assets.Risyal.ArkanaStudioTest.Core.Template;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Template
{
    /// <summary>
    /// Implementasi ICharacterTemplate.
    /// </summary>
    [CreateAssetMenu (fileName = "CharacterTemplate", menuName = "Risyal/So/Template/CharacterTemplate")]
    public class CharacterTemplate : ScriptableObject, ICharacterTemplate
    {
        #region ICharacterTemplate

        [field: SerializeField]
        public CharacterRarity Rarity { get; private set; } = default;

        [field: SerializeField]
        public float Attack { get; private set; } = 0;

        [field: SerializeField]
        public float Hp { get; private set; } = 0;

        [field: SerializeField]
        public float Defence { get; private set; } = 0;

        #endregion
    }
}