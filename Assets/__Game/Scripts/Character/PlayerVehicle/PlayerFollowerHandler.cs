using Dreamteck.Splines;
using UnityEngine;

namespace Factura
{
  public class PlayerFollowerHandler : MonoBehaviour
  {
    [SerializeField] private SplineFollower _splineFollower;

    [Header("")]
    [SerializeField] private PlayerController _playerController;

    private void OnEnable()
    {
      _splineFollower.onEndReached += OnEndReached;
    }

    private void OnDisable()
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

      EventManager.RaisePlayerStateChanged(_playerController.StateMachine.CurrentState);
    }
  }
}