using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager S;
    public int currentLevelId = 0;
    private void Awake()
    {
        S = this;
    }


    public void LoadLevel(int id)
    {
        SceneManager.LoadScene("GameScene");
        PlayerPrefs.SetInt("levelId", id);
        currentLevelId = id;
    }
}
