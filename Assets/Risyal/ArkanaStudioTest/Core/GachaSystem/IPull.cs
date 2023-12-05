using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Core.GachaSystem
{
    /// <summary>
    /// Menangani penarikan pada gacha.
    /// </summary>
    public interface IPull
    {
        /// <summary>
        /// Jenis pull yang dilakukan.
        /// </summary>
        Pulltype Pulltype { get; }

        /// <summary>
        /// Untuk melakukan penarikan gacha.
        /// </summary>
        /// <param name="amount">
        /// Jumlah gacha yang ditarik.
        /// </param>
        void DoPull(int amount);

        /// <summary>
        /// Event yang dipanggil ketika pull telah selesai.
        /// </summary>
        Action<int> OnPullFinished { get; set; }
    }

    /// <summary>
    /// Jenis pull yang dilakukan.
    /// </summary>
    public enum Pulltype
    {
        Character,
        Weapon
    }
}