using UnityEngine;

namespace Factura
{
  public class EnemyHandler : CharacterHandler
  {
    [Header("")]
    [SerializeField] private LayerMask _destroyLayer;

    private ObjectPool<ParticleHandler> _explosionPool;

    private void Awake()
    {
      _explosionPool = new(ExplosionVFX, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
      if ((_destroyLayer.value & 1 << other.gameObject.layer) != 0)
      {
        SpawnExplosion();

        Destroy(gameObject);
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
    }

    private ParticleHandler CreateExplosion()
    {
      var explosion = Instantiate(ExplosionVFX, transform.position, Quaternion.identity);

      return explosion;
    }

    private void OnPutExplosionInPull(ParticleHandler particleHandler)
    {
      particleHandler.gameObject.SetActive(false);
    }

    private void SpawnExplosion()
    {
      var explosion = _explosionPool.GetObjectFromPool(transform.position, transform.rotation, null);

      explosion.Init(transform.position, _explosionPool);
    }
  }
}