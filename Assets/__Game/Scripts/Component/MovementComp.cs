using UnityEngine;

namespace Factura
{
  public class MovementComp
  {
    public void MoveForward(float speed, Transform transform)
    {
      Vector3 forwardMovement = transform.forward * speed * Time.deltaTime;

      transform.Translate(forwardMovement);
    }
  }
}