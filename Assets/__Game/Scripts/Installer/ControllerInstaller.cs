using UnityEngine;
using Zenject;

namespace Factura
{
  public class ControllerInstaller : MonoInstaller
  {
    [SerializeField] private GameController _gameController;

    public override void InstallBindings()
    {
      Container.Bind<GameController>().FromInstance(_gameController).AsSingle();
    }
  }
}