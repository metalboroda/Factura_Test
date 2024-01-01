using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Factura
{
  public class UIManager : MonoBehaviour
  {
    [Header("Start Screen")]
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private Button _startBtn;

    [Header("Game Screen")]
    [SerializeField] private GameObject _gameScreen;

    [Header("Win Screen")]
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private Button _winNextLevelBtn;

    [Header("Lose Screen")]
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private Button _loseRestartBtn;

    private List<GameObject> _screens = new();

    [Inject] private GameController _gameController;

    private void OnEnable()
    {
      EventManager.OnGameStateChanged += SwitchScreen;
    }

    private void Start()
    {
      SubscribeButtons();
      AddScreensToList();
    }

    private void OnDisable()
    {
      EventManager.OnGameStateChanged -= SwitchScreen;
    }

    private void SubscribeButtons()
    {
      _startBtn.onClick.AddListener(() =>
      {
        _gameController.ChangeState(GameStateEnum.Game);
      });
    }

    private void AddScreensToList()
    {
      _screens.Add(_startScreen);
      _screens.Add(_gameScreen);
      _screens.Add(_winScreen);
      _screens.Add(_loseScreen);
    }

    private void SwitchScreen(GameStateEnum state)
    {
      switch (state)
      {
        case GameStateEnum.Start:
          EnableCamera(_startScreen);
          break;
        case GameStateEnum.Game:
          EnableCamera(_gameScreen);
          break;
        case GameStateEnum.Lose:
          EnableCamera(_loseScreen);
          break;
        case GameStateEnum.Win:
          EnableCamera(_winScreen);
          break;
      }
    }

    private void EnableCamera(GameObject screenToEnable)
    {
      foreach (var screen in _screens)
      {
        if (screen == screenToEnable)
        {
          screen.gameObject.SetActive(true);
        }
        else
        {
          screen.gameObject.SetActive(false);
        }
      }
    }
  }
}