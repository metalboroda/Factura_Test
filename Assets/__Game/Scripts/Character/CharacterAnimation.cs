using UnityEngine;

namespace Factura
{
  public class CharacterAnimation : MonoBehaviour
  {
    [SerializeField] private CharacterAnimationSO _characterAnimationSO;

    [Header("")]
    [SerializeField] private float _crossfade = 0.2f;

    [Header("")]
    [SerializeField] private Animator _animator;

    public void IdleAnim()
    {
      _animator.CrossFadeInFixedTime(_characterAnimationSO.GetRandIdleAnim(), _crossfade);
    }

    public void RunAnim()
    {
      _animator.CrossFadeInFixedTime(_characterAnimationSO.GetRandRunAnim(), _crossfade);
    }
  }
}