using System;
using UnityEngine;

namespace Factura
{
  public class EnemyHandler : CharacterHandler
  {
    public event Action<int> EnemyHealthChanged;

    [Header("")]
    [SerializeField] private LayerMask _destroyLayer;
    [SerializeField] private int _power = 5;

    [Header("")]
    [SerializeField] private ParticleHandler _explosionVFX;

    private ObjectPool<ParticleHandler> _explosionPool;

    private void Awake()
    {
      _explosionPool = new(_explosionVFX, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
      if ((_destroyLayer.value & 1 << other.gameObject.layer) != 0)
      {
        if (other.TryGetComponent(out IDamageable damageable))
        {
          damageable.Damage(_power);

          SpawnExplosion();

          Destroy(gameObject);
        }
      }
    }

    public override void Damage(int damage)
    {
      Health -= damage;

      if (Health < 0)
      {
        Health = 0;

        SpawnExplosion();

        Destroy(gameObject);
      }

      EnemyHealthChanged?.Invoke(Health);
    }

    private void SpawnExplosion()
    {
      var explosion = _explosionPool.GetObjectFromPool(transform.position, transform.rotation, null);

      explosion.Init(transform.position, _explosionPool);
    }
  }
}