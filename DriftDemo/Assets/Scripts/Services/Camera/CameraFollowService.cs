using Cinemachine;
using UnityEngine;
using Zenject;

namespace Services.Camera
{
    public class CameraFollowService : ICameraFollowService
    {
        private CinemachineVirtualCamera _camera;

        [Inject]
        public CameraFollowService(CinemachineVirtualCamera camera)
        {
            _camera = camera;
        }

        public void FollowObject(GameObject newFollowedObject)
        {
            _camera.Follow = newFollowedObject.transform;
            _camera.LookAt = newFollowedObject.transform;
        }
    }
}