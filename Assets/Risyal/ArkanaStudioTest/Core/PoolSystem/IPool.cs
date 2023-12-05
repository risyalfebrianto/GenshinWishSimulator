using System.Collections.Generic;

namespace Assets.Risyal.ArkanaStudioTest.Core.PoolSystem
{
    /// <summary>
    /// Menangani pool yang digunakan untuk menyimpan kumpulan dari object.
    /// </summary>
    public interface IPool<T>
    {
        /// <summary>
        /// Kumpulan dari object yang disimpan pada pool.
        /// </summary>
        List<T> Pool { get; }

        /// <summary>
        /// Untuk mendapatkan object yang ada didalam pool.
        /// </summary>
        /// <param name="id">
        /// Id dari object yang ada didalam pool.
        /// </param>
        /// <returns>
        /// Mengembalikan nilai berupa T.
        /// </returns>
        T Get(string id);
    }
}