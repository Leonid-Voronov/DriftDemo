using System;

namespace Services
{
    public class AdsService : IAdsService, IDisposable
    {
        private const string AppKey = "";
        private bool _adAvailable;

        public void InitAds()
        {
            IronSource.Agent.init(AppKey);
            IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoClosed;
            IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoUnavailable;
            IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoAvailable;
        }

        public void ShowRewardedVideo()
        {
            if (_adAvailable)
                IronSource.Agent.showRewardedVideo();
        }

        private void RewardedVideoClosed(IronSourceAdInfo adInfo)
        {
            IronSource.Agent.init(AppKey, IronSourceAdUnits.REWARDED_VIDEO);
            IronSource.Agent.shouldTrackNetworkState(true);
        }

        private void RewardedVideoUnavailable() => _adAvailable = false;

        private void RewardedVideoAvailable(IronSourceAdInfo adInfo) => _adAvailable = true;

        public void Dispose()
        {
            IronSourceRewardedVideoEvents.onAdClosedEvent -= RewardedVideoClosed;
            IronSourceRewardedVideoEvents.onAdUnavailableEvent -= RewardedVideoUnavailable;
            IronSourceRewardedVideoEvents.onAdAvailableEvent -= RewardedVideoAvailable;
        }
    }
}