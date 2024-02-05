using UnityEngine;

namespace Ads
{
    public class AdsPauser : MonoBehaviour
    {
        private void OnApplicationPause(bool pause) => IronSource.Agent.onApplicationPause(pause);
    }
}