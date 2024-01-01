using UnityEngine;
using UnityEngine.Events;

namespace Factura
{
  public class PlayerController : CharacterController
  {
    [field: SerializeField] public PlayerMovement PlayerMovement { get; private set; }
    [field: SerializeField] public PlayerFollowerHandler PlayerFollowerHandler { get; private set; }
    [field: SerializeField] public PlayerWeaponHandler PlayerWeaponHandler { get; private set; }

    private UnityAction<GameStateEnum> _gameStateChangedAction;

    private void Awake()
    {
      StateMachine.Init(new PlayerIdleState(this));
    }

    private void OnEnable()
    {
      _gameStateChangedAction = (state) =>
      {
        if (state == GameStateEnum.Game)
        {
          StateMachine.ChangeState(new PlayerMovementState(this));
        }
      };

      EventManager.OnGameStateChanged += _gameStateChangedAction;

      StateMachine.StateChanged += OnStateChanged;
    }

    private void Update()
    {
      StateMachine.CurrentState.Update();
    }

    private void OnDisable()
    {
      EventManager.OnGameStateChanged -= _gameStateChangedAction;

      StateMachine.StateChanged -= OnStateChanged;
    }

    private void OnStateChanged(State state)
    {
      State newState = state;
      EventManager.RaisePlayerStateChanged(newState);
    }
  }
}