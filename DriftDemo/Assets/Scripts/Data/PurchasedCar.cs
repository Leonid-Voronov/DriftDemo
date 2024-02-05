using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class PurchasedCar
    {
        public string PrefabPath { get; set; }
        public float Cost { get; set; }
        public CarName Name { get; set; }
        public int MaterialIndex { get; set; }
        public bool WithSpoiler { get; set; }
        public PurchasedCar(string path, int cost, CarName name, bool withSpoiler)
        {
            PrefabPath = path;
            Cost = cost;
            Name = name;
            WithSpoiler = withSpoiler;
        }

        public int SpoilerStartIndex => WithSpoiler ? 1 : 0;
    }
}