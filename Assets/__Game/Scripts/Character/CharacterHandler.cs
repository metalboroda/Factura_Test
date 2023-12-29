using Factura;
using UnityEngine;

public abstract class CharacterHandler : MonoBehaviour, IDamageable
{
  [SerializeField] protected int Health = 100;

  [Header("")]
  [SerializeField] protected ParticleHandler ExplosionVFX;

  public virtual void Damage(int damage) { }
}