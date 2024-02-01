using Infrastructure;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : MonoBehaviour
{
    private IGameplayFactory _gameplayFactory;

    [Inject]
    public void Construct(IGameplayFactory gameplayFactory)
    {
        _gameplayFactory = gameplayFactory;
    }

    private void Start()
    {
        _gameplayFactory.CreateCar();
    }
}
