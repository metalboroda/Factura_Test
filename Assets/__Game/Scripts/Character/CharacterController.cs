using UnityEngine;

namespace Factura
{
  [SelectionBase]
  public abstract class CharacterController : MonoBehaviour
  {
    public StateMachine StateMachine { get; private set; } = new();
  }
}