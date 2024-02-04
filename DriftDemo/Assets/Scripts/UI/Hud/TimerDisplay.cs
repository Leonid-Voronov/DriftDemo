using TMPro;
using UnityEngine;

namespace UI.Hud
{
    public class TimerDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        public void DisplayTimer(float timer) => _text.text = Mathf.Round(timer).ToString();
    }
}