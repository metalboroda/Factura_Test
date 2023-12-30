using UnityEngine;

namespace Factura
{
  public class Setup : MonoBehaviour
  {
    [SerializeField] private int _vSyncCount = 1;
    [SerializeField] private int _targetFrameRate = 120;

    private void Awake()
    {
      QualitySettings.vSyncCount = _vSyncCount;
      Application.targetFrameRate = _targetFrameRate;
    }
  }
}