using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpikeGateTrigger : MonoBehaviour
{
    private Collider _collider;
    private Animator _animator;
    [SerializeField] private SpikeGate[] traps;
    private string[] tags = { "Player", "Box", "Enemy" };

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
        GameEvents.current.OnNextTurn += ActiveUpdate;
        SetActive(Check());
    }
    

    private void ActiveUpdate()
    {
        SetActive(Check());
        StartCoroutine(ActiveUpdate2());
    }

    private IEnumerator ActiveUpdate2()
    {
        yield return new WaitForSeconds(0.15f);
        SetActive(Check());
    }


    private bool Check()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.2f);
 
        foreach (var col in colliders)
        {
            if (tags.Contains(col.tag))
            {
                return false;
            }
        }
        return true;
    }



    private void SetActive(bool act)
    {
        _animator.SetBool("active", act);
        foreach (var trap in traps)
        {
            trap.active = act;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            SetActive(false);
        }
    }
    
}
