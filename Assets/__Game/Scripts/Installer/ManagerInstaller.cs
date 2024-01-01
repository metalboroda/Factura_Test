using UnityEngine;
using Zenject;

namespace Factura
{
  public class ManagerInstaller : MonoInstaller
  {
    [SerializeField] private UIManager _uiManager;

    public override void InstallBindings()
    {
      Container.Bind<UIManager>().FromInstance(_uiManager).AsSingle();
    }
  }
}