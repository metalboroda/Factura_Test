using Dreamteck.Splines;
using UnityEngine;

namespace Factura
{
  public class PlayerFollowerHandler : MonoBehaviour
  {
    [SerializeField] private SplineFollower _splineFollower;

    [Header("")]
    [SerializeField] private PlayerController _playerController;

    private void Awake()
    {
      _splineFollower.onEndReached += OnEndReached;
    }

    private void OnDestroy()
    {
      _splineFollower.onEndReached -= OnEndReached;
    }

    public void SetFollowerSpeed(float speed)
    {
      _splineFollower.followSpeed = speed;
    }

    private void OnEndReached(double obj)
    {
      _playerController.StateMachine.ChangeState(new PlayerIdleState(_playerController));
    }
  }
}