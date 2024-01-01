using UnityEngine;

namespace Factura
{
  public class EnemySpawner : MonoBehaviour
  {
    [SerializeField] private bool _needSpawn = true;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyHeallerPrefab;
    [SerializeField] private int _spawnAmount;
    [SerializeField] private int _heallerChance = 10;

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
      if (!_needSpawn) return;

      for (int i = 0; i < _spawnAmount; i++)
      {
        Vector3 randomPosition = GetRandomPositionWithinCollider();
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

        GameObject enemyPrefabToSpawn = Random.value < (_heallerChance / 100f) ? _enemyHeallerPrefab : _enemyPrefab;

        Instantiate(enemyPrefabToSpawn, randomPosition, randomRotation, transform);
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