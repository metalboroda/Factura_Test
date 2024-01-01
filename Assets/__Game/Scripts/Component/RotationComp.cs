using UnityEngine;

namespace Factura
{
  public class RotationComp
  {
    public void RotateByInput(float speed, float rotMultiplier, Vector2 axis, Transform transform)
    {
      Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
        axis.x * rotMultiplier, transform.rotation.eulerAngles.z);
      transform.rotation = Quaternion.RotateTowards(transform.rotation,
        targetRotation, speed * Time.deltaTime);
    }
  }
}