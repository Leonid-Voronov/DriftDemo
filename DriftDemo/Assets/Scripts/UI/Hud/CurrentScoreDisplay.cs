using UnityEngine;
using TMPro;

namespace UI
{
    public class CurrentScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void ShowCurrentScore(float score) => _text.text = "CurrentScore: " + Mathf.RoundToInt(score).ToString();
    }
}

