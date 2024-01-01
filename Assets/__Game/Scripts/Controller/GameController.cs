using System;
using UnityEngine;

namespace Factura
{
  public class GameController : MonoBehaviour
  {
    public event Action<GameStateEnum> StateChanged;

    [field: SerializeField] public GameStateEnum GameState { get; private set; }

    private void Start()
    {
      ChangeState(GameStateEnum.Start);
    }

    public void ChangeState(GameStateEnum newState)
    {
      if (GameState == newState) return;

      GameState = newState;

      EventManager.RaiseGameStateChanged(GameState);

      StateChanged?.Invoke(GameState);
    }
  }
}