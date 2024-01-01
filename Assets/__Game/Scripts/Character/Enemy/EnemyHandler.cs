using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Factura
{
  public class EnemyHandler : CharacterHandler
  {
    public event Action<int> EnemyHealthChanged;

    [Header("")]
    [SerializeField] private EnemyTypeEnum _enemyType = EnemyTypeEnum.Default;

    [Header("Healler")]
    [SerializeField] private int _heal = 25;

    [Header("")]
    [SerializeField] private LayerMask _destroyLayer;
    [SerializeField] private int _power = 5;

    private ObjectPool<ParticleHandler> _explosionPool;

    private void Awake()
    {
      _explosionPool = new(ExplosionVFX, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
      if ((_destroyLayer.value & 1 << other.gameObject.layer) != 0)
      {
        if (other.TryGetComponent(out IDamageable damageable))
        {
          damageable.Damage(_power);

          Death();
        }
      }
    }

    public override void Damage(int damage)
    {
      MaxHealth -= damage;

      if (MaxHealth < 0)
      {
        MaxHealth = 0;

        HeallerDeath();
        Death();
      }

      EnemyHealthChanged?.Invoke(MaxHealth);
    }

    private void SpawnExplosion()
    {
      var explosion = _explosionPool.GetObjectFromPool(transform.position, transform.rotation, null);

      explosion.Init(transform.position, _explosionPool);
    }

    public override void Death()
    {
      SpawnExplosion();

      Destroy(gameObject);
    }

    private void HeallerDeath()
    {
      if (_enemyType == EnemyTypeEnum.Healler)
      {
        EventManager.RaisePlayerHealed(_heal);
      }
    }
  }
}