using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts
{
    /// <summary>
    /// Untuk menon-aktifkan object ketika start dimulai.
    /// </summary>
    [DefaultExecutionOrder(-10000)]
    public class DeactivateObjectAtStart : MonoBehaviour
    {
        #region Mono

        void Start()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}