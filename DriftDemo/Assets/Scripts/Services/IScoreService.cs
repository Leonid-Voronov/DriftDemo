namespace Services
{
    public interface IScoreService
    {
        void AddScore(float delta);
        void ResetCurrentScore();
        float SessionScore { get; }
        void ConvertScoreToCash();
    }
}