using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Core.Data
{
    /// <summary>
    /// Menyimpan data pity yang digunakan untuk menghitung kemungkinan player mendapatkan rare atau super rare.
    /// </summary>
    public interface IPityData : IData
    {
        /// <summary>
        /// Nilai default rare pity yang dimiliki player.
        /// </summary>
        int DefaultRarePity { get; }

        /// <summary>
        /// Jumlah rare pity yang dimiliki player.
        /// </summary>
        int RarePity { get; }

        /// <summary>
        /// Nilai default super rare pity yang dimiliki player.
        /// </summary>
        int DefaultSuperRarePity { get; }

        /// <summary>
        /// Jumlah super rare pity yang dimiliki player.
        /// </summary>
        int SuperRarePity { get; }

        /// <summary>
        /// Untuk set nilai rare pity.
        /// </summary>
        /// <param name="value">
        /// Nilai yang di set.
        /// </param>
        void SetRarePity(int value);

        /// <summary>
        /// Untuk set nilai super rare pity.
        /// </summary>
        /// <param name="value">
        /// Nilai yang di set.
        /// </param>
        void SetSuperRarePity(int value);
    }
}