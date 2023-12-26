using UnityEngine;

namespace Factura
{
  public class InputManager : MonoBehaviour
  {
    [field: SerializeField] public Joystick Joystick { get; private set; }
  }
}