using UnityEngine;
using DG.Tweening;

namespace Factura
{
  public class RotationComp
  {
    public void RotateByInput(float speed, float rotMultiplier, float axisX, Transform transform)
    {
      Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
        axisX * rotMultiplier, transform.rotation.eulerAngles.z);
      transform.rotation = Quaternion.RotateTowards(transform.rotation,
        targetRotation, speed * Time.deltaTime);
    }
  }
}