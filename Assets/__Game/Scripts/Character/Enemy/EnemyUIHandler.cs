using UnityEngine;

namespace Factura
{
  public class EnemyUIHandler : CharacterUIHandler
  {
    [Header("")]
    [SerializeField] private EnemyController _enemyController;

    private void OnEnable()
    {
      _enemyController.EnemyHandler.EnemyHealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
      _enemyController.EnemyHandler.EnemyHealthChanged -= UpdateHealthBar;
    }
  }
}