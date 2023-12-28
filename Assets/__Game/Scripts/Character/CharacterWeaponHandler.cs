using UnityEngine;

namespace Factura
{
  public abstract class CharacterWeaponHandler : MonoBehaviour
  {
    protected virtual void ShootWeapon() { }

    protected virtual void AutoShootWeapon() { }

    protected virtual void RotateWeapon() { }
  }
}