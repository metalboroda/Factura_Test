namespace Factura
{
  public class PlayerIdleState : State
  {
    public PlayerIdleState(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private PlayerController _playerController;

    public override void Enter()
    {
      _playerController.PlayerFollowerHandler.SetFollowerSpeed(0);
    }
  }
}