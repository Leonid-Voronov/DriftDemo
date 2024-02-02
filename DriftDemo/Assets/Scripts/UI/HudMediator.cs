using UI;
using UnityEngine;

public class HudMediator : MonoBehaviour
{
    [SerializeField] private SpeedDisplay _speedDisplay;
    [SerializeField] private DriftScorePanel _driftPanel;

    public void ShowSpeed(float speed) => _speedDisplay.ShowSpeed(speed);
    public void ShowDriftPanel() => _driftPanel.gameObject.SetActive(true);

    public void HideDriftPanel() => _driftPanel.gameObject.SetActive(false);
}
