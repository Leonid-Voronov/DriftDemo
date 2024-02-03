using Logic;
using Data;
using System.Collections.Generic;

namespace Infrastructure
{
    public interface IGameFactory
    {
        Currency CreateCurrency();
        ICoroutineRunner CreateCoroutineRunner();
        LoadingCurtain CreateLoadingCurtain();
        List<ISavedProgress> ProgressObjects { get; }
    }
}

