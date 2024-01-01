using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

namespace Factura
{
  public class PlayerUIHandler : CharacterUIHandler
  {
    [SerializeField] private GameObject _playerCanvas;

    [Header("Camera's")]
    [SerializeField] private CinemachineVirtualCamera _frontCamera;
    [SerializeField] private CinemachineVirtualCamera _mainCamera;

    private List<CinemachineVirtualCamera> _cameras = new();

    private void OnEnable()
    {
      EventManager.OnGameStateChanged += SwitchCamera;
      EventManager.OnPlayerStateChanged += SwitchUI;
      EventManager.OnPlayerHealthChanged += UpdateHealthBar;
    }

    private void Start()
    {
      _playerCanvas.SetActive(false);

      AddCamerasToList();
    }

    private void OnDisable()
    {
      EventManager.OnGameStateChanged -= SwitchCamera;
      EventManager.OnPlayerStateChanged -= SwitchUI;
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
          EnableCamera(_frontCamera);
          break;
        case GameStateEnum.Game:
          EnableCamera(_mainCamera);
          break;
        case GameStateEnum.Win:
          EnableCamera(_frontCamera);
          break;
      }
    }

    private void SwitchUI(State state)
    {
      if (state is PlayerMovementState)
      {
        _playerCanvas.SetActive(true);
      }
      else
      {
        _playerCanvas.SetActive(false);
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