using UnityEngine;

namespace Factura
{
  public class Projectile : MonoBehaviour
  {
    private float _speed;
    private int _power;

    private MovementComp _movementComp = new();

    private void Update()
    {
      _movementComp.MoveForward(_speed, transform);
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out IDamageable damageable))
      {
        damageable.Damage(_power);
      }

      Destroy(gameObject);
    }

    public void Init(float speed, int power)
    {
      _speed = speed;
      _power = power;
    }
  }
}