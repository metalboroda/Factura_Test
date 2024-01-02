using UnityEngine;

namespace Factura
{
  public class RotationComp
  {
    public void RotateByInput(float speed, Vector2 axis, Transform transform)
    {
      float rotationAmount = axis.x * speed * Time.deltaTime;
      Vector3 currentRotation = transform.rotation.eulerAngles;

      currentRotation.y += rotationAmount;
      transform.rotation = Quaternion.Euler(currentRotation);
    }
  }
}
