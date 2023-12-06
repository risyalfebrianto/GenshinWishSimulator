using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Core.GachaSystem
{
    /// <summary>
    /// Menyimpan data tipe pull yang dipilih.
    /// </summary>
    public interface ICurrentPullType
    {
        /// <summary>
        /// Tipe pull yang dipilih.
        /// </summary>
        Pulltype CurrentPullType { get; }

        /// <summary>
        /// Untuk mengganti jenis pull yang ingin dilakukan.
        /// </summary>
        /// <param name="pullType">
        /// Tipe pull yang ingin dilakukan.
        /// </param>
        void ChangePullType(Pulltype pullType);

        /// <summary>
        /// Event yang dipanggil ketika pull type diganti.
        /// </summary>
        Action<Pulltype> OnPullTypeChanged { get; set; }
    }
}