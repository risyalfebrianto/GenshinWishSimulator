namespace Assets.Risyal.ArkanaStudioTest.Core.Formula
{
    /// <summary>
    /// Menangani formula untuk menghitung sesuatu pada game.
    /// </summary>
    public interface IFormula
    {
        /// <summary>
        /// Untuk menghitung formula.
        /// </summary>
        /// <param name="parameters">
        /// Parameter yang digunakan untuk menghitung formula.
        /// </param>
        /// <returns>
        /// Mengembalikan nilai berupa float.
        /// </returns>
        float Calculate(params object[] parameters);
    }
}