namespace Assets.Risyal.ArkanaStudioTest.Core.FiniteStateMachine
{
    /// <summary>
    /// Menangani finite state machine yang ada pada suatu object.
    /// </summary>
    public interface IFsm
    {
        /// <summary>
        /// State yang dimiliki oleh object pada saat ini.
        /// </summary>
        IState CurrentState { get; }

        /// <summary>
        /// Untuk mengganti state.
        /// </summary>
        /// <param name="id">
        /// Id dari state yang diganti.
        /// </param>
        void ChangeState(string id);
    }
}