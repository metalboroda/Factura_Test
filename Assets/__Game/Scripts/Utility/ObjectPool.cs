using System.Collections.Generic;
using UnityEngine;

namespace Factura
{
  public class ObjectPool<T> where T : MonoBehaviour
  {
    private T _prefab;
    private int _poolSize = 100;

    private List<T> objectPool;

    public ObjectPool(T prefab, int poolSize)
    {
      _prefab = prefab;
      _poolSize = poolSize;

      InitializePool();
    }

    private void InitializePool()
    {
      objectPool = new List<T>();

      for (int i = 0; i < _poolSize; i++)
      {
        T obj = Object.Instantiate(_prefab);

        obj.gameObject.SetActive(false);
        objectPool.Add(obj);
      }
    }

    public T GetObjectFromPool(Vector3 position, Quaternion rotation, Transform parent)
    {
      foreach (T obj in objectPool)
      {
        if (!obj.gameObject.activeInHierarchy)
        {
          obj.transform.position = position;
          obj.transform.rotation = rotation;
          obj.gameObject.SetActive(true);

          return obj;
        }
      }

      T newObj = Object.Instantiate(_prefab, position, rotation, parent);

      objectPool.Add(newObj);

      return newObj;
    }

    public void ReturnObjectToPool(T obj)
    {
      obj.gameObject.SetActive(false);
    }
  }
}