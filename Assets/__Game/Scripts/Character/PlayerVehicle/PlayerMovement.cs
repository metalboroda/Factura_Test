using UnityEngine;

namespace Factura
{
  public class PlayerMovement : CharacterMovement
  {
    [field: SerializeField] public Joystick Joystick { get; private set; }
  }
}