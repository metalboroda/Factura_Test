using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Zenject;

namespace Factura
{
  public class LevelController : MonoBehaviour
  {
    [SerializeField] private int _levelAmount;

    private string _address;
    private int _levelIndex;
    private int _randomLevelIndex;
    private GameObject _spawnedLevel;

    [Inject] private DiContainer _spawnContainer;

    [Inject] private PlayerPrefsController _playerPrefsController;

    private async void Start()
    {
      if (_playerPrefsController.GetIsRandomLevel() == 0)
      {
        _levelIndex = _playerPrefsController.GetLevelIndex();

        SetAddressIndex(_levelIndex);
      }
      else
      {
        _randomLevelIndex = _playerPrefsController.GetRandomLevelIndex();

        SetAddressIndex(_randomLevelIndex);
      }

      await LoadLevel(_address);
    }

    public void RestartLevel()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
      int visualIndex = _playerPrefsController.GetVisualLevelIndex();

      visualIndex++;
      _playerPrefsController.SaveVisualLevelIndex(visualIndex);

      if (_playerPrefsController.GetIsRandomLevel() == 0)
      {
        _levelIndex++;
        _playerPrefsController.SaveLevelIndex(_levelIndex);

        if (_levelIndex >= _levelAmount)
        {
          LoadRandomLevel();
        }
        else
        {
          SetAddressIndex(_levelIndex);

          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
      }
      else
      {
        int randLevel = Random.Range(0, _levelAmount + 1);

        _playerPrefsController.SaveRandomLevelIndex(randLevel);

        SetAddressIndex(randLevel);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
    }

    private void LoadRandomLevel()
    {
      int randLevel = Random.Range(1, _levelAmount + 1);

      _playerPrefsController.SaveLevelIndex(randLevel);

      SetAddressIndex(randLevel);

      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

      _playerPrefsController.SetIsRandomLevel(1);
    }

    public async Task<GameObject> LoadLevel(string address)
    {
      var loadOperation = Addressables.LoadAssetAsync<GameObject>(address);
      await loadOperation.Task;

      if (loadOperation.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
      {
        GameObject prefab = loadOperation.Result;

        _spawnedLevel = _spawnContainer.InstantiatePrefab(prefab);

        return _spawnedLevel;
      }
      else
      {
        Debug.Log($"No address: {address}");

        return null;
      }
    }

    private void SetAddressIndex(int index)
    {
      _address = $"Assets/__Game/Prefabs/Level/Level_{index}.prefab";
    }
  }
}