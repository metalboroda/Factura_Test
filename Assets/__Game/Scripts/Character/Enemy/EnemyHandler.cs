using UnityEngine;

namespace Factura
{
  public class EnemyHandler : CharacterHandler
  {
    [SerializeField] private LayerMask _destroyLayer;

    private void OnTriggerEnter(Collider other)
    {
      if ((_destroyLayer.value & 1 << other.gameObject.layer) != 0)
      {
        Destroy(gameObject);
      }
    }

    public override void Damage(int damage)
    {
      Health -= damage;

      if (Health < 0)
      {
        Health = 0;

        Destroy(gameObject);
      }
    }
  }
}
