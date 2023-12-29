using UnityEngine;
using Zenject;

namespace Factura
{
  public class PlayerController : CharacterController
  {
    [field: SerializeField] public PlayerMovement PlayerMovement { get; private set; }
    [field: SerializeField] public PlayerFollowerHandler PlayerFollowerHandler { get; private set; }

    [Inject] public GameController GameController { get; private set; }
    [Inject] public InputManager InputManager { get; private set; }

    private void Awake()
    {
      StateMachine.Init(new PlayerIdleState(this));

      GameController.StateChanged += (state) =>
      {
        if (state == GameStateEnum.Game)
        {
          StateMachine.ChangeState(new PlayerMovementState(this));
        }
      };
    }

    private void Update()
    {
      StateMachine.CurrentState.Update();
    }
  }
}