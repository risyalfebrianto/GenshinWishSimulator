namespace Assets.Risyal.ArkanaStudioTest.Core.Template
{
    /// <summary>
    /// Menangani template stat yang dimiliki oleh senjata.
    /// </summary>
    public interface IWeaponTemplate
    {
        /// <summary>
        /// Tingkat kelangkaan senjata. 
        /// </summary>
        WeaponRarity Rarity { get; }

        /// <summary>
        /// Tipe dari senjata. 
        /// </summary>
        WeaponType WeaponType { get; }

        /// <summary>
        /// Banyaknya point serangan yang dimiliki senjata.
        /// </summary>
        float BaseAttack { get; }

        /// <summary>
        /// Banyaknya point health yang dimiliki senjata.
        /// </summary>
        string SpecialEffect { get; }
    }

    /// <summary>
    /// Jenis kelangkaan senjata yang tersedia.
    /// </summary>
    public enum WeaponRarity
    {
        Normal,
        Rare,
        SuperRare
    }

    /// <summary>
    /// Jenis kelangkaan senjata yang tersedia.
    /// </summary>
    public enum WeaponType
    {
        Sword,
        Catalyst,
        Bow
    }
}