namespace Data
{
    public interface ISavedProgress
    {
        void UpdateProgress(PlayerData playerData);
        void LoadProgress(PlayerData playerData);
    }
}

