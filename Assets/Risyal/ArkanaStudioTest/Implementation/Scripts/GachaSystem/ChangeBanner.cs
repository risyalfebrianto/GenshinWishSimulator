using Assets.Risyal.ArkanaStudioTest.Core.GachaSystem;
using Assets.Risyal.ArkanaStudioTest.Core.PoolSystem;
using Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.Pool;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Risyal.ArkanaStudioTest.Implementation.Scripts.GachaSystem
{
    /// <summary>
    /// Untuk mengganti banner.
    /// </summary>
    public class ChangeBanner : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Jenis pull yang dipilih player.
        /// </summary>
        private ICurrentPullType _currentPullType = null;

        /// <summary>
        /// Menampilkan gambar banner pada scene.
        /// </summary>
        private Image _bannerImage = null;

        /// <summary>
        /// Menyimpan data banner.
        /// </summary>
        private IPool<BannerData> _bannerPool = null;

        #endregion

        #region Main

        /// <summary>
        /// Untuk mengganti banner.
        /// </summary>
        /// <param name="pulltype">
        /// Jenis pull gacha yang dipilih player.
        /// </param>
        private void DoChangeBanner(Pulltype pulltype)
        {
            _bannerImage.sprite = _bannerPool.Get(pulltype.ToString()).sprite;
        }

        #endregion

        #region Mono

        private void Awake()
        {
            _currentPullType = FindObjectsOfType<MonoBehaviour>().OfType<ICurrentPullType>().FirstOrDefault();
            _bannerImage = GetComponentInChildren<Image>();
            _bannerPool = Resources.Load<BannerPool>("So/Pool/BannerPool");

            _currentPullType.OnPullTypeChanged += DoChangeBanner;
        }

        private void OnDestroy()
        {
            _currentPullType.OnPullTypeChanged -= DoChangeBanner;
        }

        #endregion
    }
}