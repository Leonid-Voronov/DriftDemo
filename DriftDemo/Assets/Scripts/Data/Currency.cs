using System;

namespace Data
{
    public class Currency : ISavedProgress
    {
        public event EventHandler<CashAmountChangedEventArgs> CashAmountChanged;
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
        
        public float CashAmount => _cashAmount;
        public void LoadProgress(PlayerData playerData) => _cashAmount = playerData.CashAmount;
        public void UpdateProgress(PlayerData playerData) => playerData.CashAmount = _cashAmount;

        private void OnCashAmountChanged(object sender, EventArgs e) => CashAmountChanged?.Invoke(this, new CashAmountChangedEventArgs(_cashAmount));
    }

    public class CashAmountChangedEventArgs : EventArgs
    {
        private float _cashAmount;
        public CashAmountChangedEventArgs(float cashAmount)
        {
            _cashAmount = cashAmount;
        }

        public float CashAmount => _cashAmount;
    }
}

