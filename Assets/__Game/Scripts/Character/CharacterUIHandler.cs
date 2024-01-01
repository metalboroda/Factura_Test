using UnityEngine;
using UnityEngine.UI;

namespace Factura
{
  public class CharacterUIHandler : MonoBehaviour
  {
    [SerializeField] protected Image HealthBar;

    protected virtual void UpdateHealthBar(int health)
    {
      HealthBar.fillAmount = (float)health / 100f;
    }
  }
}