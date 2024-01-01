using UnityEngine;

namespace Factura
{
  public class EnemySpawner : MonoBehaviour
  {
    [SerializeField] private bool _needSpawn = true;
    [SerializeField] private bool _needSpawnHealler = false;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyHeallerPrefab;
    [SerializeField] private int _spawnAmount;
    [SerializeField] private int _heallerChance = 10;

    [Header("")]
    [SerializeField] private BoxCollider _spawnerCollider;

    private void Start()
    {
      SpawnEnemies();
    }

    private void SpawnEnemies()
    {
      if (!_needSpawn) return;

      for (int i = 0; i < _spawnAmount; i++)
      {
        Vector3 randomPosition = GetRandomPointInCollider(_spawnerCollider);
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

        if (_needSpawnHealler == true)
        {
          GameObject enemyPrefabToSpawn = Random.value < (_heallerChance / 100f) ? _enemyHeallerPrefab : _enemyPrefab;

          Instantiate(enemyPrefabToSpawn, randomPosition, randomRotation, transform);
        }
        else
        {
          Instantiate(_enemyPrefab, randomPosition, randomRotation, transform);
        }
      }
    }

    public static Vector3 GetRandomPointInCollider(BoxCollider collider)
    {
      Vector3 randomPoint = new Vector3(
          Random.Range(collider.bounds.min.x, collider.bounds.max.x),
          Random.Range(collider.bounds.min.y, collider.bounds.max.y),
          Random.Range(collider.bounds.min.z, collider.bounds.max.z)
      );

      return randomPoint;
    }
  }
}
