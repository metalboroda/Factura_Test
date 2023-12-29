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
      _characterAnimation = _enemyController.CharacterAnimation;
    }

    private EnemyController _enemyController;
    private EnemyMovement _enemyMovement;
    private EnemyDetector _enemyDetector;
    private CharacterAnimation _characterAnimation;

    public override void Enter()
    {
      _characterAnimation.RunAnim();
    }

    public override void Update()
    {
      Chase();
    }

    private void Chase()
    {
      if (_enemyDetector.TargetPosition != Vector3.zero)
      {
        // Movement
        Vector3 direction = (_enemyDetector.TargetPosition - _enemyController.transform.position).normalized;
        Vector3 newPosition = Vector3.MoveTowards(_enemyController.transform.position,
            _enemyDetector.TargetPosition, _enemyMovement.MovementSpeed * Time.deltaTime);

        _enemyController.transform.position = newPosition;

        // Rotation
        float step = (_enemyMovement.RoationSpeed * 100) * Time.deltaTime;
        Quaternion rotation = Quaternion.RotateTowards(_enemyController.transform.rotation,
            Quaternion.LookRotation(direction), step);

        _enemyController.transform.rotation = rotation;
      }
    }
  }
}