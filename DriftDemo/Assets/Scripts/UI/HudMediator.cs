using UI;
using UnityEngine;

public class HudMediator : MonoBehaviour
{
    [SerializeField] private SpeedDisplay _speedDisplay;

    public void ShowSpeed(float speed) => _speedDisplay.ShowSpeed(speed);
}
