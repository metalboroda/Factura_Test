using UnityEngine;

namespace Factura
{
  public class EnemyDetector : MonoBehaviour
  {
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _detectionRadius = 25;

    [Header("")]
    [SerializeField] private EnemyController _enemyController;

    public Vector3 TargetPosition { get; private set; }

    private Collider[] _collidersBuffer = new Collider[25];

    private void Update()
    {
      CheckSphereForEnemy();
    }

    private void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.yellow;
      Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }

    private void CheckSphereForEnemy()
    {
      int numColliders = Physics.OverlapSphereNonAlloc(transform.position, _detectionRadius,
        _collidersBuffer, _enemyLayer);

      if (numColliders > 0)
      {
        TargetPosition = _collidersBuffer[0].transform.position;

        _enemyController.StateMachine.ChangeState(new EnemyChaseState(_enemyController));
      }
      else
      {
        TargetPosition = Vector3.zero;

        _enemyController.StateMachine.ChangeState(new EnemyIdleState(_enemyController));
      }
    }
  }
}