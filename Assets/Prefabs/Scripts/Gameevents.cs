using System;
using UnityEngine;

public static class GameEvents
{
    public static event Action<Vector3> OnMoveCommand;
    public static event Action OnResetCommand;
    public static event Action OnMoveFinished;
    public static event Action<bool> OnBoxGoalChanged;
    public static event Action OnAllBoxesInPlace;

    public static void TriggerMove(Vector3 direction)
    {
        OnMoveCommand?.Invoke(direction);
    }

    public static void TriggerReset()
    {
        OnResetCommand?.Invoke();
    }

    public static void TriggerMoveFinished()
    {
        OnMoveFinished?.Invoke();
    }

    public static void TriggerBoxGoalChanged(bool isAtGoal)
    {
        OnBoxGoalChanged?.Invoke(isAtGoal);
    }

    public static void TriggerAllBoxesInPlace()
    {
        OnAllBoxesInPlace?.Invoke();
    }
}
