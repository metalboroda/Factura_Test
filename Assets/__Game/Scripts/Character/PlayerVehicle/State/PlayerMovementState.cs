namespace Factura
{
  public class PlayerMovementState : State
  {
    public PlayerMovementState(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private PlayerController _playerController;

    public override void Enter()
    {
      _playerController.PlayerFollowerHandler.SetFollowerSpeed(
        _playerController.PlayerMovement.MovementSpeed);
    }
  }
}