using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bochka : MonoBehaviour
{
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            GameEvents.current.LevelComplete();
            _animator.SetTrigger("claim");
            transform.parent = Player.current.transform.GetChild(0);
            //transform.position = new Vector3(0f, transform.position.y, 0f);

        }
    }
}
