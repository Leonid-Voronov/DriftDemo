using UnityEngine;

namespace Services.Camera
{
    public interface ICameraFollowService
    {
        void FollowObject(GameObject newFollowedObject);
    }
}