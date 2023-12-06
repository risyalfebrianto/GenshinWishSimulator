namespace Assets.Risyal.ArkanaStudioTest.Core.ObjectPooling
{
    /// <summary>
    /// Menangani object pooling yang ada didalam game.
    /// </summary>
    public interface IObjectPoolingManager
    {
        /// <summary>
        /// Untuk mendapatkan object yang di pooling.
        /// </summary>
        /// <param name="parameters">
        /// Parameter yang digunakan untuk mendapatkan object.
        /// </param>
        /// <returns>
        /// Mengembalikan nilai berupa IPooledObject.
        /// </returns>
        IPooledObject GetFreeItem(params object[] parameters);
    }
}