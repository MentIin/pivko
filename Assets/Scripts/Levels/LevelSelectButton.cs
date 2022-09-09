using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    public int levelId=0;
    private bool locked = true;
    private int stars = 0;
    [SerializeField] private GameObject starIndicator;

    public void Load()
    {
        if (locked) return;
        SceneManager.LoadScene("GameScene");
        PlayerPrefs.SetInt("levelId", levelId);
        
    }

    private void Start()
    {
        Level level = LevelsManager.levels[levelId];
       locked = level.Locked;
        
        if (locked)
        {
            gameObject.SetActive(false);
        }
        else
        {
            if (level.Stars == 1)
            {
                starIndicator.SetActive(true);
            }
            else
            {
                starIndicator.SetActive(false);
            }
        }
    }
}
