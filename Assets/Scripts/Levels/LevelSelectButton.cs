using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    private Animator _animator;
    public int levelId=0;
    private bool locked = true;
    private int stars = 0;
    [SerializeField] private GameObject starIndicator;

    public void Load()
    {
        if (locked) return;
        Transitor.S.LoadLevel(levelId);
        
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Level level = LevelsManager.levels[levelId];
       locked = level.Locked;
        
        if (locked)
        {
            _animator.SetBool("locked", true);
        }
        else
        {
            _animator.SetBool("locked", false);

            _animator.SetInteger("stars", level.Stars);

        }
    }
}
