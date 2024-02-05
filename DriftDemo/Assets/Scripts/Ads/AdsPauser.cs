using Services;
using UnityEngine;
using Zenject;

namespace Ads
{
    public class AdsPauser : MonoBehaviour
    {
        private IAdsService _adsService;

        [Inject]
        public void Construct(IAdsService adsService)
        {
            _adsService = adsService;
        }

        private void OnApplicationPause(bool pause) => IronSource.Agent.onApplicationPause(pause);
    }
}