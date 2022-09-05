using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    public static LevelManager S;
    public int currentLevelId = 0;
    private void Awake()
    {
        S = this;
    }


    public void LoadLevel(int id)
    {
        if (id + 1 > levels.Length) return;
        SceneManager.LoadScene("GameScene");
        GameObject lvl = Instantiate(levels[id]);
        currentLevelId = id;
    }
}
