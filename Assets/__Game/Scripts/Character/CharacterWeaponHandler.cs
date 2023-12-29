using UnityEngine;

namespace Factura
{
  public abstract class CharacterWeaponHandler : MonoBehaviour
  {
    public virtual void ShootWeapon() { }

    public virtual void AutoShootWeapon() { }

    public virtual void RotateWeapon(Vector2 axis) { }
  }
}