using Factura;
using UnityEngine;

public abstract class CharacterHandler : MonoBehaviour, IDamageable
{
  [SerializeField] protected int MaxHealth = 100;

  [Header("")]
  [SerializeField] protected ParticleHandler ExplosionVFX;

  public virtual void Damage(int damage) { }

  public virtual void Death() { }
}