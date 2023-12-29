using UnityEngine;

namespace Factura
{
  public class EnemyController : CharacterController
  {
    [field: SerializeField] public EnemyMovement EnemyMovement { get; private set; }
    [field: SerializeField] public EnemyDetector EnemyDetector { get; private set; }
    [field: SerializeField] public CharacterAnimation CharacterAnimation { get; private set; }

    private void Awake()
    {
      StateMachine.Init(new EnemyIdleState(this));
    }

    private void Update()
    {
      StateMachine.CurrentState.Update();
    }
  }
}