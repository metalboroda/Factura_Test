using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

namespace Factura
{
  public class PlayerUIHandler : CharacterUIHandler
  {
    [SerializeField] private GameObject _healthUI;

    [Header("Camera's")]
    [SerializeField] private CinemachineVirtualCamera _frontCamera;
    [SerializeField] private CinemachineVirtualCamera _mainCamera;

    private List<CinemachineVirtualCamera> _cameras = new();

    private void OnEnable()
    {
      EventManager.OnGameStateChanged += SwitchCamera;
      EventManager.OnPlayerHealthChanged += UpdateHealthBar;
    }

    private void Start()
    {
      AddCamerasToList();
    }

    private void OnDisable()
    {
      EventManager.OnGameStateChanged -= SwitchCamera;
      EventManager.OnPlayerHealthChanged -= UpdateHealthBar;
    }

    private void AddCamerasToList()
    {
      _cameras.Add(_frontCamera);
      _cameras.Add(_mainCamera);
    }

    private void SwitchCamera(GameStateEnum state)
    {
      switch (state)
      {
        case GameStateEnum.Start:
          _healthUI.gameObject.SetActive(false);

          EnableCamera(_frontCamera);
          break;
        case GameStateEnum.Game:
          _healthUI.gameObject.SetActive(true);

          EnableCamera(_mainCamera);
          break;
        case GameStateEnum.Win:
          _healthUI.gameObject.SetActive(false);

          EnableCamera(_frontCamera);
          break;
      }
    }

    private void EnableCamera(CinemachineVirtualCamera cameraToEnable)
    {
      foreach (var camera in _cameras)
      {
        if (camera == cameraToEnable)
        {
          camera.gameObject.SetActive(true);
        }
        else
        {
          camera.gameObject.SetActive(false);
        }
      }
    }
  }
}