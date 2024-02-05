using System;

namespace Services
{
    public class AdsService : IAdsService, IDisposable
    {
        private const string AppKey = "";
        private bool _adAvailable;

        public event EventHandler RewardedVideoClosed;

        public void InitAds()
        {
            IronSource.Agent.init(AppKey);
            IronSourceRewardedVideoEvents.onAdClosedEvent += OnRewardedVideoClosed;
            IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoUnavailable;
            IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoAvailable;
        }

        public void ShowRewardedVideo()
        {
            if (_adAvailable)
                IronSource.Agent.showRewardedVideo();
        }

        private void OnRewardedVideoClosed(IronSourceAdInfo adInfo)
        {
            IronSource.Agent.init(AppKey, IronSourceAdUnits.REWARDED_VIDEO);
            IronSource.Agent.shouldTrackNetworkState(true);
            RewardedVideoClosed?.Invoke(this, EventArgs.Empty);
        }

        private void RewardedVideoUnavailable() => _adAvailable = false;

        private void RewardedVideoAvailable(IronSourceAdInfo adInfo) => _adAvailable = true;
        public void OnApplicationPause(bool pause) => IronSource.Agent.onApplicationPause(pause);
        public void Dispose()
        {
            IronSourceRewardedVideoEvents.onAdClosedEvent -= OnRewardedVideoClosed;
            IronSourceRewardedVideoEvents.onAdUnavailableEvent -= RewardedVideoUnavailable;
            IronSourceRewardedVideoEvents.onAdAvailableEvent -= RewardedVideoAvailable;
        }
    }
}