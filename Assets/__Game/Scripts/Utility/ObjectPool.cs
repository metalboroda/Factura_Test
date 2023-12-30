using System.Collections.Generic;
using UnityEngine;

namespace Factura
{
  public class ObjectPool
  {
    private GameObject _prefab;
    private int _poolSize = 100;

    private List<GameObject> objectPool;

    public ObjectPool(GameObject prefab, int poolSize)
    {
      _prefab = prefab;
      _poolSize = poolSize;

      InitializePool();
    }

    private void InitializePool()
    {
      objectPool = new List<GameObject>();

      for (int i = 0; i < _poolSize; i++)
      {
        GameObject obj = Object.Instantiate(_prefab);

        obj.SetActive(false);
        objectPool.Add(obj);
      }
    }

    public GameObject GetObjectFromPool(Vector3 position, Quaternion rotation)
    {
      foreach (GameObject obj in objectPool)
      {
        if (!obj.activeInHierarchy)
        {
          obj.transform.position = position;
          obj.transform.rotation = rotation;
          obj.SetActive(true);

          return obj;
        }
      }

      GameObject newObj = Object.Instantiate(_prefab, position, rotation);

      objectPool.Add(newObj);

      return newObj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
      obj.SetActive(false);
    }
  }
}