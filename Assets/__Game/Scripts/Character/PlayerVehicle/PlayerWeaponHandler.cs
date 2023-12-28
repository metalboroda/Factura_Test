using Zenject;

namespace Factura
{
  public class PlayerWeaponHandler : CharacterWeaponHandler
  {
    private Weapon _currentWeapon;

    [Inject] private InputManager _inputManager;

    private void Awake()
    {
      _currentWeapon = GetComponentInChildren<Weapon>();
    }

    private void Update()
    {
      RotateWeapon();
    }

    protected override void RotateWeapon()
    {
      if (_currentWeapon is Turret turret)
      {
        turret.Rotate(_inputManager.Joystick.Horizontal);
      }
    }
  }
}