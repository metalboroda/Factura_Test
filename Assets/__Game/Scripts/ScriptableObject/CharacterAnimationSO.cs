using System.Collections.Generic;
using UnityEngine;

namespace Factura
{
  [CreateAssetMenu(menuName = "CharacterAnimationSO")]
  public class CharacterAnimationSO : ScriptableObject
  {
    [SerializeField] public List<string> _idles = new();
    [SerializeField] public List<string> _runs = new();

    public string GetRandIdleAnim()
    {
      int rand = Random.Range(0, _idles.Count);

      return _idles[rand];
    }

    public string GetRandRunAnim()
    {
      int rand = Random.Range(0, _runs.Count);

      return _runs[rand];
    }
  }
}