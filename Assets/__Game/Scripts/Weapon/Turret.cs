using UnityEngine;

namespace Factura
{
  public class Turret : Weapon
  {
    [Header("Turret")]
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotMultiplier;

    private float _lastShotTime;

    private RotationComp _rotationComp = new();

    private void Update()
    {
      DrawLaser();
    }

    public override void AutoShoot()
    {
      if (Autoshooting == false) return;

      if (Time.time - _lastShotTime >= ShootingInterval)
      {
        Shoot();

        _lastShotTime = Time.time;
      }
    }

    public override void Shoot()
    {
      SpawnedProjectile = Instantiate(Projectile, ShootingPoint.position,
          ShootingPoint.rotation, null);
      SpawnedProjectile.Init(Speed, Power);
    }

    public void Rotate(Vector2 axis)
    {
      _rotationComp.RotateByInput(_rotationSpeed, _rotMultiplier, axis, transform);
    }
  }
}