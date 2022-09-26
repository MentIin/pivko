using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    private Animator _animator;
    private Collider _collider;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();

    }

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnNextTurn += MakeTurn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MakeTurn()
    {
        Vector2Int dir = CheckAround();
        Move(dir.x, dir.y);
    }
    

    private void Move(int x, int y)
    {
        if (x == 0 && y == 0) return;
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("move")) return;
    
        float rot = 0f;
        if (x == 1) rot = -90f;
        if (x == -1) rot = 90f;
        if (y == 1) rot = 180f;
        if (y == -1) rot = 0f;
    
        transform.rotation = Quaternion.Euler(0f, rot, 0f);
        if (!CheckToward(x, y))
        {
            transform.position = transform.position + new Vector3(x, 0, y);
            _animator.SetTrigger("move");
            
        }

    }

    private RaycastHit Check(int x, int y, float distance)
    {
        Vector3 center = _collider.bounds.center;
        RaycastHit info;
        Vector3 dir = new Vector3(x, 0, y);
        Physics.BoxCast(center, transform.localScale / 10f, dir, out info, Quaternion.identity, distance);
        return info;
    }
    private bool CheckToward(int x, int y)
    {
        RaycastHit info = Check(x, y, 1);

        if (info.collider)
        {
            if (info.collider.CompareTag("Wall"))
            {
                return true;
            }

            if (info.collider.CompareTag("Box"))
            {
                return !info.collider.GetComponent<Box>().Move(x, y);
            }
            
        }
        return false;
    }

    private Vector2Int CheckAround()
    {
        for (int i = -2; i < 2; i++)
        {
            int x = i % 2;
            int y = (i + 1) % 2;
            RaycastHit info = Check(x, y, 10);
            if (info.collider)
            {
                if (info.collider.CompareTag("Player"))
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return Vector2Int.zero;
        

    }

    private void OnDestroy()
    {
        GameEvents.current.OnNextTurn -= MakeTurn;
    }
}
