using UnityEngine.Events;

namespace Factura
{
  public static class EventManager
  {
    #region Game
    public static event UnityAction<GameStateEnum> OnGameStateChanged;
    public static void RaiseGameStateChanged(GameStateEnum state) => OnGameStateChanged?.Invoke(state);
    #endregion

    #region Player
    public static event UnityAction<State> OnPlayerStateChanged;
    public static void RaisePlayerStateChanged(State state) => OnPlayerStateChanged?.Invoke(state);

    public static event UnityAction<int> OnPlayerHealthChanged;
    public static void RaisePlayerHealthChanged(int health) => OnPlayerHealthChanged?.Invoke(health);

    public static event UnityAction<int> OnPlayerHealed;
    public static void RaisePlayerHealed(int health) => OnPlayerHealed?.Invoke(health);
    #endregion
  }
}