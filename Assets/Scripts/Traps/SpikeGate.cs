using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGate : MonoBehaviour
{
    public bool active = true;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        _animator.SetBool("active", active);
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("active", active);
    }

    void MakeTurn()
    {
        active = !active;
        _animator.SetBool("active", active);
    }

    
}
