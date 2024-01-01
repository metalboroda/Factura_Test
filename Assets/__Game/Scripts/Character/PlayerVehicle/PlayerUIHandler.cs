using Cinemachine;
using System.Collections;
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

    [Header("Camera shake")]
    [SerializeField] private float _shakeIntensity = 1f;
    [SerializeField] private float _shakeTime = 0.2f;

    private List<CinemachineVirtualCamera> _cameras = new();

    private CinemachineBasicMultiChannelPerlin _cbmcp;

    private void Awake()
    {
      _cbmcp = _mainCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void OnEnable()
    {
      EventManager.OnGameStateChanged += SwitchCamera;
      EventManager.OnPlayerStateChanged += SwitchUI;
      EventManager.OnPlayerHealthChanged += UpdateHealthBar;
      EventManager.OnPlayerDamaged += ShakeCamera;
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
      EventManager.OnPlayerDamaged -= ShakeCamera;
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

    private void ShakeCamera()
    {
      _cbmcp.m_AmplitudeGain = _shakeIntensity;

      StartCoroutine(DoStopShakeCamera());
    }

    private IEnumerator DoStopShakeCamera()
    {
      yield return new WaitForSeconds(_shakeTime);

      _cbmcp.m_AmplitudeGain = 0;
    }
  }
}