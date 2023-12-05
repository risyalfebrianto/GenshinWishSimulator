using Cysharp.Threading.Tasks;

namespace Assets.Risyal.ArkanaStudioTest.Core.SaveSystem
{
    /// <summary>
    /// Menangani data yang akan di save, load atau delete.
    /// </summary>
    public interface ISaveData
    {
        /// <summary>
        /// Id dari save data.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Menangani proses save, load dan delete data.
        /// </summary>
        ISaveManager SaveManager { get; }

        /// <summary>
        /// Untuk save data.
        /// </summary>
        /// <param name="parameters">
        /// Parameter yang digunakna untuk save data.
        /// </param>
        /// <returns>
        /// Mengembalikan nilai berupa UniTask.
        /// </returns>
        UniTask Save(params object[] parameters);

        /// <summary>
        /// Untuk load data.
        /// </summary>
        /// <param name="parameters">
        /// Parameter yang digunakna untuk load data.
        /// </param>
        /// <returns>
        /// Mengembalikan nilai berupa UniTask.
        /// </returns>
        UniTask Load(params object[] parameters);

        /// <summary>
        /// Untuk apply hasil dari load ke data.
        /// </summary>
        /// <param name="source">
        /// Sumber yang akan di apply.
        /// </param>
        void Apply(object source);

        /// <summary>
        /// Untuk menghapus data.
        /// </summary>
        /// <returns>
        /// Mengembalikan nilai berupa UniTask.
        /// </returns>
        UniTask Delete();
    }
}