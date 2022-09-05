using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public bool active = true;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        
        GameEvents.current.OnNextTurn += MakeTurn;
        
        _animator.SetBool("active", active);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeTurn()
    {
        active = !active;
        _animator.SetBool("active", active);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;

        if (other.gameObject.CompareTag("Player"))
        {
            Player.current.Die();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!active) return;

        if (other.gameObject.CompareTag("Player"))
        {
            Player.current.Die();
        }
    }
}
