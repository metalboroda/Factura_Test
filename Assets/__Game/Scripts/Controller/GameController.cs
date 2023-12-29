using System.Collections;
using UnityEngine;

namespace Factura
{
  public class GameController : MonoBehaviour
  {
    [field: SerializeField] public GameStateEnum GameState { get; private set; }

    public GameStateEnum CurrentState { get; private set; }

    private void Start()
    {
      ChangeState(GameStateEnum.Start);
      StartCoroutine(DoGameState());
    }

    public void ChangeState(GameStateEnum newState)
    {
      if (CurrentState != newState)
      {
        CurrentState = newState;
        GameState = newState;

        EventManager.RaiseGameStateChanged(GameState);
      }
    }

    // Temp
    private IEnumerator DoGameState()
    {
      yield return new WaitForSeconds(1);

      ChangeState(GameStateEnum.Game);
    }
  }
}