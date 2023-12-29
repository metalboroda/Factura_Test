using UnityEngine;

namespace Factura
{
  public class EnemyIdleState : State
  {
    public EnemyIdleState(EnemyController enemyController)
    {
      _enemyController = enemyController;
      _characterAnimation = _enemyController.CharacterAnimation;
    }

    private EnemyController _enemyController;
    private CharacterAnimation _characterAnimation;

    public override void Enter()
    {
      _characterAnimation.IdleAnim();
    }
  }
}