using UI;
using UnityEngine;

public class HudMediator : MonoBehaviour
{
    [SerializeField] private SpeedDisplay _speedDisplay;
    [SerializeField] private DriftScorePanel _driftPanel;
    [SerializeField] private CurrentScoreDisplay _currentScoreDisplay;
    [SerializeField] private SessionScoreDisplay _sessionScoreDisplay;

    public void ShowSpeed(float speed) => _speedDisplay.ShowSpeed(speed);
    public void ShowDriftPanel() => _driftPanel.gameObject.SetActive(true);
    public void HideDriftPanel() => _driftPanel.gameObject.SetActive(false);
    public void DisplayCurrentScore(float score) => _currentScoreDisplay.ShowCurrentScore(score);
    public void DisplaySessionScore(float score) => _sessionScoreDisplay.ShowSessionScore(score);
}
