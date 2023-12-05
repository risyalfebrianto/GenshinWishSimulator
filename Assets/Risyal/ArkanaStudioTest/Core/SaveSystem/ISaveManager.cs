using Cysharp.Threading.Tasks;

namespace Assets.Risyal.ArkanaStudioTest.Core.SaveSystem
{
    /// <summary>
    /// Menangani proses save, load dan delete data.
    /// </summary>
    public interface ISaveManager
    {
        /// <summary>
        /// Menangani proses penyimpanan data.
        /// </summary>
        /// <param name="Id">
        /// Id data yang ingin disave.
        /// </param>
        /// <param name="parameters">
        /// Parameter yang digunakan untuk proses save.
        /// </param>
        /// <returns>
        /// Mengembalikan nilai berupa UniTask.
        /// </returns>
        UniTask Save(string id, params object[] parameters);

        /// <summary>
        /// Menangani proses load data.
        /// </summary>
        /// <param name="Id">
        /// Id data yang ingin diload.
        /// </param>
        /// <param name="parameters">
        /// Parameter yang digunakan untuk proses load.
        /// </param>
        /// <returns>
        /// Mengembalikan nilai berupa T.
        /// </returns>
        UniTask<T> Load<T>(string id, params object[] parameters);

        /// <summary>
        /// Untuk menangani proses hapus data.
        /// </summary>
        /// <param name="id">
        /// Id data yang ingin dihapus.
        /// </param>
        void Delete(string id);
    }
}