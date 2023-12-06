using System;

namespace Assets.Risyal.ArkanaStudioTest.Core.Data
{
    /// <summary>
    /// Menangani data yang ada pada game.
    /// </summary>
    public interface IData
    {
        /// <summary>
        /// Id dari data.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Event yang dipanggil ketika data berubah nilainya.
        /// </summary>
        Action OnDataChanged { get; set; }
    }
}