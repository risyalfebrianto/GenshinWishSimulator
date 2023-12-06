using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Global
{
    /// <summary>
    /// Menangani semua ekstensi yang ada pada game.
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Untuk mengubah text uppercase diganti dengan space.
        /// </summary>
        /// <param name="value">
        /// Text yang ingin dirubah.
        /// </param>
        /// <returns>
        /// Mengembalikan nilai berupa string.
        /// </returns>
        public static string ConvertUpperCaseToSpace(this string value)
        {
            var newValue = Regex.Replace(value, "([a-z])([A-Z])", "$1 $2");

            return newValue;
        }
    }
}