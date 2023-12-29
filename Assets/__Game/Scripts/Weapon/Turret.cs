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
      ProjectilePool = new(CreateProjectile, null, OnPutProjectileInPull, defaultCapacity: 10);
      FlarePool = new(CreateFlare, null, OnPutFlareInPull, defaultCapacity: 10);
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

      SpawnFlare();
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

    private ParticleHandler CreateFlare()
    {
      var flare = Instantiate(FlareVFX, transform);

      return flare;
    }

    private void OnPutProjectileInPull(Projectile projectile)
    {
      projectile.gameObject.SetActive(false);
    }

    private void OnPutFlareInPull(ParticleHandler particleHandler)
    {
      particleHandler.gameObject.SetActive(false);
    }

    private void SpawnFlare()
    {
      var spawnedFlare = FlarePool.Get();

      spawnedFlare.Init(ShootingPoint.position, FlarePool);
    }
  }
}