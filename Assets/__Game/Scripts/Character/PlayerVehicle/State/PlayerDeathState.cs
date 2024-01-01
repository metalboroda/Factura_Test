namespace Factura
{
  public class PlayerDeathState : State
  {
    public PlayerDeathState(PlayerController playerController)
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