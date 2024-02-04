using Data;
using System.Collections.Generic;
using UnityEngine;

namespace Car
{
    [CreateAssetMenu(fileName = "CarMaterials", menuName = "ScriptableObjects/CarMaterials", order = 2)]
    public class CarMaterialsSO : ScriptableObject
    {
        [SerializeField] private CarName _carName;
        [SerializeField] private List<Material> _materials = new List<Material>();
        public List<Material> Materials => _materials;
        public CarName CarName => _carName;
    }
}