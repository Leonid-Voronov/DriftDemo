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
        public PurchasedCar(string path, int cost, CarName name)
        {
            PrefabPath = path;
            Cost = cost;
            Name = name;
        }
    }
}