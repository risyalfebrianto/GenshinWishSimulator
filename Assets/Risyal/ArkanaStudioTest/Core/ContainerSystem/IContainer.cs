using System;
using System.Collections.Generic;

namespace Assets.Risyal.ArkanaStudioTest.Core.ContainerSystem
{
    /// <summary>
    /// Menangani kontainer yang digunakan untuk menyimpan kumpulan object pada game.
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Id dari kontainer.
        /// </summary>
        string Id { get; }
    }

    /// <summary>
    /// Menangani kontainer yang digunakan untuk menyimpan kumpulan object pada game.
    /// </summary>
    /// <typeparam name="T">
    /// Semua tipe yang ada pada program.
    /// </typeparam>
    public interface IContainer<T> : IContainer
    {
        /// <summary>
        /// Untuk mendapatkan object yang disimpan pada kontainer.
        /// </summary>
        /// <param name="id">
        /// Id dari object yang ingin diambil dari kontainer.
        /// </param>
        /// <returns>
        /// Mengembalikan nilai berupa T.
        /// </returns>
        T Get(string id);

        /// <summary>
        /// Event yang dipanggil ketika isi dari kontainer berganti.
        /// </summary>
        Action OnContentChanged { get; set; }
    }

    /// <summary>
    /// Menangani kontainer berbentuk dictionary.
    /// </summary>
    /// <typeparam name="T">
    /// Semua tipe yang ada pada program.
    /// </typeparam>
    public interface IListContainer<T> : IContainer<T>
    {
        /// <summary>
        /// Menyimpan content pada kontainer yang berbentuk dictionary.
        /// </summary>
        List<T> Content { get; }

        /// <summary>
        /// Untuk menambah object ke container.
        /// </summary>
        /// <param name="content">
        /// Content dari container.
        /// </param>
        void Add(T content);

        /// <summary>
        /// Untuk menghilangkan object dari container.
        /// </summary>
        /// <param name="id">
        /// Id dari object yang dihilangkan.
        /// </param>
        void Remove(string id);

        /// <summary>
        /// Untuk mereset isi container.
        /// </summary>
        void Clear();
    }
}