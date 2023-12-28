namespace Factura
{
  public class EnemyController : CharacterController
  {
    private void Start()
    {
      StateMachine.Init(new EnemyIdleState(this));
    }
  }
}