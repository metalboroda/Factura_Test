using UnityEngine;
using UnityEngine.Events;

namespace Factura
{
  public class GameController : MonoBehaviour
  {
    [field: SerializeField] public GameStateEnum GameState { get; private set; }

    public GameStateEnum CurrentState { get; private set; }

    private UnityAction<State> _playerStateChangedAction;

    private void OnEnable()
    {
      _playerStateChangedAction = (state) =>
      {
        ChangeState(GameStateEnum.Win);
      };

      EventManager.OnPlayerStateChanged += _playerStateChangedAction;
    }

    private void Start()
    {
      ChangeState(GameStateEnum.Start);
    }

    private void OnDisable()
    {
      EventManager.OnPlayerStateChanged -= _playerStateChangedAction;
    }

    public void ChangeState(GameStateEnum newState)
    {
      if (CurrentState != newState)
      {
        CurrentState = newState;
        GameState = newState;

        EventManager.RaiseGameStateChanged(GameState);
      }
    }
  }
}