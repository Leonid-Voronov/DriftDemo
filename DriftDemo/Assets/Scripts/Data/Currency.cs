namespace Data
{
    public class Currency : ISavedProgress
    {
        private float _cashAmount = 0f;

        public void AddCash(float amount) => _cashAmount += amount;

        public bool SpendCash(float amount)
        {
            if (_cashAmount - amount >= 0)
            {
                _cashAmount -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LoadProgress(PlayerData playerData) => _cashAmount = playerData.CashAmount;

        public void UpdateProgress(PlayerData playerData) => playerData.CashAmount = _cashAmount;
    }
}

