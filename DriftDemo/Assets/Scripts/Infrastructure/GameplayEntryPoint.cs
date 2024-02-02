using Infrastructure;
using UnityEngine;
using Zenject;
using Cinemachine;
using Services.Camera;

public class GameplayEntryPoint : MonoBehaviour
{
    private IGameplayFactory _gameplayFactory;
    private ICameraFollowService _cameraFollowService;

    [Inject]
    public void Construct(IGameplayFactory gameplayFactory, ICameraFollowService cameraFollowService)
    {
        _gameplayFactory = gameplayFactory;
        _cameraFollowService = cameraFollowService;
    }

    private void Start()
    {
        GameObject car = _gameplayFactory.CreateCar();
        _cameraFollowService.FollowObject(car);
    }
}
