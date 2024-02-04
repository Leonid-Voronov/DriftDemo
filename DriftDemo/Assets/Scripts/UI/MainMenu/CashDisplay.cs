using TMPro;
using UnityEngine;

namespace UI.MainMenu
{
    public class CashDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void DisplayCash(float value) => _text.text = Mathf.RoundToInt(value).ToString();
    }
}