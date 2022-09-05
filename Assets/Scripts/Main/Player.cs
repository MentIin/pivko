using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator _anim;

    private Collider _collider;

    public static Player current;
    // Start is called before the first frame update
    void Start()
    {
        current = this;
        _anim = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckToward())
        {
            
        }
    }

    public void Move(int x, int y)
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("move")) return;
        
        float rot = 0f;
        if (x == 1) rot = -90f;
        if (x == -1) rot = 90f;
        if (y == 1) rot = 180f;
        if (y == -1) rot = 0f;
        
        transform.rotation = Quaternion.Euler(0f, rot, 0f);
        if (!CheckToward())
        {
            transform.position = transform.position + new Vector3(x, 0, y);
            _anim.SetTrigger("move");

            GameEvents.current.NextTurn();
        }
        
        
        
    }

    private bool CheckToward()
    {
        Vector3 center = _collider.bounds.center;
        RaycastHit info;
        Physics.BoxCast(center, transform.localScale / 2.1f, -transform.forward, out info, Quaternion.identity, 1);

        if (info.collider)
        {
            if (info.collider.CompareTag("Wall"))
            {
                return true;
            }
            
        }
        return false;
    }

    public void Die()
    {
        SceneManager.LoadScene("GameScene");
    }
}
