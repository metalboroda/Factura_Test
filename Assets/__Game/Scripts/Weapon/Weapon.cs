using UnityEngine;
using UnityEngine.Pool;

namespace Factura
{
  public abstract class Weapon : MonoBehaviour, IShootable, IAutoShootable
  {
    [SerializeField] protected Projectile Projectile;
    [SerializeField] protected Transform ShootingPoint;

    [Header("Projectile")]
    [SerializeField] protected int Speed;
    [SerializeField] protected int Power;

    [Header("Shooting")]
    [SerializeField] protected bool Autoshooting;
    [SerializeField] protected float ShootingInterval = 0.3f;
    [SerializeField] protected LayerMask EnemyLayer;
    [SerializeField] protected float RayDistance = 100f;

    [Header("Laser")]
    [SerializeField] private bool _needLaser;
    [SerializeField] private Material _laserMat;
    [SerializeField] private float _laserLength = 100f;
    [SerializeField] private float _startWidth = 0.2f;
    [SerializeField] private float _endWidth = 0;

    [Header("VFX")]
    [SerializeField] protected ParticleHandler FlareVFX;

    protected ObjectPool<Projectile> ProjectilePool;
    protected ObjectPool<ParticleHandler> FlarePool;
    protected Projectile SpawnedProjectile;

    private LineRenderer laserLineRenderer;

    protected virtual void Start()
    {
      SetupLaser();
    }

    public virtual void Shoot() { }

    public virtual void AutoShoot() { }

    private void SetupLaser()
    {
      if (_needLaser == false) return;

      laserLineRenderer = gameObject.AddComponent<LineRenderer>();
      laserLineRenderer.material = _laserMat;
      laserLineRenderer.positionCount = 2;
      laserLineRenderer.startWidth = _startWidth;
      laserLineRenderer.endWidth = _endWidth;
    }

    protected void DrawLaser()
    {
      if (_needLaser == false) return;

      laserLineRenderer.SetPosition(0, ShootingPoint.position);

      Vector3 endPosition = ShootingPoint.position + ShootingPoint.forward * _laserLength;

      laserLineRenderer.SetPosition(1, endPosition);
    }

    protected bool DetectEnemy()
    {
      Ray ray = new(ShootingPoint.position, ShootingPoint.forward);
      bool hitEnemy = Physics.Raycast(ray, out RaycastHit hit, RayDistance, EnemyLayer);

      return hitEnemy;
    }
  }
}