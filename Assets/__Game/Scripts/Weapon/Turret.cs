using UnityEngine;

namespace Factura
{
  public class Turret : Weapon
  {
    [Header("Turret")]
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotMultiplier;

    private RotationComp _rotationComp = new();

    public override void Shoot()
    {
      SpawnedProjectile = Instantiate(Projectile, ShootingPoint.position,
        ShootingPoint.rotation, null);
      SpawnedProjectile.Init(Speed, Power);
    }

    public void Rotate(float axisX)
    {
      _rotationComp.RotateByInput(_rotationSpeed, _rotMultiplier, axisX, transform);
    }
  }
}