using UnityEngine;
using Zenject;

namespace Factura
{
  public class PlayerHandler : CharacterHandler
  {
    [Header("")]
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private GameObject _model;

    [Header("")]
    [SerializeField] private PlayerController _playerController;

    private int _currentHealth;

    private ObjectPool<ParticleHandler> _explosionPool;

    [Inject] private GameController _gameController;

    private void Awake()
    {
      _explosionPool = new(ExplosionVFX, 1);
    }

    private void Start()
    {
      _currentHealth = MaxHealth;
    }

    private void OnEnable()
    {
      EventManager.OnPlayerHealed += OnHeal;
    }

    private void OnDisable()
    {
      EventManager.OnPlayerHealed -= OnHeal;
    }

    public override void Damage(int damage)
    {
      _currentHealth -= damage;

      if (_currentHealth <= 0)
      {
        _currentHealth = 0;

        Death();
      }

      EventManager.RaisePlayerHealthChanged(_currentHealth);
      EventManager.PlayerDamaged();
    }

    private void OnHeal(int health)
    {
      if (_currentHealth >= MaxHealth) return;

      _currentHealth += health;

      EventManager.RaisePlayerHealthChanged(_currentHealth);
    }

    public override void Death()
    {
      SpawnExplosion();

      _boxCollider.enabled = false;
      _model.SetActive(false);
      _playerController.StateMachine.ChangeState(new PlayerDeathState(_playerController));
      _gameController.ChangeState(GameStateEnum.Lose);
    }

    private void SpawnExplosion()
    {
      var explosion = _explosionPool.GetObjectFromPool(transform.position, transform.rotation, null);

      explosion.Init(transform.position, _explosionPool);
    }
  }
}