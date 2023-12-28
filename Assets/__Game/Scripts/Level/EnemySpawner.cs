using UnityEngine;

namespace Factura
{
  public class EnemySpawner : MonoBehaviour
  {
    [SerializeField] private bool _needSpawn = true;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _spawnAmount;

    private BoxCollider _boxCollider;

    private void Awake()
    {
      _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
      SpawnEnemies();
    }

    private void SpawnEnemies()
    {
      if (_needSpawn == false) return;

      for (int i = 0; i < _spawnAmount; i++)
      {
        Vector3 randomPosition = GetRandomPositionWithinCollider();

        Instantiate(_enemyPrefab, randomPosition, Quaternion.identity, transform);
      }
    }

    private Vector3 GetRandomPositionWithinCollider()
    {
      float minX = transform.position.x - _boxCollider.size.x / 2f;
      float maxX = transform.position.x + _boxCollider.size.x / 2f;

      float minZ = transform.position.z - _boxCollider.size.z / 2f;
      float maxZ = transform.position.z + _boxCollider.size.z / 2f;

      float randomX = Random.Range(minX, maxX);
      float randomZ = Random.Range(minZ, maxZ);

      return new Vector3(randomX, 0f, randomZ);
    }
  }
}