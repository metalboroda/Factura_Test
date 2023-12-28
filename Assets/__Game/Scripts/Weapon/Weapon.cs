using UnityEngine;

namespace Factura
{
  public abstract class Weapon : MonoBehaviour, IShootable
  {
    [SerializeField] protected Projectile Projectile;
    [SerializeField] protected Transform ShootingPoint;

    [Header("Projectile")]
    [SerializeField] protected int Speed;
    [SerializeField] protected int Power;

    [Header("Laser")]
    [SerializeField] private bool _needLaser;
    [SerializeField] private Material _laserMat;
    [SerializeField] private float _laserLength = 100f;
    [SerializeField] private float _startWidth = 0.2f;
    [SerializeField] private float _endWidth = 0;

    protected Projectile SpawnedProjectile;

    private LineRenderer laserLineRenderer;

    protected virtual void Start()
    {
      SetupLaser();
    }

    private void Update()
    {
      DrawLaser();
    }

    public virtual void Shoot() { }

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
  }
}