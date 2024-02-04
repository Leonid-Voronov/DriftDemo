using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.MainMenu
{
    public class MainMenuMediator : MonoBehaviour
    {
        [Header ("Buttons")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _garageButton;
        [SerializeField] private Button _shopButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;

        [Header ("Panels")]
        [SerializeField] private MenuPanel _playPanel;
        [SerializeField] private MenuPanel _garagePanel;
        [SerializeField] private MenuPanel _shopPanel;
        [SerializeField] private MenuPanel _settingsPanel;
         
        private IAppExitService _exitService;
        private MenuPanel _activePanel = null;

        [Inject]
        public void Construct(IAppExitService appExitService)
        {
            _exitService = appExitService;
        }

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonPressed);
            _garageButton.onClick.AddListener(OnGarageButtonPressed);
            _shopButton.onClick.AddListener(OnShopButtonPressed);
            _settingsButton.onClick.AddListener(OnSettingsButtonPressed);
            _exitButton.onClick.AddListener(OnExitButtonPressed);
        }

        private void OnPlayButtonPressed() => ChangePanel(_playPanel);
        private void OnGarageButtonPressed() => ChangePanel(_garagePanel);
        private void OnShopButtonPressed() => ChangePanel(_shopPanel);
        private void OnSettingsButtonPressed() => ChangePanel(_settingsPanel);
        private void OnExitButtonPressed() => _exitService.ExitApp();

        private void ChangePanel(MenuPanel panel)
        {
            _activePanel?.gameObject.SetActive(false);
            panel.gameObject.SetActive(true);
            _activePanel = panel;
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonPressed);
            _garageButton.onClick.RemoveListener(OnGarageButtonPressed);
            _shopButton.onClick.RemoveListener(OnShopButtonPressed);
            _settingsButton.onClick.RemoveListener(OnSettingsButtonPressed);
            _exitButton.onClick.RemoveListener(OnExitButtonPressed);
        }
    }
}
