namespace Assets.Risyal.ArkanaStudioTest.Core.FactorySystem
{
    /// <summary>
    /// Menangani pembuatan suatu instansi.
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// Id dari factory.
        /// </summary>
        string Id { get; }
    }

    /// <summary>
    /// Menangani pembuatan suatu instansi.
    /// </summary>
    /// <typeparam name="T">
    /// Semua tipe object yang ada pada sistem.
    /// </typeparam>
    public interface IFactory<T> : IFactory
    {
        /// <summary>
        /// Untuk membuat object.
        /// </summary>
        /// <param name="parameters">
        /// Parameter yang digunakan untuk membuat suatu object.
        /// </param>
        /// <returns>
        /// Mengembalikan nilai berupa T.
        /// </returns>
        T Create(params object[] parameters);
    }
}