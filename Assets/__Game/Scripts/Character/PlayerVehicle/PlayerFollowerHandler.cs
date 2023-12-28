using Dreamteck.Splines;
using UnityEngine;

namespace Factura
{
  public class PlayerFollowerHandler : MonoBehaviour
  {
    [SerializeField] private SplineFollower _splineFollower;

    public void SetFollowerSpeed(float speed)
    {
      _splineFollower.followSpeed = speed;
    }
  }
}