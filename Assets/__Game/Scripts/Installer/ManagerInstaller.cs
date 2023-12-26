using UnityEngine;
using Zenject;

namespace Factura
{
  public class ManagerInstaller : MonoInstaller
  {
    [SerializeField] private InputManager _inputManager;

    public override void InstallBindings()
    {
      Container.Bind<InputManager>().FromInstance(_inputManager).AsSingle();
    }
  }
}