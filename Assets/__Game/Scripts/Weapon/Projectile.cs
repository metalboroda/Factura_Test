using UnityEngine;
using UnityEngine.Pool;

namespace Factura
{
  public class Projectile : MonoBehaviour
  {
    [SerializeField] private TrailRenderer _trailRenderer;

    [Header("")]
    [SerializeField] private Rigidbody _rigidbody;

    private float _speed;
    private int _power;
    private ObjectPool<Projectile> _pool;

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out IDamageable damageable))
      {
        damageable.Damage(_power);
      }

      _pool.Release(this);
    }

    public void Init(float speed, int power, Vector3 position,
      Quaternion rotation, ObjectPool<Projectile> pool)
    {
      _pool = pool;
      gameObject.SetActive(true);
      _rigidbody.velocity = Vector3.zero;
      transform.position = position;
      transform.rotation = rotation;
      _speed = speed;
      _power = power;

      if (_trailRenderer != null)
      {
        _trailRenderer.Clear();
      }

      Impulse();
    }

    private void Impulse()
    {
      Vector3 forwardDirection = transform.forward;

      _rigidbody.AddForce(forwardDirection * _speed, ForceMode.Impulse);
    }
  }
}