namespace Factura
{
  public class EnemyDeathState : State
  {
    public EnemyDeathState(EnemyController enemyController)
    {
      _enemyController = enemyController;
      _enemyHandler = _enemyController.EnemyHandler;
    }

    private EnemyController _enemyController;
    private EnemyHandler _enemyHandler;

    public override void Enter()
    {
      _enemyHandler.Damage(999);
    }
  }
}