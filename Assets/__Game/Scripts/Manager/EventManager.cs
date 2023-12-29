using UnityEngine.Events;

namespace Factura
{
  public static class EventManager
  {
    #region GameController
    public static event UnityAction<GameStateEnum> OnGameStateChanged;
    public static void RaiseGameStateChanged(GameStateEnum state) => OnGameStateChanged?.Invoke(state);
    #endregion

    #region PlayerController
    public static event UnityAction<State> OnPlayerStateChanged;
    public static void RaisePlayerStateChanged(State state) => OnPlayerStateChanged?.Invoke(state);
    #endregion
  }
}