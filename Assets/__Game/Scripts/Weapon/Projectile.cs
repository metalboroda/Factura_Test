using UnityEngine;

namespace Factura
{
  public class Projectile : MonoBehaviour
  {
    [SerializeField] private Rigidbody _rigidbody;

    private float _speed;
    private int _power;

    private void Start()
    {
      Impulse();
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

    private void Impulse()
    {
      Vector3 forwardDirection = transform.forward;

      _rigidbody.AddForce(forwardDirection * _speed, ForceMode.Impulse);
    }
  }
}