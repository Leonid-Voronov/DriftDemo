using Infrastructure;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;
using System.Collections.Generic;
using Data;
using Services;
using System.Linq;

namespace UI.MainMenu
{
    public class PlayPanel : MenuPanel
    {
        [SerializeField] private TMP_Dropdown _carDropdown;
        [SerializeField] private TMP_Dropdown _mapDropdown;
        [SerializeField] private Button _startGameButton;
        private GameStateMachine _gameStateMachine;
        private List<CarName> _carNames;
        private IPlayerDataService _playerDataService;
        private const string GameplaySceneName = "Track2";
        private List<string> _trackNames;
        private IConvertService _convertService;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine, IConvertService convertService, IPlayerDataService playerDataService)
        {
            _gameStateMachine = gameStateMachine;
            _playerDataService = playerDataService;
            _convertService = convertService;
            FillLists();
        }

        private void OnEnable()
        {
            List<CarName> purchasedCarNames = _carNames.Where(c => _playerDataService.PlayerGarage.IsCarPurchased(c)).ToList();
            AddOptionsToDropdown(_carDropdown, _convertService.ConvertEnumToString(purchasedCarNames));
            AddOptionsToDropdown(_mapDropdown, _trackNames);
            _startGameButton.onClick.AddListener(OnStartGameButtonPressed);
            _carDropdown.onValueChanged.AddListener(delegate { OnCarDropdownValueChanged(_carDropdown); });
        }

        private void OnStartGameButtonPressed() => _gameStateMachine.Enter<LoadLevelState, string>(_trackNames[_mapDropdown.value]);
        private void OnCarDropdownValueChanged(TMP_Dropdown change) => _playerDataService.PlayerGarage.ChangeActiveCar(_carNames[change.value]);

        private void AddOptionsToDropdown(TMP_Dropdown dropdown, List<string> options)
        {
            dropdown.ClearOptions();
            dropdown.AddOptions(options);
        }

        private void FillLists()
        {
            _carNames = new List<CarName>
            {
                CarName.Car1,
                CarName.Car2,
            };
            _trackNames = new List<string>()
            {
                "Track1",
                "Track2"
            };
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(OnStartGameButtonPressed);
            _carDropdown.onValueChanged.RemoveListener(delegate { OnCarDropdownValueChanged(_carDropdown); });
        }
    }
}

