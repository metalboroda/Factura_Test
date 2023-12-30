using UnityEngine;

namespace Factura
{
  public class Projectile : MonoBehaviour
  {
    [SerializeField] private TrailRenderer _trailRenderer;

    [Header("VFX")]
    [SerializeField] private ParticleHandler _explosionVFX;

    [Header("")]
    [SerializeField] private Rigidbody _rigidbody;

    private float _speed;
    private int _power;
    private ObjectPool<Projectile> _projectilePool;
    private ObjectPool<ParticleHandler> _particlePool;

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out IDamageable damageable))
      {
        damageable.Damage(_power);
      }

      SpawnExplosionVFX();

      _projectilePool.ReturnObjectToPool(this);
    }

    public void Init(float speed, int power, Vector3 position,
      Quaternion rotation, ObjectPool<Projectile> pool)
    {
      _projectilePool = pool;
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

      _particlePool = new(_explosionVFX, 25);

      Impulse();
    }

    private void Impulse()
    {
      Vector3 forwardDirection = transform.forward;

      _rigidbody.AddForce(forwardDirection * _speed, ForceMode.Impulse);
    }

    private void SpawnExplosionVFX()
    {
      var spawnedVFX = _particlePool.GetObjectFromPool(transform.position,
        transform.rotation, null);

      spawnedVFX.Init(transform.position, _particlePool);
    }
  }
}