namespace Data
{
    [System.Serializable]
    public class PurchasedCar
    {
        private string _prefabPath;
        private float _cost;
        private float _playerDataIndex;
        private CarName _name;

        public PurchasedCar(string path, int cost, int playerDataIndex, CarName name)
        {
            _prefabPath = path;
            _cost = cost;
            _playerDataIndex = playerDataIndex;
            _name = name;
        }

        public float Cost => _cost;
        public float PlayerDataIndex => _playerDataIndex;
        public CarName Name => _name;
    }
}