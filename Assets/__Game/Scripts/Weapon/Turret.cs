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

    private void Awake()
    {
      ProjectilePool = new(Projectile, 25);
      FlarePool = new(FlareVFX, 5);
    }

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
      SpawnedProjectile = ProjectilePool.GetObjectFromPool(
        ShootingPoint.position, ShootingPoint.rotation, null);
      SpawnedProjectile.Init(Speed, Power, ShootingPoint.position,
        ShootingPoint.rotation, ProjectilePool);

      SpawnFlare();
    }

    public void Rotate(Vector2 axis)
    {
      _rotationComp.RotateByInput(_rotationSpeed, _rotMultiplier, axis, transform);
    }

    private void SpawnFlare()
    {
      var spawnedFlare = FlarePool.GetObjectFromPool(
        ShootingPoint.localPosition, ShootingPoint.rotation, ShootingPoint.transform);

      spawnedFlare.Init(ShootingPoint.position, FlarePool);
    }
  }
}