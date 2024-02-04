using UnityEngine;

namespace Services
{
    public class AppExitService : IAppExitService
    {
        public void ExitApp() => Application.Quit();
    }
}