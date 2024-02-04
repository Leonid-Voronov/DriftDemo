using UnityEngine;
using TMPro;

namespace UI
{
    public class SpeedDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void ShowSpeed(float speed) => _text.text = Mathf.RoundToInt(speed).ToString() + " km/h";
    }
}

