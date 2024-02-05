using Infrastructure;
using System;
using UI;
using UI.Hud;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HudMediator : MonoBehaviour
{
    [SerializeField] private SpeedDisplay _speedDisplay;
    [SerializeField] private DriftScorePanel _driftPanel;
    [SerializeField] private CurrentScoreDisplay _currentScoreDisplay;
    [SerializeField] private SessionScoreDisplay _sessionScoreDisplay;
    [SerializeField] private TimerDisplay _timerDisplay;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private Button _toMenuButton;
    [SerializeField] private Button _doubleRewardButton; 
    private GameStateMachine _gameStateMachine;

    private const string MainMenuName = "MainMenuScene";

    public event EventHandler DoubleRewardButtonPressed;

    [Inject]
    public void Construct(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    private void OnEnable()
    {
        _toMenuButton.onClick.AddListener(ToMenuButtonPressed);
        _doubleRewardButton.onClick.AddListener(OnDoubleRewardButtonPressed);
    }

    public void ShowSpeed(float speed) => _speedDisplay.ShowSpeed(speed);
    public void ShowDriftPanel() => _driftPanel.gameObject.SetActive(true);
    public void HideDriftPanel() => _driftPanel.gameObject.SetActive(false);
    public void DisplayCurrentScore(float score) => _currentScoreDisplay.ShowCurrentScore(score);
    public void DisplaySessionScore(float score) => _sessionScoreDisplay.ShowSessionScore(score);
    public void DisplayTimer(float timer) => _timerDisplay.DisplayTimer(timer);
    public void ShowFinishPanel() => _finishPanel.gameObject.SetActive(true);
    private void ToMenuButtonPressed() => _gameStateMachine.Enter<LoadLevelState, string>(MainMenuName);
    private void OnDoubleRewardButtonPressed()
    {
        DoubleRewardButtonPressed?.Invoke(this, EventArgs.Empty);
        _doubleRewardButton.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _toMenuButton.onClick.RemoveListener(ToMenuButtonPressed);
        _doubleRewardButton.onClick.RemoveListener(OnDoubleRewardButtonPressed);
    }
}
