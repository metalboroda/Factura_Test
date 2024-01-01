using UnityEngine;

namespace Factura
{
  public class PlayerPrefsController : MonoBehaviour
  {
    #region Level
    public int GetLevelIndex()
    {
      return PlayerPrefs.GetInt("LevelIndex");
    }

    public void SaveLevelIndex(int index)
    {
      PlayerPrefs.SetInt("LevelIndex", index);
    }

    public int GetRandomLevelIndex()
    {
      return PlayerPrefs.GetInt("RandomLevelIndex");
    }

    public void SaveRandomLevelIndex(int index)
    {
      PlayerPrefs.SetInt("RandomLevelIndex", index);
    }

    public int GetIsRandomLevel()
    {
      return PlayerPrefs.GetInt("IsRandomLevel");
    }

    public void SetIsRandomLevel(int value)
    {
      PlayerPrefs.SetInt("IsRandomLevel", value);
    }

    public int GetVisualLevelIndex()
    {
      return PlayerPrefs.GetInt("VisualLevelIndex");
    }

    public void SaveVisualLevelIndex(int index)
    {
      PlayerPrefs.SetInt("VisualLevelIndex", index);
    }
    #endregion
  }
}