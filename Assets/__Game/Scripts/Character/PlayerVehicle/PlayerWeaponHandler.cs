using UnityEngine;

namespace Factura
{
  public class PlayerWeaponHandler : CharacterWeaponHandler
  {
    private Weapon _currentWeapon;

    private void Awake()
    {
      _currentWeapon = GetComponentInChildren<Weapon>();
    }

    public override void AutoShootWeapon()
    {
      if (_currentWeapon is Turret turret)
      {
        turret.AutoShoot();
      }
    }

    public override void RotateWeapon(Vector2 axis)
    {
      if (_currentWeapon is Turret turret)
      {
        turret.Rotate(axis);
      }
    }
  }
}