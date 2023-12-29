using UnityEngine;

namespace Factura
{
  public class EnemyChaseState : State
  {
    public EnemyChaseState(EnemyController enemyController)
    {
      _enemyController = enemyController;
      _enemyMovement = _enemyController.EnemyMovement;
      _enemyDetector = _enemyController.EnemyDetector;
    }

    private EnemyController _enemyController;
    private EnemyMovement _enemyMovement;
    private EnemyDetector _enemyDetector;

    public override void Update()
    {
      Chase();
    }

    private void Chase()
    {
      if (_enemyDetector.TargetPosition != Vector3.zero)
      {
        Vector3 direction = (_enemyDetector.TargetPosition - _enemyController.transform.position).normalized;
        Vector3 newPosition = Vector3.MoveTowards(_enemyController.transform.position,
          _enemyDetector.TargetPosition, _enemyMovement.MovementSpeed * Time.deltaTime);

        _enemyController.transform.position = newPosition;

        Quaternion rotation = Quaternion.LookRotation(direction);

        _enemyController.transform.rotation = rotation;
      }
    }
  }
}
