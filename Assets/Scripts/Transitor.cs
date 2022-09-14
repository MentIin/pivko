using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitor : MonoBehaviour
{
    public static Transitor S;
    [SerializeField] private Animator transitionAnim;
    private float transitionTime = 1f;

    private void Awake()
    {
        S = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel(int levelId)
    {
        PlayerPrefs.SetInt("levelId", levelId);
        StartCoroutine(LoadGameScene("GameScene"));
    }
 

    IEnumerator LoadGameScene(string name)
    {
        transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(name);
    }
    public void Load(string name)
    {
        StartCoroutine(LoadGameScene(name));
    }
 


}
