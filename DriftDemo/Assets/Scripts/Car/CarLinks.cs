using UnityEngine;

namespace Car
{
    public class CarLinks : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private CarMaterialsSO _materials;
        [SerializeField] private GameObject _spoilerObject;
        public MeshRenderer MeshRenderer => _meshRenderer;
        public CarMaterialsSO MaterialsHolder => _materials;
        public GameObject SpoilerObject => _spoilerObject;
    }
}