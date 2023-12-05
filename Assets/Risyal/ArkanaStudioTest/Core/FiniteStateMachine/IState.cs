namespace Assets.Risyal.ArkanaStudioTest.Core.FiniteStateMachine
{
    /// <summary>
    /// Menangani kondisi dari suatu object saat ini.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Id yang dimiliki oleh state.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Method yang dipanggil ketika state di inisialisasi.
        /// </summary>
        void InitializeState();

        /// <summary>
        /// Method yang dipanggil ketika masuk state.
        /// </summary>
        void EnterState();

        /// <summary>
        /// Method yang dipanggil ketika keluar state.
        /// </summary>
        void ExitState();
    }
}