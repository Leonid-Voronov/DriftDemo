using Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Car
{
    [CreateAssetMenu(fileName = "CarsMaterialsHolder", menuName = "ScriptableObjects/CarsMaterialsHolder", order = 3)]
    public class CarsMaterialsHolderSO : ScriptableObject
    {
        [SerializeField] private List<CarMaterialsSO> _carsMaterialsSOs = new List<CarMaterialsSO>();

        public CarMaterialsSO GetCarMaterialsSO(CarName carName) => _carsMaterialsSOs.Where(so => so.CarName == carName).FirstOrDefault();
    }
}