using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBladeTrap : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private GameObject blade;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnNextTurn += Rotate;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Rotate()
    {
        blade.transform.Rotate(Vector3.up, 90f);
        _animator.SetTrigger("rotate");
    }
}
