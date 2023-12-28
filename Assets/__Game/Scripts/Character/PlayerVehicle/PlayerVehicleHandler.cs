using UnityEngine;

namespace Factura
{
  public class PlayerVehicleHandler : CharacterHandler
  {
    public override void Damage(int damage)
    {
      Health -= damage;

      if (Health <= 0)
      {
        Health = 0;
      }
    }
  }
}