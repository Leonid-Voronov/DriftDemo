using System;
namespace Services
{
    public interface IAdsService
    {
        void InitAds();
        void ShowRewardedVideo();
        event EventHandler RewardedVideoClosed;
        void OnApplicationPause(bool pause);
    }
}