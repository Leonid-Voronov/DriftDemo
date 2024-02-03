using Services;
using System;
using Zenject;

namespace Logic
{
    public class SaveTrigger : IDisposable, ISaveTrigger
    {
        private ILocalStorageService _localStorageService;

        [Inject]
        public SaveTrigger(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public void Dispose()
        {
            _localStorageService.Save();
        }
    }
}