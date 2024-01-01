using UnityEngine;
using UnityEngine.UI;

namespace Factura
{
  public class PlayerUIHandler : MonoBehaviour
  {
    [SerializeField] private Image _healthBar;

    private void OnEnable()
    {
      EventManager.OnPlayerHealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
      EventManager.OnPlayerHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(int health)
    {
      _healthBar.fillAmount = (float)health / 100f;
    }
  }
}