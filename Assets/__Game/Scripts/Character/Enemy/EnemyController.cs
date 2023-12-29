using UnityEngine;
using UnityEngine.Events;

namespace Factura
{
  public class EnemyController : CharacterController
  {
    [field: SerializeField] public EnemyMovement EnemyMovement { get; private set; }
    [field: SerializeField] public EnemyDetector EnemyDetector { get; private set; }
    [field: SerializeField] public CharacterAnimation CharacterAnimation { get; private set; }

    private UnityAction<GameStateEnum> _gameStateChangedAction;

    private void Awake()
    {
      StateMachine.Init(new EnemyIdleState(this));
    }

    private void OnEnable()
    {
      _gameStateChangedAction = (state) =>
      {
        if (state == GameStateEnum.Win)
        {
          EnemyDetector.gameObject.SetActive(false);
          StateMachine.ChangeState(new EnemyIdleState(this));
        }
      };

      EventManager.OnGameStateChanged += _gameStateChangedAction;
    }

    private void Update()
    {
      StateMachine.CurrentState.Update();
    }

    private void OnDisable()
    {
      EventManager.OnGameStateChanged -= _gameStateChangedAction;
    }
  }
}