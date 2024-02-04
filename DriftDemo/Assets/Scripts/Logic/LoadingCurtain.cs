using System.Collections;
using UnityEngine;

namespace Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeInSpeed;
        [SerializeField] private float _fadeInPerdiodicity;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
        }

        public void Hide() => StartCoroutine(FadeIn());

        private IEnumerator FadeIn()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= _fadeInSpeed;
                yield return new WaitForSeconds(_fadeInPerdiodicity);
            }

            gameObject.SetActive(false);
        }
    }
}

