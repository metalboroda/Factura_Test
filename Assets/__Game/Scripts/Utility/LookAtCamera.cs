using UnityEngine;

namespace Factura
{
  public class LookAtCamera : MonoBehaviour
  {
    private Camera _mainCamera;

    void Start()
    {
      _mainCamera = Camera.main;
    }

    void Update()
    {
      Vector3 cameraForward = _mainCamera.transform.forward;

      transform.rotation = Quaternion.LookRotation(cameraForward, Vector3.up);
    }
  }
}