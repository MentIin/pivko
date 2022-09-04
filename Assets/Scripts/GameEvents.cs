using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnNextTurn;

    public void NextTurn()
    {
        if (OnNextTurn != null)
        {
            OnNextTurn();
        }
    }
    public event Action OnLevelComplete;

    public void LevelComplete()
    {
        if (OnLevelComplete != null)
        {
            OnLevelComplete();
        }
    }
}
