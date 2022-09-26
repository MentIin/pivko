using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteMenu : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private Text levelNameText;
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
        levelNameText.text = levelNameText.text + (LevelLoader.S.level + 1);
    }
}
