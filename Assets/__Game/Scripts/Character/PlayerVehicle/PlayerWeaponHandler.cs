using UnityEngine;

namespace Factura
{
  public class PlayerWeaponHandler : CharacterWeaponHandler
  {
    [SerializeField] private PlayerController _playerVehicleController;

    private Weapon _currentWeapon;

    private void Awake()
    {
      _currentWeapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
      RotateWeapon();

      if (_playerVehicleController.StateMachine.CurrentState is PlayerMovementState)
      {
        if (_currentWeapon is Turret turret)
        {
          turret.AutoShoot();
        }
      }
    }

    protected override void RotateWeapon()
    {
      if (_playerVehicleController.StateMachine.CurrentState
        is not PlayerMovementState) return;

      if (_currentWeapon is Turret turret)
      {
        turret.Rotate(_playerVehicleController.InputManager.Joystick.Horizontal);
      }
    }
  }
}