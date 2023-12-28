using UnityEngine;

namespace Factura
{
  public abstract class CharacterController : MonoBehaviour
  {
    public StateMachine StateMachine { get; private set; } = new();
  }
}