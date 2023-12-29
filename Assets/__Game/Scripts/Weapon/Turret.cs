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
      ProjectilePool = new(CreateProjectile, null, OnPutBackInPull, defaultCapacity: 10);
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
      SpawnedProjectile = ProjectilePool.Get();
      SpawnedProjectile.Init(Speed, Power, ShootingPoint.position,
        ShootingPoint.rotation, ProjectilePool);
    }

    public void Rotate(Vector2 axis)
    {
      _rotationComp.RotateByInput(_rotationSpeed, _rotMultiplier, axis, transform);
    }

    private Projectile CreateProjectile()
    {
      var projectile = Instantiate(Projectile);

      return projectile;
    }

    private void OnPutBackInPull(Projectile projectile)
    {
      projectile.gameObject.SetActive(false);
    }
  }
}