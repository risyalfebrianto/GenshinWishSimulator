namespace Assets.Risyal.ArkanaStudioTest.Core.Template
{
    /// <summary>
    /// Menangani template stat yang dimiliki oleh character.
    /// </summary>
    public interface ICharacterTemplate
    {
        /// <summary>
        /// Tingkat kelangkaan karakter. 
        /// </summary>
        CharacterRarity Rarity { get; }

        /// <summary>
        /// Banyaknya point serangan yang dimiliki karakter.
        /// </summary>
        float Attack { get; }

        /// <summary>
        /// Banyaknya point health yang dimiliki karakter.
        /// </summary>
        float Hp { get; }

        /// <summary>
        /// Banyaknya point pertahanan yang dimiliki karakter.
        /// </summary>
        float Defence { get; }
    }

    /// <summary>
    /// Jenis kelangkaan senjata yang tersedia.
    /// </summary>
    public enum CharacterRarity
    {
        Rare,
        SuperRare
    }
}