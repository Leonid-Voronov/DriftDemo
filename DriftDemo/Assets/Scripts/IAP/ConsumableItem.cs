namespace Purchases
{
    [System.Serializable]
    public class ConsumableItem
    {
        private string _name;
        private string _id;
        private string _description;
        private float _price;

        public ConsumableItem(string name, string id, string description, float price)
        {
            _name = name;
            _id = id;
            _description = description;
            _price = price;
        }

        public string Name => _name;
        public string Id => _id;
        public string Description => _description;
        public float Price => _price;
    }
}

