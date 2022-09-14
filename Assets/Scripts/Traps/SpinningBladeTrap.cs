using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBladeTrap : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private bool reverse = false;

    [SerializeField] private GameObject blade;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnNextTurn += Rotate;
        _animator = GetComponent<Animator>();
        _animator.SetBool("reverse", reverse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Rotate()
    {
        if (!reverse) {
            blade.transform.Rotate(Vector3.up, 90f);
        }
        else
        {
            blade.transform.Rotate(Vector3.up, -90f);
        }

        _animator.SetTrigger("rotate");
    }
}
