using UnityEngine;
using TMPro;

namespace UI
{
    public class SessionScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void ShowSessionScore(float score) => _text.text = "Session score: " + Mathf.RoundToInt(score).ToString();
    }
}

