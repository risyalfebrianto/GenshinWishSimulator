namespace Assets.Risyal.ArkanaStudioTest.Core.ObjectPooling
{
    /// <summary>
    /// Object yang di pool.
    /// </summary>
    public interface IPooledObject
    {
        /// <summary>
        /// Id dari pooled object.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Indikasi apakah object aktif atau tidak.
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        /// Untuk mengaktifkan pooled object.
        /// </summary>
        void Activate();

        /// <summary>
        /// Untuk manon-aktifkan pooled object.
        /// </summary>
        void Deactivate();
    }
}