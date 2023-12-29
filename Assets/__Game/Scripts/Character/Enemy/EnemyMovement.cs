using UnityEngine;

namespace Factura
{
  public class EnemyMovement : CharacterMovement
  {
    [field: SerializeField] public float RoationSpeed { get; private set; } = 5;
  }
}