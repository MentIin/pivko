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

    public void Load()
    {
        print("sdf");
        if (locked) return;
        SceneManager.LoadScene("GameScene");
        PlayerPrefs.SetInt("levelId", levelId);
        
    }

    private void Start()
    {
       locked =  LevelsManager.levels[levelId].Locked;
        
        if (locked)
        {
            gameObject.SetActive(false);
        }
    }
}
