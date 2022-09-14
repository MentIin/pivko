using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] private Text starCollectedText;
    [SerializeField] private Text turnsMade;

    private int turns=0;

    private void Start()
    {
        GameEvents.current.OnNextTurn += UpdateTurns;
        GameEvents.current.OnLevelComplete += SetUpText;
    }

    private void UpdateTurns()
    {
        turns += 1;
    }

    private void SetUpText()
    {
        if (GameManager.S.stars > 0)
        {
            starCollectedText.text = "звезда собрана";
        }
        else
        {
            starCollectedText.text = "звезда упущена";
        }

        turnsMade.text = "ходов сделано: " + turns;
    }

}
