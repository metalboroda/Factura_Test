namespace Factura
{
  public class EnemyIdleState : State
  {
    public EnemyIdleState(EnemyController enemyController)
    {
      _enemyController = enemyController;
    }

    private EnemyController _enemyController;
  }
}