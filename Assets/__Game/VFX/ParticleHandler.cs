using System.Collections;
using UnityEngine;

namespace Factura
{
  public class ParticleHandler : MonoBehaviour
  {
    [SerializeField] private ParticleSystem _particleSystem;

    private ObjectPool<ParticleHandler> _particlePool;

    public void Init(Vector3 position, ObjectPool<ParticleHandler> pool)
    {
      _particleSystem.Stop();
      _particlePool = pool;
      gameObject.SetActive(true);
      transform.position = position;
      _particleSystem.Play();

      StartCoroutine(DoDestroyDuration());
    }

    private IEnumerator DoDestroyDuration()
    {
      yield return new WaitForSeconds(_particleSystem.main.duration);

      _particlePool.ReturnObjectToPool(this);
    }
  }
}