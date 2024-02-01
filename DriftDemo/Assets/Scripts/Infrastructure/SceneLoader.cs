using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure
{
    public class SceneLoader
    {
        private ICoroutineRunner _coroutineRunner;

        [Inject]
        public SceneLoader(IGameFactory gameFactory)
        {
            _coroutineRunner = gameFactory.CreateCoroutineRunner();
        }

        public void Load(string name, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }
            

        private IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            if(SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while(!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}

