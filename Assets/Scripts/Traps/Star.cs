using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private Animator _animator;

    private Collider _collider;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
        GameEvents.current.OnNextTurn += Check;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.S.CollectStar();
            Die();
        }
        Check();
    }

    private void OnTriggerExit(Collider other)
    {
        Check();
    }

    public void Die()
    {
        GameEvents.current.OnNextTurn -= Check;
        Destroy(this.gameObject);
    }

    private void Check()
    {
        Collider[] colliders = Physics.OverlapSphere(_collider.bounds.center, 0.1f);
 
        foreach (var col in colliders)
        {
            if (col.tag == "Enemy")
            {
                _animator.SetBool("fly", true);
                return;
            }
        }
        _animator.SetBool("fly", false);
    }
}
