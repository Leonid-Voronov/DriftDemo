using Car;
using Data;
using UnityEngine;
using Zenject;
using System.Collections.Generic;

namespace Services
{
    public class CarPaintingService : ICarPaintingService
    {
        private PlayerGarage _playerGarage;

        [Inject]
        public CarPaintingService(IPlayerDataService playerDataService)
        {
            _playerGarage = playerDataService.PlayerGarage;
        }

        public void PaintCar(GameObject car)
        {
            CarLinks carLinks = car.GetComponent<CarLinks>();
            Material newMaterial = carLinks.MaterialsHolder.Materials[_playerGarage.ActiveCar.MaterialIndex];
            List<Material> materials = new List<Material>(carLinks.MeshRenderer.materials);
            materials[0] = newMaterial;
            carLinks.MeshRenderer.materials = materials.ToArray();
            
        }
    }
}