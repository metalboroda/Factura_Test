namespace Factura
{
  public class PlayerMovementState : State
  {
    public PlayerMovementState(PlayerController playerController)
    {
      _playerController = playerController;
      _playerMovement = _playerController.PlayerMovement;
      _playerWeaponHandler = _playerController.PlayerWeaponHandler;
    }

    private PlayerController _playerController;
    private PlayerMovement _playerMovement;
    private PlayerWeaponHandler _playerWeaponHandler;

    public override void Enter()
    {
      _playerController.PlayerFollowerHandler.SetFollowerSpeed(
        _playerController.PlayerMovement.MovementSpeed);
    }

    public override void Update()
    {
      _playerWeaponHandler.RotateWeapon(_playerMovement.Joystick.Direction);
      _playerWeaponHandler.AutoShootWeapon();
    }
  }
}