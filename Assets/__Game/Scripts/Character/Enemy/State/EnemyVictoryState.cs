namespace Factura
{
  public class EnemyVictoryState : State
  {
    public EnemyVictoryState(EnemyController enemyController)
    {
      _enemyController = enemyController;
    }

    private EnemyController _enemyController;

    public override void Enter()
    {
      _enemyController.CharacterAnimation.VictoryAnim();
    }
  }
}