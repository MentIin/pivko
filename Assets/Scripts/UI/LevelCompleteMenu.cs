using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteMenu : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnLevelComplete += Show;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Show()
    {
        _animator.SetTrigger("show");
    }
}
